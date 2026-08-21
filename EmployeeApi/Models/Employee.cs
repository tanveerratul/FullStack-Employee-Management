namespace EmployeeApi.Models;

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
}