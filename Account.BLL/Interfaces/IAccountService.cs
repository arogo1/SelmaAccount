using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain;

namespace Account.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAll();

        AccountDTO GetById(int accountId);

        void Create(AccountDTO account);

        void Update(AccountDTO account);

        void Delete(int accountId);

        IEnumerable<AccountDTO> Search(AccountDTO account);
    }
}
