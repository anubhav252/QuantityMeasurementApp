using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Data
{
    public class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options) { }

        public DbSet<QuantityMeasurementEntity> Quantities { get; set; }
        public DbSet<OperationHistoryEntity> Operations { get; set; }
    }
}
