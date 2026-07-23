using DeptManagemnt.Application.Common.Interfaces;
using DeptManagemnt.Domain.Entity;
using MediatR;

namespace DeptManagemnt.Application.Features.Commands.Department;

public class DepartmentAddCommandHandler : IRequestHandler<DepartmentAddCommand, int>
{
    private readonly IDepartmentCommand _departmentCommand;
    public DepartmentAddCommandHandler(IDepartmentCommand departmentCommand)
    {
        _departmentCommand = departmentCommand;
    }
    public async Task<int> Handle(DepartmentAddCommand request, CancellationToken cancellationToken)
    {

        return await _departmentCommand.AddDepartmentAsync(request.Department);
    }
}