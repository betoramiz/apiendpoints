using ApiEndpoints.Data;
using Carter.ModelBinding;
using FluentValidation;

namespace ApiEndpoints.Features.Employee;

public class Create
{
    public sealed record Command(string Name);
    
    public class Validator: AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
    
    public static IResult CreateEmployee(HttpRequest request, Command employee)
    {
        var validator = request.Validate<Command>(employee);
        if (!validator.IsValid)
            return Results.BadRequest(validator.Errors.Select(e => e.ErrorMessage));

        var max = Database.GetData().Max(emp => emp.Id);
        var id = max + 1;
        var newEmployee = Data.Employee.Create(id, employee.Name);
    
        Database.Add(newEmployee);
        return Results.Created($"/employee/{newEmployee.Id}", newEmployee);
    }
}