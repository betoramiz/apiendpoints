using ErrorOr;
using FluentValidation.Results;

namespace ApiEndpoints.Application.Common.Errors;

public static partial class Errors
{
    public static List<Error> GetErrors(IEnumerable<ValidationFailure> errors) =>
        errors
            .Select(e => Error.Validation(code: e.PropertyName, description: e.ErrorMessage))
            .ToList();
}