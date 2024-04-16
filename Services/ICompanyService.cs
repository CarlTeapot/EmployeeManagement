using EmployeeManagement.Model;

namespace EmployeeManagement.Services;

public interface ICompanyService
{
    public long RegisterCompany(Company company);
    
    public long AddEmployeeToCompany(long employeeId, long companyId);

    public void DeleteCompany(long id);
}