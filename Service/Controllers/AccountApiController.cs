using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Core.Domain.Accounts;
using Core.Interfaces;
using Core.Interfaces.Repositories.Business;
using Infrastructure.AutoMapper;
using Infrastructure.Serialization.JsonContractResolvers;
using Service.Dtos.Account;

namespace Service.Controllers
{
    [RoutePrefix("api/accounts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountApiController : ApiController
    {
        private readonly IAccountRepository<Account> _repository;
        private readonly IComplete _unitOfWork;

        public AccountApiController(IUnitOfWork unitOfWork)
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
            var accounts = await _repository.GetAll()
                .Include(a => a.Partner)
                .ToListAsync();

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
        public async Task<IHttpActionResult> UpdateAsync(int id, AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> CreateAsync(AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
