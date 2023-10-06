using ErrorOr;

namespace ApiEndpoints.Application.Employee;

public static class Errors
{
    public static Error EmployeeNotFound(int id) => Error.NotFound(code: "employee_not_found", description: $"Employee with id {id} was not found");
}