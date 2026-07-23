using EmpManagemnt.Application.Common.Interface;
using MediatR;

public class EmployeeReadServiceQueryHandler : IRequestHandler<ReadEmployeeQuery, Employee?>,
                                                IRequestHandler<ReadAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeReadRepository _employeeRepository;

    public EmployeeReadServiceQueryHandler(IEmployeeReadRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee?> Handle(ReadEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeById(request.Id);
    }

    public async Task<IEnumerable<Employee>> Handle(ReadAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetAllEmployees();
    }
}