using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Produto/5
        public IEnumerable<Produto> Get(int Id)
        {
            return Negocio.N_Produto.SelectAllByCriator(Id);
        }

        // POST: api/Produto
        public IHttpActionResult Post([FromBody]Produto Produto)
        {
            if (Produto == null)
                return NotFound();

            try
            {
                Negocio.N_Produto.Insert(Produto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
