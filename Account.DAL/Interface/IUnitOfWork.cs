using System;
namespace Account.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        int Complete();
    }
}
