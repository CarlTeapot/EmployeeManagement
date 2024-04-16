namespace EmployeeManagement.DTO;

public record RegistrationDTO
{
    public long CompanyId { get;  set;} = 0;
   
    public string Password =  null!;
 
    public string Email { get; set; } = null!;
    
}