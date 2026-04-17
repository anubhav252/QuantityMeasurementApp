using HistoryService.Models;

namespace HistoryService.Interfaces
{
    public interface IHistoryRepository
    {
        // Quantities
        QuantityMeasurementEntity SaveQuantity(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetQuantitiesByIds(IEnumerable<int> ids);

        // Operations
        void SaveOperation(OperationHistoryEntity entity);
        List<OperationHistoryEntity> GetAllOperations();
        List<OperationHistoryEntity> GetOperationsByUser(string userId);

        // Delete
        void DeleteAllByUser(string userId);
    }
}
