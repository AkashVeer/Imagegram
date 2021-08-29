using AutoMapper;
using Imagegram.Application.Services;
using Imagegram.Model.Dtos.Accounts;
using Imagegram.Model.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountCreateViewModel request)
        {
            var account = _mapper.Map<AccountCreateDomainModel>(request);
            var response = _mapper.Map<AccountViewModel>(await _accountService.AddAccount(account));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _accountService.DeleteAccount(id);
            return Ok("Account deleted");
        }
    }
}
