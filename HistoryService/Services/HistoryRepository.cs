using HistoryService.Data;
using HistoryService.Interfaces;
using HistoryService.Models;

namespace HistoryService.Services
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly HistoryDbContext _context;

        public HistoryRepository(HistoryDbContext context)
        {
            _context = context;
        }

        public QuantityMeasurementEntity SaveQuantity(QuantityMeasurementEntity entity)
        {
            _context.Quantities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<QuantityMeasurementEntity> GetQuantitiesByIds(IEnumerable<int> ids)
            => _context.Quantities.Where(q => ids.Contains(q.Id)).ToList();

        public void SaveOperation(OperationHistoryEntity entity)
        {
            _context.Operations.Add(entity);
            _context.SaveChanges();
        }

        public List<OperationHistoryEntity> GetAllOperations()
            => _context.Operations.ToList();

        public List<OperationHistoryEntity> GetOperationsByUser(string userId)
            => _context.Operations.Where(o => o.UserId == userId).ToList();

        public void DeleteAllByUser(string userId)
        {
            var ops = _context.Operations.Where(o => o.UserId == userId).ToList();
            _context.Operations.RemoveRange(ops);
            _context.SaveChanges();
        }
    }
}
