using Domain.LogAggregate.Entities;

namespace Application.Interfaces
{
    public interface ILogRepository : IRepository<LogEntry>
    {
        Task<IEnumerable<LogEntry>> GetLogsByServiceAsync(string serviceName);
        Task<IEnumerable<LogEntry>> GetFilteredLogsAsync(DateTime? start, DateTime? end, string level);
    }
}
