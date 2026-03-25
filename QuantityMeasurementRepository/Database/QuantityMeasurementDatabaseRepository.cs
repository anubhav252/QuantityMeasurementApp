using Microsoft.Data.SqlClient;
using QuantityMeasurementModel.Models;
using QuantityMeasurementRepository.Interfaces;
using QuantityMeasurementRepository.DbException;
using QuantityMeasurementRepository.Configuration;

namespace QuantityMeasurementRepository.Database
{
    public class QuantityMeasurementDatabaseRepository : IQuantityMeasurementRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        public void Save(QuantityMeasurementEntity entity)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                string query = @"INSERT INTO QuantityMeasurements (Value, Unit, Category)
                                 OUTPUT INSERTED.Id
                                 VALUES (@Value, @Unit, @Category)";

                using SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Value", entity.Value);
                cmd.Parameters.AddWithValue("@Unit", entity.Unit);
                cmd.Parameters.AddWithValue("@Category", entity.Category);

                entity.Id = (int)cmd.ExecuteScalar(); // capture ID
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to save quantity", ex);
            }
        }

        //  Save operation history
        public void SaveOperation(OperationHistoryEntity op)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                string query = @"INSERT INTO OperationHistory
                                (FirstQuantityId, SecondQuantityId, OperationType, ResultValue, ResultUnit)
                                VALUES (@F, @S, @Op, @Val, @Unit)";

                using SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@F", op.FirstQuantityId);
                cmd.Parameters.AddWithValue("@S", op.SecondQuantityId);
                cmd.Parameters.AddWithValue("@Op", op.OperationType);
                cmd.Parameters.AddWithValue("@Val", op.ResultValue);
                cmd.Parameters.AddWithValue("@Unit", op.ResultUnit);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to save operation", ex);
            }
        }
        public List<QuantityMeasurementEntity> GetAll()
        {
            var list = new List<QuantityMeasurementEntity>();

            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                string query = "SELECT * FROM QuantityMeasurements";

                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new QuantityMeasurementEntity
                    {
                        Id = (int)reader["Id"],
                        Value = (double)reader["Value"],
                        Unit = reader["Unit"].ToString(),
                        Category = reader["Category"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to fetch data", ex);
            }

            return list;
        }

        public List<OperationHistoryEntity> GetOperationHistory()
        {
            var list = new List<OperationHistoryEntity>();
        
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();
        
                string query = "SELECT * FROM OperationHistory ORDER BY CreatedAt DESC";
        
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
        
                while (reader.Read())
                {
                    list.Add(new OperationHistoryEntity
                    {
                        Id = (int)reader["Id"],
                        FirstQuantityId = (int)reader["FirstQuantityId"],
                        SecondQuantityId = (int)reader["SecondQuantityId"],
                        OperationType = reader["OperationType"].ToString(),
                        ResultValue = Convert.ToDouble(reader["ResultValue"]),
                        ResultUnit = reader["ResultUnit"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to fetch operation history", ex);
            }
        
            return list;
        }
        public void DeleteAllRecords()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                string deleteHistory = "DELETE FROM OperationHistory";
                string deleteMeasurements = "DELETE FROM QuantityMeasurements";

                using SqlCommand cmd = new SqlCommand(deleteHistory, conn);
                cmd.ExecuteNonQuery();

                cmd.CommandText = deleteMeasurements;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Failed to delete all records", ex);
            }
        }
    }
}