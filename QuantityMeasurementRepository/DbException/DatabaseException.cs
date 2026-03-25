namespace QuantityMeasurementRepository.DbException
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception inner)
            : base(message, inner) { }
    }
}