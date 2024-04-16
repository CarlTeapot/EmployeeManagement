using EmployeeManagement.Repository;
using EmployeeManagement.DTO;
using EmployeeManagement.Model;
using EmployeeManagement.Repository.Impl;

namespace EmployeeManagement.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
 
    public EmployeeService(IUnitOfWork unit)
    {
        _unitOfWork = unit;
    }

    public void RegisterEmployee(Employee employee)
    {
        var emp = _unitOfWork.EmployeeRepository.GetByEmail(employee.Email);
        if (emp != null)
            return;

        _unitOfWork.BeginTransaction();
        _unitOfWork.EmployeeRepository.Add(employee);
        _unitOfWork.CommitTransaction();
        _unitOfWork.Save();
        
    }

    public void DeleteEmployee(long id)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var emp = _unitOfWork.EmployeeRepository.GetById(id);
            _unitOfWork.EmployeeRepository.Delete(emp);
            _unitOfWork.CommitTransaction();
            _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            _unitOfWork.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }

    public EmployeeDTO? GetEmployeeByEmail(string email)
    {
        var empl = _unitOfWork.EmployeeRepository.GetByEmail(email);

        if (empl == null || empl.isActive == false)
        {
            return null;
        }
        else
        {
            EmployeeDTO dto = new EmployeeDTO()
            {
                CompanyName = _unitOfWork.CompanyRepository.GetById(empl.CompanyId).Name,
                Email = empl.Email
            };
            return dto;
        }
        
        
    }
}