using Carter;
using MediatR;
using O9d.AspNet.FluentValidation;

namespace ApiEndpoints.Application.Employee;

public class Endpoints: ICarterModule
{
    private readonly IMediator _mediator;

    public Endpoints(IMediator mediator) => _mediator = mediator;

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var appGroup = app.MapGroup("api/employee")
            .WithValidationFilter(); // O9d.AspNet.FluentValidation
        
        appGroup.MapGet("/{id:int}", async (int id) => await GetEmployee(id));
        appGroup.MapPost("", async ([Validate] Create.Command request) => await CreateEmployee(request));
    }
    
    private async Task<IResult> CreateEmployee(Create.Command request)
    {
        var response = await _mediator.Send(request);
        return response.Match(
            res => Results.CreatedAtRoute("{id:int}", new { id = res }, res),
            error => Results.Problem()
        );
    }

    private async Task<IResult> GetEmployee(int id)
    {
        var result = await _mediator.Send(new GetById.Query(id));
        return result.Match(
            Results.Ok,
            error => Results.Problem()
        );
    }
}