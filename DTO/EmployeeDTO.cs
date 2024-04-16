namespace EmployeeManagement.DTO;

public record EmployeeDTO
{
      public string Email { get; set; } = null!;

     public string CompanyName { get; set; } = null!;
     
     public long Salary { get; set; } = 0;
     
    
}