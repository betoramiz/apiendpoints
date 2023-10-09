using ApiEndpoints.Infrastructure;
using Carter.ModelBinding;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace ApiEndpoints.Application.Employee;

public class Create
{
    public sealed record Command(string Name): IRequest<ErrorOr<int>>;
    
    public class Validator: AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
    
    public class CommandHandler: IRequestHandler<Command, ErrorOr<int>>
    {
        private readonly ApiEndpointContext _context;
        private readonly HttpRequest _httpRequest;
        public CommandHandler(HttpRequest httpRequest, ApiEndpointContext context)
        {
            _httpRequest = httpRequest;
            _context = context;
        }

        public async Task<ErrorOr<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validator = _httpRequest.Validate<Command>(request);
            if (!validator.IsValid)
                return Common.Errors.Errors.GetErrors(validator.Errors);
        
            var newEmployee = Domain.Employee.Create(request.Name);
            var result = await SaveAsync(newEmployee, cancellationToken);
        
            return result.IsError? result.Errors : result.Value;
        }
        
        private async Task<ErrorOr<int>> SaveAsync(Domain.Employee employee, CancellationToken cancellationToken)
        {
            try
            {
                _context.Employees.Add(employee);
                var result = await _context.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                return Common.Errors.Errors.EntityFramework.ImpossibleToSave;
            }
        }
    }
}