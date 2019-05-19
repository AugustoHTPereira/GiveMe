using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Produto/5
        public IEnumerable<Produto> Get(int usuarioid)
        {
            return Negocio.N_Produto.SelectAllByCriator(usuarioid);
        }

        // POST: api/Produto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produto/5
        public void Delete(int id)
        {
        }
    }
}
