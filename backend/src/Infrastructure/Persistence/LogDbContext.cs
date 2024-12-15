using Domain.LogAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Persistence;

public class LogDbContext : DbContext
{
    public DbSet<LogEntry> LogEntries { get; set; }

    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogEntry>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LogLevel).IsRequired();
            entity.Property(e => e.Message).IsRequired();
            entity.Property(e => e.Timestamp).IsRequired();
        });
    }
}