using ACME.Entity;
using ACMEBank.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ACMEBank.Controllers
{
    public class AccountController : ACMEControllerBase
    {
        IRepository<Account> repo = new AccountRepository();

        [Route("api/accounts/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var answer = repo.Get(id);
            return OkOrNotFound(answer);
        }

        [Route("api/customers/{customerid:int}/accounts")]
        [HttpGet]
        public IHttpActionResult GetAccountsByCustomer(int customerid)
        {
            var answer = repo.Get().Where(x => x.CustomerId == customerid);
            return OkOrNotFound(answer);
        }

        [HttpGet]
        [Route("api/accounts")]
        public IHttpActionResult Get()
        {
            var answer = repo.Get();
            return OkOrNotFound(answer);
        }

        [HttpPost]
        [Route("api/customers/{customerid}/accounts")]
        public IHttpActionResult Create([FromBody]Account account, int customerid)
        {
            if (customerid == 0 || account.CustomerId == 0 || string.IsNullOrEmpty((string)account.AccountType) || string.IsNullOrEmpty((string)account.Status))
            {
                return base.BadRequest();
            }
            var accountExists = repo.Get().Any((Func<Account, bool>)(c => 
                                            (bool)(string.Equals(c.AccountType, (string)account.AccountType, StringComparison.OrdinalIgnoreCase)
                                            && c.CustomerId == account.CustomerId)));
            if (accountExists)
            {
                return Conflict();
            }
            var answer = repo.Create((Account)account);
            return Created(Request.RequestUri, answer);
        }

        [HttpPut]
        [Route("api/accounts/{id:int}")]
        public IHttpActionResult Save([FromBody]Account account)
        {
            if (account == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            if (account.CustomerId == 0 || string.IsNullOrEmpty(account.AccountType) || string.IsNullOrEmpty(account.Status))
            {
                return BadRequest();
            }
            var answer = repo.Get(account.Id);
            if (answer == null)
            {
                return NotFound();
            }
            var accountExists = repo.Get().Any(c => string.Equals(c.AccountType, account.AccountType, StringComparison.OrdinalIgnoreCase)
                                            && c.CustomerId == account.CustomerId);
            if (accountExists)
            {
                return Conflict();
            }
            answer = repo.Create(account);
            return Ok(answer);
        }

        [HttpDelete]
        [Route("api/accounts/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var answer = repo.Get(id);
            if (answer == null)
            {
                return NotFound();
            }
            repo.Delete(id);
            return Ok(answer);
        }
    }
}
