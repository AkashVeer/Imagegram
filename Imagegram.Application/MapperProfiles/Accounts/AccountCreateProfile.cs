using AutoMapper;
using Imagegram.Domain;
using Imagegram.Model.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.MapperProfiles.Accounts
{
    public class AccountCreateProfile : Profile
    {
        public AccountCreateProfile()
        {
            CreateMap<AccountCreateDomainModel, Account>();
        }
    }
}
