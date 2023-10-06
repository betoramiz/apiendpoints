namespace ApiEndpoints.Domain;

public class Employee
{
    private Employee(string Name)
    {
        this.Name = Name;
    }

    public int Id { get; init; }
    public string Name { get; init; }

    public static Employee Create(string name)
    {
        return new Employee(name);
    }
}

