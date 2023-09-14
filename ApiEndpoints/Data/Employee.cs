namespace ApiEndpoints.Data;

public class Employee
{
    public Employee(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public int Id { get; init; }
    public string Name { get; init; }

    public static Employee Create(int id, string name)
    {
        return new Employee(id, name);
    }
}

