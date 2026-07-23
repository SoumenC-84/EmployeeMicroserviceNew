namespace DeptManagemnt.Application.Common.Interfaces;

public interface IDepartmentQuery
{
    Task<List<DeptManagemnt.Domain.Entity.Department>> GetAllDepartment(
    CancellationToken cancellationToken);
    Task<DeptManagemnt.Domain.Entity.Department>
                      GetDepartmentById(int Id, CancellationToken cancellationToken);
}
