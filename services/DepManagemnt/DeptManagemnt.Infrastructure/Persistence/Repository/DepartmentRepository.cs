using DeptManagemnt.Application.Features.Queries;
using DeptManagemnt.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using DeptManagemnt.Application.Common.Interfaces;

public class DepartmentRepository : IDepartmentCommand, IDepartmentQuery
{
    private readonly DepartmentDBContext _context;

    public DepartmentRepository(DepartmentDBContext context)
    {
        _context = context;
    }

    public async Task<int> AddDepartmentAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department.Id;
    }
    public async Task<List<Department>> GetAllDepartment(
     CancellationToken cancellationToken)
    {
        return await _context.Departments.ToListAsync(cancellationToken);
    }
    public async Task<Department> GetDepartmentById(int Id, CancellationToken cancellationToken)
    {
        return await _context.Departments.FirstOrDefaultAsync(d => d.Id == Id, cancellationToken);
    }
}