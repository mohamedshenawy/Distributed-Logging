namespace Domain.LogAggregate.Entities;

public class LogEntry
{
    public Guid Id { get;}
    public DateTime Timestamp { get;}
    public string ServiceName { get; private set; }
    public string LogLevel { get; private set; }
    public string Message { get; private set; }


    public LogEntry(string serviceName, string message, string logLevel)
    {
        if (string.IsNullOrEmpty(serviceName))
            throw new ArgumentNullException("Service Name should have a value");
        
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("message should have a value");

        if (string.IsNullOrEmpty(logLevel))
            throw new ArgumentOutOfRangeException("log Level should be greater than Id");

        Id = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
        ServiceName = serviceName;
        LogLevel = logLevel;
        Message = message;
    }

}
