using DeptManagemnt.Application.Common.Interfaces;
using DeptManagemnt.Application.Features.Queries;

public class DepartmentGetAllQueryHandler : MediatR.IRequestHandler<DepartmentGetAllQuery,
            List<DeptManagemnt.Domain.Entity.Department>>
{
    private readonly IDepartmentQuery departmentGetQuery;
    public DepartmentGetAllQueryHandler(IDepartmentQuery _departmentGetQuery)
    {
        departmentGetQuery = _departmentGetQuery;
    }

    public async Task<List<DeptManagemnt.Domain.Entity.Department>>
                          Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
    {
        return await departmentGetQuery.GetAllDepartment(cancellationToken);
    }
    public async Task<DeptManagemnt.Domain.Entity.Department>
                          Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await departmentGetQuery.GetDepartmentById(request.Id, cancellationToken);
    }
}