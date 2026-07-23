using MediatR;

public sealed record ReadEmployeeQuery(int Id) :
                          IRequest<Employee?>;

public sealed record ReadAllEmployeesQuery() :
                          IRequest<IEnumerable<Employee>>;