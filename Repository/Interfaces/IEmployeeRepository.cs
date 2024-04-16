using EmployeeManagement.Model;

namespace EmployeeManagement.Repository;

public interface IEmployeeRepository 
{    
    public long Add(Employee employee);
    public void Delete(Employee? entity);
    public Employee? GetById(long id);
    public int Update(Employee entity);
    public Employee? GetByEmail(string email);
}