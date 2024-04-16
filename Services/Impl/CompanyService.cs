using EmployeeManagement.Repository;
using EmployeeManagement.Model;
using EmployeeManagement.Repository.Impl;

namespace EmployeeManagement.Services.Impl;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CompanyService(IUnitOfWork work)
    {
        _unitOfWork = work;
    }
    public long RegisterCompany(Company company)
    {
        var comp = _unitOfWork.CompanyRepository.GetByName(company.Name);
        if (comp != null && comp.IsActive)
            return -1;
        
        _unitOfWork.BeginTransaction();
        _unitOfWork.CompanyRepository.Add(company);
        _unitOfWork.CommitTransaction();
        _unitOfWork.Save();
        return _unitOfWork.CompanyRepository.GetByName(company.Name).Id;
    }
    public void DeleteCompany(long companyId)
    {
        var comp = _unitOfWork.CompanyRepository.GetById(companyId);
        if (comp != null)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.CompanyRepository.Delete(comp);
            _unitOfWork.CommitTransaction();
            _unitOfWork.Save();
        }
    }

    public long AddEmployeeToCompany(long employeeId, long companyId)
    {
        var comp = _unitOfWork.CompanyRepository.GetById(companyId);
        var emp = _unitOfWork.EmployeeRepository.GetById(employeeId);
        
        if (comp == null || emp == null)
            return -1;
        _unitOfWork.BeginTransaction();
        comp.Employees.Add(emp);
        _unitOfWork.CompanyRepository.Update(comp);
        _unitOfWork.CommitTransaction();
        _unitOfWork.Save();
        return emp.Id;
    }
    
}