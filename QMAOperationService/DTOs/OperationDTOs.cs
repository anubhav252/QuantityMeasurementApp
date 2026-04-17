namespace QMAOperationService.DTOs
{
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class CompareRequest
    {
        public QuantityDTO First { get; set; } = new();
        public QuantityDTO Second { get; set; } = new();
    }

    public class QuantityRequest
    {
        public QuantityDTO First { get; set; } = new();
        public QuantityDTO Second { get; set; } = new();
        public string TargetUnit { get; set; } = string.Empty;
    }

    public class DivideRequest
    {
        public QuantityDTO First { get; set; } = new();
        public QuantityDTO Second { get; set; } = new();
    }

    public class ConvertRequest
    {
        public QuantityDTO Input { get; set; } = new();
        public string TargetUnit { get; set; } = string.Empty;
    }

    // Sent to HistoryService via HTTP
    public class SaveOperationRequest
    {
        public QuantityDTO First { get; set; } = new();
        public QuantityDTO Second { get; set; } = new();
        public string OperationType { get; set; } = string.Empty;
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public string? UserId { get; set; }
    }
}
