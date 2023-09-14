using Carter;

namespace ApiEndpoints.Features.Employee;

public class Endpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var appGroup = app.MapGroup("employee");
        
        appGroup.MapPost("", Create.CreateEmployee);
        appGroup.MapGet("/all", GetAll.Execute);
        appGroup.MapGet("{id:int}", GetById.Execute);
    }
}