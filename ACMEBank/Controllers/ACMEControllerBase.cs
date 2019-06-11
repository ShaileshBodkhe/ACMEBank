using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ACMEBank.Controllers
{
    public class ACMEControllerBase : ApiController
    {
        protected IHttpActionResult OkOrNotFound<TEntity>(TEntity entity)
        {
            if(entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
