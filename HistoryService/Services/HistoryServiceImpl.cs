using HistoryService.DTOs;
using HistoryService.Interfaces;
using HistoryService.Models;

namespace HistoryService.Services
{
    public class HistoryServiceImpl : IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryServiceImpl(IHistoryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Called internally by QMAOperationService after each computation.
        /// Saves both input quantities and the operation record.
        /// </summary>
        public void SaveOperation(SaveOperationRequest request)
        {
            var firstEntity = _repository.SaveQuantity(new QuantityMeasurementEntity
            {
                Value    = request.First.Value,
                Unit     = request.First.Unit,
                Category = request.First.Category
            });

            var secondEntity = _repository.SaveQuantity(new QuantityMeasurementEntity
            {
                Value    = request.Second.Value,
                Unit     = request.Second.Unit,
                Category = request.Second.Category
            });

            _repository.SaveOperation(new OperationHistoryEntity
            {
                FirstQuantityId  = firstEntity.Id,
                SecondQuantityId = secondEntity.Id,
                OperationType    = request.OperationType,
                ResultValue      = request.ResultValue,
                ResultUnit       = request.ResultUnit,
                UserId           = request.UserId,
                CreatedAt        = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Returns operation history and associated quantities for a specific user.
        /// </summary>
        public HistoryResponse GetHistoryByUser(string userId)
        {
            var operations = _repository.GetOperationsByUser(userId);

            var quantityIds = operations
                .SelectMany(o => new[] { o.FirstQuantityId, o.SecondQuantityId })
                .Distinct()
                .ToList();

            var quantities = _repository.GetQuantitiesByIds(quantityIds);

            return new HistoryResponse
            {
                Quantities = quantities.Select(q => new QuantityMeasurementDTO
                {
                    Id       = q.Id,
                    Value    = q.Value,
                    Unit     = q.Unit,
                    Category = q.Category
                }).ToList(),

                Operations = operations.Select(o => new OperationDTO
                {
                    Id               = o.Id,
                    FirstQuantityId  = o.FirstQuantityId,
                    SecondQuantityId = o.SecondQuantityId,
                    OperationType    = o.OperationType,
                    ResultValue      = o.ResultValue,
                    ResultUnit       = o.ResultUnit,
                    CreatedAt        = o.CreatedAt,
                    UserId           = o.UserId
                }).ToList()
            };
        }

        /// <summary>
        /// Deletes all history records belonging to a specific user.
        /// </summary>
        public void DeleteHistoryByUser(string userId)
            => _repository.DeleteAllByUser(userId);
    }
}
