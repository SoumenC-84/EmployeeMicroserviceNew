using EmpManagemnt.Application.Common.Interface;
using MediatR;
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeWriteRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = request.Employee;
        await _employeeRepository.CreateEmployeeAsync(employee);
        return employee.Id;
    }
}