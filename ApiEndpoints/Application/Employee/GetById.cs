using ApiEndpoints.Application.Common.Errors;
using ApiEndpoints.Infrastructure;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiEndpoints.Application.Employee;

public class GetById
{
    public sealed record Query(int Id) : IRequest<ErrorOr<Response>>;

    public record Response(int Id, string Name);
    
    public class QueryHandler: IRequestHandler<Query, ErrorOr<Response>>
    {
        private readonly ApiEndpointContext _context;

        public QueryHandler(ApiEndpointContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var employee =  await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee is null)
                return Errors.EmployeeNotFound(request.Id);

            return new Response(employee.Id, employee.Name);
        }
    }
}