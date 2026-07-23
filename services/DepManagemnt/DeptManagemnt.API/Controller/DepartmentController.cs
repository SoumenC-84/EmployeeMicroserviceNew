using DeptManagemnt.Application.Features.Commands.Department;
using DeptManagemnt.Application.Features.Queries;
using DeptManagemnt.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{

    private readonly MediatR.IMediator _mediator;
    public DepartmentController(MediatR.IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] Department department)
    {
        DepartmentAddCommand command = new DepartmentAddCommand(department);
        await _mediator.Send(command);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        DepartmentGetAllQuery query = new DepartmentGetAllQuery();
        var departments = await _mediator.Send(query);
        return Ok(departments);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        DepartmentGetByIdQuery query = new DepartmentGetByIdQuery(id);
        var department = await _mediator.Send(query);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }
}