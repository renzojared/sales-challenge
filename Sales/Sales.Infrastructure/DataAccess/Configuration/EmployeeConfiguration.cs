using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using Sales.Domain.Enums;

namespace Sales.Infrastructure.DataAccess.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .Property(s => s.Code)
            .HasMaxLength(10)
            .IsRequired();

        builder
            .HasIndex(s => s.Code)
            .IsUnique();

        builder
            .Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(s => s.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(s => s.Password)
            .IsRequired();

        builder
            .Property(s => s.Phone)
            .HasMaxLength(9);

        builder
            .Property(s => s.Position)
            .HasMaxLength(20);

        builder
            .Property(s => s.Rol)
            .IsRequired();

        builder.HasKey(s => s.Id);

        builder.HasData(
            new Employee
                { Id = 1, Code = "MM11", Name = "Jose", Email = "user1@company.com", Password = "MM@11", Rol = RolType.Manager },
            new Employee
                { Id = 2, Code = "MM12", Name = "Juan", Email = "user2@company.com", Password = "MM@12", Rol = RolType.Seller },
            new Employee
                { Id = 3, Code = "MM13", Name = "Pedro", Email = "user3@company.com", Password = "MM@13", Rol = RolType.Delivery },
            new Employee
                { Id = 4, Code = "MM14", Name = "Alberto", Email = "user4@company.com", Password = "MM@14", Rol = RolType.Deliverer },
            new Employee
                { Id = 5, Code = "MM15", Name = "Enrique", Email = "user5@company.com", Password = "MM@15", Rol = RolType.Deliverer }
        );
    }
}