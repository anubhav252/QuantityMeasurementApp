using System.ComponentModel.DataAnnotations;

namespace HistoryService.Models
{
    public class QuantityMeasurementEntity
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class OperationHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        public int FirstQuantityId { get; set; }
        public int SecondQuantityId { get; set; }
        public string OperationType { get; set; } = string.Empty;
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }
    }
}
