using Application.Interfaces;
using Domain.LogAggregate.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LogRepository : Repository<LogEntry>, ILogRepository
    {
        public LogRepository(LogDbContext context) : base(context) { }

        public async Task<IEnumerable<LogEntry>> GetFilteredLogsAsync(DateTime? start, DateTime? end, string level)
        {
            return await _context.LogEntries
                .Where(log => (!start.HasValue || log.Timestamp >= start)
                           && (!end.HasValue || log.Timestamp <= end)
                           && (string.IsNullOrEmpty(level) || log.LogLevel == level))
                .OrderByDescending(e=>e.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<LogEntry>> GetLogsByServiceAsync(string serviceName)
        {
            return await _context.LogEntries
                .Where(log => log.ServiceName == serviceName)
                .ToListAsync();
        }
    }
}
