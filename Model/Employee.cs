using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model;

public class Employee {
    
    [Column("Id")]
    public long Id { get; }

    [Required] 
    public Company Company { get; set; } = null!;
    [ForeignKey("CompanyId")]
    [Required]
    public long CompanyId { get;  set;} = 0;
    [Required]
    [MaxLength(64)]
    public string Password =  null!;
    
    [Required]
    [MaxLength(64)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required] 
    public Role role { get;  set; }= Role.Employee; 
    public bool isActive { get; set; } = true;
    
}