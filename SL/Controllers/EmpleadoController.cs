using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        //http://localhost:59638/
        // GET: api/Empleaado
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [HttpGet]
        [Route("api/Empleado/GetById/{idEmpleado}")]
        public IHttpActionResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Empleado/Add")]
        // POST: api/Empleado
        public IHttpActionResult Post([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Empleado/Update")]
        // PUT: api/Empleado/5
        public IHttpActionResult Put([FromBody] ML.Empleado empleado)
        {
            var result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        [HttpGet]
        [Route("api/Empleado/Delete/{idEmpleado}")]
        // GET: api/Empleado/Delete
        public IHttpActionResult Delete(int idEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(idEmpleado);

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