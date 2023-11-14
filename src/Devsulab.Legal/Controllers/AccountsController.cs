using System;
using Devsulab.Common;
using Devsulab.Legal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Devsulab.Legal.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IRepository<Account> accountsRepository;

        public AccountsController(IRepository<Account> accountsRepository)
        {
            this.accountsRepository = accountsRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<Account>> GetAsync()
        {
            var accounts = new List<Account>();
            accounts.Add(new Account()
            {
                Name = "TestInMemory",
                BillingState = "FL"
            });
            return Ok(accounts);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetByIdAsync(Guid id)
        {
            var account = await accountsRepository.GetAsync(id);

            if (String.IsNullOrEmpty(account.Name))
            {
                return NotFound();
            }

            return account;
        }
        
    }
}

