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
    public void RegisterCompany(Company company)
    {
        var comp = _unitOfWork.CompanyRepository.GetByName(company.Name);
        if (comp != null)
            return;
        
        _unitOfWork.BeginTransaction();
        _unitOfWork.CompanyRepository.Add(company);
        _unitOfWork.CommitTransaction();
        _unitOfWork.Save();
      
    
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

    public void AddEmployeeToCompany(long employeeId, long companyId)
    {
        var comp = _unitOfWork.CompanyRepository.GetById(companyId);
        var emp = _unitOfWork.EmployeeRepository.GetById(employeeId);
        
        if (comp == null || emp == null)
            return;
        _unitOfWork.BeginTransaction();
        comp.Employees.Add(emp);
        _unitOfWork.CompanyRepository.Update(comp);
        _unitOfWork.CommitTransaction();
        _unitOfWork.Save();
    }
    
}