using Imagegram.Model.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public interface IAccountService
    {
        Task<AccountDomainModel> AddAccount(AccountCreateDomainModel accountRequest);
        Task DeleteAccount(Guid id);
    }
}
