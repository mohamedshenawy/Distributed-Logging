using System.ComponentModel.DataAnnotations;

namespace Application.Commands;

public record CreateLogEntryCommand(
    [Required] string ServiceName,
    [Required] string LogLevel,
    [Required] string Message
);