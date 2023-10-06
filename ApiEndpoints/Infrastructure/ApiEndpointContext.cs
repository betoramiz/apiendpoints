using ApiEndpoints.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiEndpoints.Infrastructure;

public class ApiEndpointContext: DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    
    public ApiEndpointContext(DbContextOptions<ApiEndpointContext> contextOptions): base(contextOptions)
    {
    }
}