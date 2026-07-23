using DeptManagemnt.Domain.Entity;
namespace DeptManagemnt.Application.Common.Interfaces;

public interface IDepartmentCommand
{
    Task<int> AddDepartmentAsync(Department department);
}