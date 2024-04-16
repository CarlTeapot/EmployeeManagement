using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controller;

[ApiController]
[Route("company")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IEmployeeService _employeeService;
    
    public CompanyController(ICompanyService service, IEmployeeService employeeService )
    {
        _employeeService = employeeService;
        _companyService = service; 
    }
    
    [HttpPost("register-company")]
    public IActionResult RegisterCompany(Company company)
    {
        var id = _companyService.RegisterCompany(company);

        return Ok(id);
    }
    [HttpDelete("delete/{companyId}")]
    public IActionResult DeleteCompany(long companyId)
    {
        _companyService.DeleteCompany(companyId);
        return Ok("Success");
    }

    public IActionResult AddEmployeeToCompany(long employeeId, long companyId)
    {
        _companyService.AddEmployeeToCompany(employeeId, companyId);
        return Ok(employeeId);
    }
}