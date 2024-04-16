using EmployeeManagement.DTO;
using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controller;

[ApiController]
[Route("Employees")]
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
         return Ok();
    }
    [HttpPost("register-employee")]
    public IActionResult RegisterEmployee(RegistrationDTO employeeRegistrationDto)
    {
      // //  var employee = _mapper.Map<Employee>(employeeRegistrationDto);
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
    [HttpPost("register-company")]

    public IActionResult RegisterCompany(Company company)
    {
        _companyService.RegisterCompany(company);
        return Ok(company.Id);
        return Ok();
    }
}