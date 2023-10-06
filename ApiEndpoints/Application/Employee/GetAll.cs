using MediatR;

namespace ApiEndpoints.Application.Employee;

public class GetAll
{
    public sealed record Query : IRequest<List<Response>>;

    public sealed record Response();
    
    public class QueryHandler: IRequestHandler<Query, List<Response>>
    {
        public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Response>());
        }
    }
}

