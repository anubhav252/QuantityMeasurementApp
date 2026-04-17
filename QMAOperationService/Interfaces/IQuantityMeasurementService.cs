using QMAOperationService.DTOs;

namespace QMAOperationService.Interfaces
{
    public interface IQuantityMeasurementService
    {
        Task<bool> Compare(QuantityDTO first, QuantityDTO second, string? userId = null);
        QuantityDTO Convert(QuantityDTO source, string targetUnit);
        Task<QuantityDTO> Add(QuantityDTO first, QuantityDTO second, string targetUnit, string? userId = null);
        Task<QuantityDTO> Subtract(QuantityDTO first, QuantityDTO second, string targetUnit, string? userId = null);
        Task<double> Divide(QuantityDTO first, QuantityDTO second, string? userId = null);
    }
}
