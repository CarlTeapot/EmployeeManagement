using EmployeeManagement.Model;

namespace EmployeeManagement.Services;

public interface ICompanyService
{
    public void RegisterCompany(Company company);
    
    public void AddEmployeeToCompany(long employeeId, long companyId);
    
}