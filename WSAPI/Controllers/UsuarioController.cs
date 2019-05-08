using Modelo;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            return N_Usuario.GetAll();
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return new NotImplementedException().ToString();
        }
        [HttpPost]
        // POST: api/Usuario
        public HttpResponseMessage Post([FromBody]Usuario Usuario)
        {
            try
            {
                N_Usuario.Insert(Usuario);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
