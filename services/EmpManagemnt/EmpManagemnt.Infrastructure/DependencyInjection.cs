using EmpManagemnt.Application.Common.Interface;
using EmpManagemnt.Infrastructure.Persistence.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                        IConfiguration configuration)
    {
        services.AddDbContext<EmpDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEmployeeWriteRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeReadRepository, EmployeeRepository>();
        services.AddScoped<IMediator, Mediator>();

        return services;
    }
}