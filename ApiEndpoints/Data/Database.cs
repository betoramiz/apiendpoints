namespace ApiEndpoints.Data;

public static class Database
{
    private static List<Employee> _employees = new()
    {
        new Employee(1, "Alberto Ramirez"),
        new Employee(2, "Alejandro Ramirez"),
        new Employee(3, "Mode Perez"),
        new Employee(4, "Jose Manuel Ramirez"),
    };

    public static IEnumerable<Employee> GetData() => _employees;

    public static void Add(Employee employee) => _employees.Add(employee);
}