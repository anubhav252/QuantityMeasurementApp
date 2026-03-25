using QuantityMeasurementModel.DTOs;
using QuantityMeasurementModel.Models;

namespace QuantityMeasurementServices.Interfaces
{
    
    public interface IQuantityMeasurementService
    {
        bool Compare(QuantityDTO first, QuantityDTO second);
        QuantityModel Convert(QuantityDTO source, string targetUnit);
        QuantityModel Add(QuantityDTO first, QuantityDTO second, string targetUnit);
        QuantityModel Subtract(QuantityDTO first, QuantityDTO second, string targetUnit);
        double Divide(QuantityDTO first, QuantityDTO second);
        (List<QuantityMeasurementEntity> quantities, List<OperationHistoryEntity> operations) GetFullHistory();
        List<OperationHistoryEntity> GetOperationHistory();
        void DeleteAllRecords();
    }
}
