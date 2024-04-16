namespace EmployeeManagement.Repository;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    void Save();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
