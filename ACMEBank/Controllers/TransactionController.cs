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
    public class TransactionController : ACMEControllerBase
    {
        IRepository<Transaction> repo = new TransactionRepository();

        [Route("api/transactions/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var answer = repo.Get(id);
            return OkOrNotFound(answer);
        }

        [HttpGet]
        [Route("api/accounts/{accountId:int}/transactions")]
        public IHttpActionResult GetTransactionByAccountId(int accountId)
        {
            var answer = repo.Get().Where(x=>x.AccountId == accountId);
            return OkOrNotFound(answer);
        }

        [HttpGet]
        [Route("api/transactions")]
        public IHttpActionResult Get()
        {
            var answer = repo.Get();
            return OkOrNotFound(answer);
        }

        [HttpPost]
        //[Route("api/transactions")]
        [Route("api/accounts/{accountId:int}/transactions")]
        public IHttpActionResult Create([FromBody]Transaction transaction, int accountId)
        {
            if(accountId == 0 || transaction.AccountId == 0|| string.IsNullOrEmpty(transaction.Type) || transaction.Amount == 0)
            {
                return BadRequest();
            }
            //Should check for possible conflict

            var answer = repo.Create(transaction);
            return Created(Request.RequestUri, answer);
        }

        [HttpPut]
        [Route("api/transactions/{id:int}")]
        public IHttpActionResult Save([FromBody]Transaction transaction)
        {
            if (transaction == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            var answer = repo.Get(transaction.Id);
            if (answer == null)
            {
                return NotFound();
            }
            //Should check for possible conflict

            answer = repo.Create(transaction);
            return Ok(answer);
        }

        [HttpDelete]
        [Route("api/transactions/{id:int}")]
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
