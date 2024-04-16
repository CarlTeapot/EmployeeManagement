using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Repository;

public class EmployeeDBContext : DbContext
{
    private readonly IConfiguration Configuration;

    public EmployeeDBContext(
        IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        GenerateEmployeEntity(modelBuilder);
        GenerateCompanyEntity(modelBuilder);

    }

    private void GenerateEmployeEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Employee>()
            .HasIndex(u => u.Email);
        modelBuilder.Entity<Employee>()
            .HasIndex(u => u.isActive);

        modelBuilder.Entity<Employee>().HasIndex(u => u.Password);
        
        modelBuilder.Entity<Employee>().Property(u => u.role).HasConversion<string>();;
    }

    private void GenerateCompanyEntity(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Company>()
            .HasIndex(u => u.IsActive);
        
        modelBuilder.Entity<Company>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Employees) // Company has many employees
            .WithOne(e => e.Company)   // Employee belongs to one company
            .HasForeignKey(e => e.CompanyId); // Foreign key
        
        modelBuilder.Entity<Company>()
            .HasIndex(u => u.Name);
        modelBuilder.Entity<Company>().HasIndex(u => u.CeoEmail);

    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;


}
