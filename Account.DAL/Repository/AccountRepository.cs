using Account.DAL.Interface;
using Account.Domain;

namespace Account.DAL.Repository
{
    public class AccountRepository : GenericRepository<AccountDTO>, IAccountRepository
    {
        public AccountRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
