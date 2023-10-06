using ErrorOr;

namespace ApiEndpoints.Application.Common.Errors;

public static partial class Errors
{
    public static class EntityFramework
    {
        public static Error ImpossibleToSave => Error.Failure(code: "EF.SaveToDatabase", "No se pudo guardar en base de datos");
    }
}