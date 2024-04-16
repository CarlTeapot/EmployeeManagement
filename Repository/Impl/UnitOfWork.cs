
namespace EmployeeManagement.Repository.Impl;

public class UnitOfWork : IUnitOfWork
{
        private readonly EmployeeDBContext _dbContext;

        public UnitOfWork(EmployeeDBContext dbContext, IEmployeeRepository repository, ICompanyRepository repository2)
        {
            _dbContext = dbContext;
            EmployeeRepository = repository;
            CompanyRepository = repository2;
        }

        public IEmployeeRepository EmployeeRepository { get; }
        public ICompanyRepository CompanyRepository { get; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
}