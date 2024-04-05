using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Phone { get; set; }
    public string? Position { get; set; }
    public RolType Rol { get; set; }
}