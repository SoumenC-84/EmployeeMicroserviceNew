using DeptManagemnt.Domain.Entity;
using Microsoft.EntityFrameworkCore;

public class DepartmentDBContext : DbContext
{
    public DepartmentDBContext(DbContextOptions<DepartmentDBContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
}