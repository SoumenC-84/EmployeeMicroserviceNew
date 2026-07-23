using DeptManagemnt.Domain.Entity;
using MediatR;

namespace DeptManagemnt.Application.Features.Commands.Department;

public sealed record DepartmentAddCommand(DeptManagemnt.Domain.Entity.Department Department) : IRequest<int>;