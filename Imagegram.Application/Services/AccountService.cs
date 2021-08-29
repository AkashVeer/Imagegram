using AutoMapper;
using Imagegram.Database.Repositories;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Accounts;
using Imagegram.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDomainModel> AddAccount(AccountCreateDomainModel accountRequest)
        {
            try
            {
                var account = await _accountRepository.GetAccountByName(accountRequest.Name);
                if (account is not null)
                    throw new HandleException("Account already exists with given name");

                var request = _mapper.Map<Account>(accountRequest);
                var response = _mapper.Map<AccountDomainModel>(await _accountRepository.AddAccount(request));
                return response;
            }
            catch(Exception ex)
            {
                throw new HandleException("Exception in AddAccount method : "+ex.Message);
            }
        }

        public async Task DeleteAccount(Guid id)
        {
            try
            {
                var account = await _accountRepository.GetAccount(id);
                if (account is not null)
                {
                    await _accountRepository.DeleteAccount(account);
                }
            }
            catch(Exception ex)
            {
                throw new HandleException("Exception in DeleteAccount method : " + ex.Message);
            }
        }
    }
}
