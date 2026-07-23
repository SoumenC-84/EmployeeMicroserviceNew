using MediatR;
public sealed record CreateEmployeeCommand(
    Employee Employee
) : IRequest<int>;