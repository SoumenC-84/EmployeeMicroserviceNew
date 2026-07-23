using EmpManagemnt.Application.Common.Interface;
namespace EmpManagemnt.Infrastructure.Persistence.Repository;

public class EmployeeRepository : IEmployeeWriteRepository, IEmployeeReadRepository
{
    private readonly EmpDBContext _context;

    public EmployeeRepository(EmpDBContext context)
    {
        _context = context;
    }

    public async Task<int> CreateEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee.Id;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await Task.FromResult(_context.Employees);
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await Task.FromResult(_context.Employees.FirstOrDefault(e => e.Id == id));
    }

    public void CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }

}