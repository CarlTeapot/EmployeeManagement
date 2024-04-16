using EmployeeManagement.DTO;
using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controller;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ICompanyService service, IEmployeeService employeeService )
    {
        _employeeService = employeeService;
        _companyService = service; 
    }

    [HttpGet("{email}")]
    public IActionResult GetEmployeeByEmail(string email)
    {
        var emp = _employeeService.GetEmployeeByEmail(email);
        return Ok(emp);
    }
    [HttpPost("register-employee")]
    public IActionResult RegisterEmployee(RegistrationDTO employeeRegistrationDto)
    {
      var employee = new Employee()
      {
          Email = employeeRegistrationDto.Email,
          Password = employeeRegistrationDto.Password,
          role = Role.Employee,
          isActive = true
      };
     
      _employeeService.RegisterEmployee(employee);
      _companyService.AddEmployeeToCompany(employee.Id,employee.CompanyId);
        return Ok();
    }
   
}