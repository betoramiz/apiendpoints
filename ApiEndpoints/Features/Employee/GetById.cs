using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiEndpoints.Features.Employee;

public class GetById
{
    public static Results<Ok<Data.Employee>, NotFound> Execute(int id)
    {
        var employee = Data.Database.GetData().FirstOrDefault(emp => emp.Id == id);
        if (employee is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(employee);
    }
}