namespace HistoryService.DTOs
{
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    // Received from QMAOperationService
    public class SaveOperationRequest
    {
        public QuantityDTO First { get; set; } = new();
        public QuantityDTO Second { get; set; } = new();
        public string OperationType { get; set; } = string.Empty;
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public string? UserId { get; set; }
    }

    // Returned to authenticated users
    public class HistoryResponse
    {
        public List<QuantityMeasurementDTO> Quantities { get; set; } = new();
        public List<OperationDTO> Operations { get; set; } = new();
    }

    public class QuantityMeasurementDTO
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class OperationDTO
    {
        public int Id { get; set; }
        public int FirstQuantityId { get; set; }
        public int SecondQuantityId { get; set; }
        public string OperationType { get; set; } = string.Empty;
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? UserId { get; set; }
    }
}
