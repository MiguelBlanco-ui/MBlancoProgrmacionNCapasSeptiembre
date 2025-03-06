using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_webAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [Route("api/Usuario")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllLinq();
            if (result.Correct) {
                return Ok(result);
            }
            else { 
                return NotFound();
            }
           
        }

        // GET: api/Usuario/5
        [Route("api/Usuario/{IdUsuario}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEFLinq(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("api/Usuario")]
        [HttpPost]
        // POST: api/Usuario
        public IHttpActionResult Add([FromBody]ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEFLinq(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return NotFound();
            }
        }

        [Route("api/Usuario")]
        [HttpPut]
        // PUT: api/Usuario/5
        public IHttpActionResult Update([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEFLinq(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Usuario/5
        [Route("api/Usuario/{IdUsuario}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEFLinq(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
