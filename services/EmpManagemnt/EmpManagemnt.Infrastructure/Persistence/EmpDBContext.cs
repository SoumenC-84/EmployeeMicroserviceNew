using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
public class EmpDBContext : DbContext
{
    public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}