using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(Guid id);
        Task<Account> AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task DeleteAccount(Account account);
        Task<Account> GetAccountByName(string name);
    }
}
