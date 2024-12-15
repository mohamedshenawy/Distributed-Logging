using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly LogDbContext _context;

        public UnitOfWork(LogDbContext context)
        {
            _context = context;
            Logs = new LogRepository(context);
        }

        public ILogRepository Logs { get; }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
