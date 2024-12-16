using Application.Commands;
using Application.Interfaces;
using Domain.LogAggregate.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/logs")]
public class LogController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public LogController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLog([FromBody] CreateLogEntryCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.Select(v=>v.Errors.SelectMany(e=>e.ErrorMessage).ToList()));
        }

        var log = new LogEntry(
            serviceName: command.ServiceName, 
            message: command.Message, 
            logLevel: command.LogLevel
            );
        

        await _unitOfWork.Logs.AddAsync(log);
        await _unitOfWork.CompleteAsync();



        //return CreatedAtAction(nameof(GetLogs), new { id = log.Id }, log);
        return Ok();
    }

    //[HttpGet]
    //public async Task<IActionResult> GetLogs()
    //{
    //    // get from database
    //    var logs = await _unitOfWork.Logs.GetAllAsync();
    //    return Ok(logs);
    //}

    [HttpGet]
    public async Task<IActionResult> GetFilteredLogs ([FromQuery] DateTime? start, [FromQuery] DateTime? end, [FromQuery] string? level)
    {
        // get from database
        var logs = await _unitOfWork.Logs.GetFilteredLogsAsync(start , end , level);
        return Ok(logs);
    }
}
