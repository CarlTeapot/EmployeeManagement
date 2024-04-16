using EmployeeManagement.Model;

namespace EmployeeManagement.Repository;

public class CompanyRepository : ICompanyRepository
{
    private readonly EmployeeDBContext _dbContext;
    public CompanyRepository(EmployeeDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public long Add(Company company)
    {
        _dbContext.Companies.Add(company);
        _dbContext.SaveChanges();
        return company.Id;
    }

    public void Delete(Company? company)
    {
        if (company != null)
        {
            company.IsActive = false;
            
        }
    }

    public Company? GetById(long id)
    {
        return _dbContext.Companies.FirstOrDefault(u => u.Id == id);
    }

    public Company? Update(Company company)
    {
        
            _dbContext.Companies.Update(company);
            _dbContext.SaveChanges();
            return company;
    }

    public Company? GetByName(string companyName)
    {
        return _dbContext.Companies.FirstOrDefault(u => u.Name == companyName);
    }

    public List<Employee>? GetEmployeesByCompanyId(long id) 
    {
        return _dbContext.Employees.Where(u => u.CompanyId == id).ToList();
    }
}