namespace EmpManagemnt.Application.Common.Interface;

public interface IEmployeeReadRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee?> GetEmployeeById(int id);

}
