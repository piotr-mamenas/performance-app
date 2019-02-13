using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Accounts;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.Extensions;
using Infrastructure.Serialization.JsonContractResolvers;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Account;
using Service.Filters;

namespace Service.Controllers
{
    [RoutePrefix("api/accounts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountApiController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountApiController(IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            ILogger logger, 
            ISessionService sessionService)
            : base(logger, unitOfWork, sessionService)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new AccountContractResolver();

            _accountRepository = accountRepository;
        }

        [ResponseType(typeof(ICollection<AccountDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var accounts = await _accountRepository.GetAllWithPartnerAsync();

            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts.Map<ICollection<AccountDto>>());
        }

        [ResponseType(typeof(AccountDto))]
        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var account = await _accountRepository.GetAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            return Ok(account.Map<AccountDto>());
        }

        [HttpPut, Route("{id}")]
        [ValidateModel]
        public async Task<IHttpActionResult> UpdateAsync(int id, AccountDto account)
        {
            var accountInDb = await _accountRepository.GetAsync(id);

            if (accountInDb == null)
            {
                return NotFound();
            }

            _accountRepository.Add(account.Map<Account>());

            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(AccountDto account)
        {
            _accountRepository.Add(account.Map<Account>());

            await UnitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + account.Id), account);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var account = await _accountRepository.GetAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            _accountRepository.Remove(account);

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
