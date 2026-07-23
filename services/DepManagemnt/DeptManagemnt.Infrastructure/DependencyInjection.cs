using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DeptManagemnt.Application.Common.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
          IConfiguration configuration)
    {
        services.AddDbContext<DepartmentDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDepartmentCommand, DepartmentRepository>();
        services.AddScoped<IDepartmentQuery, DepartmentRepository>();
        return services;
    }
}