using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Account.BLL.Exceptions;
using Account.BLL.Interfaces;
using Account.DAL.Interface;
using Account.Domain;

namespace Account.BLL
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(AccountDTO account)
        {
            /*if(account.FirstName == "Arnes")
            {
                throw new MyException("Ime Arnes nije dozvoljeno");
            }*/
            _unitOfWork.Accounts.Insert(account);
        }

        public void Delete(int accountId)
        {
            _unitOfWork.Accounts.Delete(accountId);
        }

        public async Task<IEnumerable<AccountDTO>> GetAll()
        {
            return await _unitOfWork.Accounts.GetAll();
        }

        public AccountDTO GetById(int accountId)
        {
            return _unitOfWork.Accounts.GetById(accountId);
        }

        public IEnumerable<AccountDTO> Search(AccountDTO accoutn)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AccountDTO account)
        {
            _unitOfWork.Accounts.Update(account);
        }

        private void HashPassword(string password)
        {
            
        }
    }
}
