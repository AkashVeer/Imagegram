using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ImagegramDbContext _dbContext;
        public AccountRepository(ImagegramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> AddAccount(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return await GetAccountByName(account.Name);
        }

        public async Task DeleteAccount(Account account)
        {
            _dbContext.Accounts.Remove(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account> GetAccount(Guid id)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Account> GetAccountByName(string name)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
            return await GetAccount(account.Id);
        }
    }
}
