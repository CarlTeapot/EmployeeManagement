using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Model;

public class Company
{
    [Column("Id")]
    public long Id { get; }

    [Required][MaxLength(50)] public string Name { get; set; } = null!;
    
    public List<Employee> Employees { get; set; } = new List<Employee>();

    [Required][MaxLength(50)] public string CeoEmail { get; set; }= null!;
    
    public bool IsActive { get; set; } = true;
}