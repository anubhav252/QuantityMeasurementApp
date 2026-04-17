using HistoryService.DTOs;

namespace HistoryService.Interfaces
{
    public interface IHistoryService
    {
        void SaveOperation(SaveOperationRequest request);
        HistoryResponse GetHistoryByUser(string userId);
        void DeleteHistoryByUser(string userId);
    }
}
