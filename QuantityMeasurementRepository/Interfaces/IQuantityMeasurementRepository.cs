using QuantityMeasurementModel.Models;

namespace QuantityMeasurementRepository.Interfaces
{
    public interface IQuantityMeasurementRepository
    {
        void Save(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAll();
        List<OperationHistoryEntity> GetOperationHistory();
        void DeleteAllRecords();
        
    }
}