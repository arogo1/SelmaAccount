using Account.DAL.Interface;
using Account.DAL.Repository;

namespace Account.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
        }

        public IAccountRepository Accounts { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
