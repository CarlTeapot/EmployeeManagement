using EmployeeManagement.Model;

namespace EmployeeManagement.Repository;

public interface ICompanyRepository
{
    public long Add(Company company);
    public void Delete(Company? company);
    public Company? GetById(long id);
    public Company? Update(Company company);
    public Company? GetByName(string companyName);
    public List<Employee>? GetEmployeesByCompanyId(long id);   
}