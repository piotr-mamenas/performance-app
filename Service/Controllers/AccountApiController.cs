using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Accounts;
using Core.Domain.Identity;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Infrastructure.Services;
using Ninject.Extensions.Logging;
using Service.Dtos.Account;
using Service.Filters;
using Service.Helpers;

namespace Service.Controllers
{
    [RoutePrefix("api/accounts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountApiController : BaseApiController
    {
        private readonly IAccountRepository _repository;
        private readonly IComplete _unitOfWork;

        public AccountApiController(IUnitOfWork unitOfWork, ILogger logger, ISessionService sessionService)
            : base(logger, sessionService)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new AccountContractResolver();

            _unitOfWork = (IComplete)unitOfWork;
            _repository = unitOfWork.Accounts;
        }

        [ResponseType(typeof(ICollection<AccountDto>))]
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var accounts = await _repository.GetAllWithPartnerAsync();

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
            var account = await _repository.GetAsync(id);

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
            var accountInDb = await _repository.GetAsync(id);

            if (accountInDb == null)
            {
                return NotFound();
            }

            _repository.Add(account.Map<Account>());

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> CreateAsync(AccountDto account)
        {
            _repository.Add(account.Map<Account>());

            await _unitOfWork.CompleteAsync();

            return Created(new Uri(Request.RequestUri + "/" + account.Id), account);
        }

        [HttpDelete, Route("{id}/delete")]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var account = await _repository.GetAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            _repository.Remove(account);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
