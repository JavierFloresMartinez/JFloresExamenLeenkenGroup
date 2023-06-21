using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EstadoController : ApiController
    {
        // GET: api/Estado
        [HttpGet]
        [Route("api/Estado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }
    }
}