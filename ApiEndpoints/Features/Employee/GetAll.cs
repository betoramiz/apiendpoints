using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiEndpoints.Features.Employee;

public class GetAll
{
    public static IEnumerable<Data.Employee> Execute()
    {
        return Data.Database.GetData().ToList();
    }
}