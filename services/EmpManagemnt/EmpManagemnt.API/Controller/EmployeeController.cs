using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace EmpManagemnt.API.Controllers;

[ApiController]
[Route("api/[controller]")] // This resolves to: api/Employee
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public EmployeeController(IMediator mediator, ILogger logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
    {
        var query = new ReadAllEmployeesQuery();
        var employees = await _mediator.Send(query, cancellationToken);
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id, CancellationToken cancellationToken)
    {
        var query = new ReadEmployeeQuery(id);
        var employee = await _mediator.Send(query, cancellationToken);

        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CreateEmployee API Hit");
        try
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var command = new CreateEmployeeCommand(employee);

            // CRITICAL FIX: You MUST await this call so the employee gets saved 
            // to the database before executing the next line.
            await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
