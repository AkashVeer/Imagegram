using AutoMapper;
using Imagegram.Model.Dtos.Accounts;
using Imagegram.Model.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.MapperProfiles.Accounts
{
    public class AccountCreateProfile : Profile
    {
        public AccountCreateProfile()
        {
            CreateMap<AccountCreateViewModel, AccountCreateDomainModel>();
        }
    }
}
