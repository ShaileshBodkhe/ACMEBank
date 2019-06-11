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
    public class CustomerController : ACMEControllerBase
    {
        Repository<Customer> repo = new CustomerRepository();

        [Route("api/customers/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var answer = repo.Get(id);
            return OkOrNotFound(answer);
        }

        [HttpGet]
        [Route("api/customers")]
        public IHttpActionResult Get()
        {
            var answer = repo.Get();
            return OkOrNotFound(answer);
        }

        [HttpPost]
        [Route("api/customers")]
        public IHttpActionResult Create([FromBody]Customer customer)
        {
            var emailExist = repo.Get().Any(c => string.Equals(c.Email, customer.Email, StringComparison.OrdinalIgnoreCase));
            if (emailExist)
            {
                return Conflict();
            }
            var answer = repo.Create(customer);
            return Created(Request.RequestUri, answer);
        }

        [HttpPut]
        [Route("api/customers/{id:int}")]
        public IHttpActionResult Save([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            var answer = repo.Get(customer.Id);
            if (answer == null)
            {
                return NotFound();
            }

            var emailExist = repo.Get().Any(c => string.Equals(c.Email, customer.Email, StringComparison.OrdinalIgnoreCase)
                                            && c.Id != customer.Id);
            if (emailExist)
            {
                return Conflict();
            }
            answer = repo.Create(customer);
            return Ok(answer);
        }

        [HttpDelete]
        [Route("api/customers/{id:int}")]
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
