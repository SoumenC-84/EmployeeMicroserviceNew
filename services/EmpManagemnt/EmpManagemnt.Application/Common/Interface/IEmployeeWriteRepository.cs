namespace EmpManagemnt.Application.Common.Interface;

public interface IEmployeeWriteRepository
{
    Task<int> CreateEmployeeAsync(Employee employee);
    void CreateEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}