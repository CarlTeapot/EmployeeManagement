using EmployeeManagement.DTO;
using EmployeeManagement.Model;

namespace EmployeeManagement.Services;

public interface IEmployeeService
{
    void RegisterEmployee(Employee employee);

    void DeleteEmployee(long Id);

    EmployeeDTO GetEmployeeByEmail(string email);
}