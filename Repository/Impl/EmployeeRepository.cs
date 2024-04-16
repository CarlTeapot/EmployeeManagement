using EmployeeManagement.Repository;
using EmployeeManagement.Model;

public class EmployeeRepository : IEmployeeRepository
{
    protected readonly EmployeeDBContext _dbcontext;
    public EmployeeRepository(EmployeeDBContext context)
    {
        _dbcontext = context;
    }

    public long Add(Employee employee)
    {
        _dbcontext.Employees.Add(employee);
        _dbcontext.SaveChanges();
        return  employee.Id;
    }

    public void Delete(Employee? entity)
    {
        if (entity != null)
        {
            _dbcontext.Employees.Remove(entity);
        }
            
    }

    public Employee? GetById(long id)
    {
        return _dbcontext.Employees.FirstOrDefault(u => u.Id == id);
    }
    public int Update(Employee entity)
    {
        throw new NotImplementedException();
    }
    
    public Employee? GetByEmail(string email)
    {
        return _dbcontext.Employees.FirstOrDefault(u => u.Email == email);
    }
}