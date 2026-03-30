using QuantityMeasurementModel.DTOs;
using QuantityMeasurementModel.Models;

namespace QuantityMeasurementServices.Interfaces
{
    
    public interface IQuantityMeasurementService
    {
        bool Compare(QuantityDTO first, QuantityDTO second);
        QuantityDTO Convert(QuantityDTO source, string targetUnit);
        QuantityDTO Add(QuantityDTO first, QuantityDTO second, string targetUnit);
        QuantityDTO Subtract(QuantityDTO first, QuantityDTO second, string targetUnit);
        double Divide(QuantityDTO first, QuantityDTO second);
        HistoryResponse GetFullHistory();
        void DeleteAllRecords();
    }
}
