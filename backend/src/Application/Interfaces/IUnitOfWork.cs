namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILogRepository Logs { get; }
        Task<int> CompleteAsync();
    }
}
