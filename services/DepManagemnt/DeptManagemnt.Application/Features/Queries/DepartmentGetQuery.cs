using MediatR;
using DeptManagemnt.Domain.Entity;
namespace DeptManagemnt.Application.Features.Queries;

public sealed record DepartmentGetAllQuery() : IRequest<List<Department>>;
public sealed record DepartmentGetByIdQuery(int Id) : IRequest<Department>;