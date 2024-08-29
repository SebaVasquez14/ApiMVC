using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using API.Models;
using MyApiProject.Models;

namespace MyApiProject.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductsController : ApiController
    {
        private BD_TodoAppEntities db = new BD_TodoAppEntities();

        // GET: api/Products
        [Route("")]
        public IEnumerable<Product> GetProducts()
        {
            var productos = db.Product.ToList();
            return productos;
        }

        // GET: api/Products/5
        [Route("{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Product.Add(product);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingProduct = db.Product.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Products/5
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }
    }
}
