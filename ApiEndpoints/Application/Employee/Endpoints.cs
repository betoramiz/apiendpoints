using Carter;
using MediatR;

namespace ApiEndpoints.Application.Employee;

public class Endpoints: ICarterModule
{
    private readonly IMediator _mediator;

    public Endpoints(IMediator mediator) => _mediator = mediator;

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var appGroup = app.MapGroup("employee");
        
        appGroup.MapPost("", async (Create.Command request) =>
        {
            var response = await _mediator.Send(request);
            return response.Match(
                res => Results.CreatedAtRoute("{id:int}", new { id = res }, res),
                error => Results.Problem()
            );
        });
        // appGroup.MapGet("/all", GetAll.Execute);
        appGroup.MapGet("{id:int}", async (int id) =>
        {
            var result = await _mediator.Send(new GetById.Query(id));
            result.Match(
                Results.Ok,
                error => Results.Problem()
            );
        });
    }
}