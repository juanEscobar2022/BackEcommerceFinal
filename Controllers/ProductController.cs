using EcommerceFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceFinal.Controllers
{
    public class ProductController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET api/<controller>

        public IHttpActionResult GetProductosConCategorias()
        {
            try
            {
                var productos = db.Product
                      .Include(p => p.Category)
                      .ToList()
                      .Select(p => new {
                          Id = p.ID_product,
                          Nombre = p.pro_name,
                          Descripcion = p.pro_description,
                          Precio = p.pro_price,
                          Categoria = p.Category.cat_name,
                          Imagen = Convert.ToBase64String(p.image)
                      })
                      .ToList();


                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }




        // GET api/<controller>/5
        public IHttpActionResult GetProductosConCategorias(int id)
        {
            try
            {
                var producto = db.Product
                      .Include(p => p.Category)
                       .ToList()
                      .Where(p => p.ID_product == id)
                      .Select(p => new {
                          Id = p.ID_product,
                          Nombre = p.pro_name,
                          Descripcion = p.pro_description,
                          Precio = p.pro_price,
                          Categoria = p.Category.cat_name,
                          Imagen = Convert.ToBase64String(p.image)
                      })
                      .FirstOrDefault();

                if (producto == null)
                {
                    return NotFound();
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // POST api/<controller>
        public IHttpActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            try
            {
                db.SaveChanges();

            }
            catch (DbUpdateException)
            {
                if (product.ID_product == 0)
                {
                    return Conflict();

                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.ID_product }, product);
        }

        // PUT api/<controller>/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productDTO = db.Product.SingleOrDefault(c => c.ID_product == id);

            if (productDTO == null)
                return NotFound();

            productDTO.pro_name = product.pro_name;
            productDTO.pro_description = product.pro_description;
            productDTO.pro_price = product.pro_price;
            productDTO.pro_account = product.pro_account;
            productDTO.ID_category = product.ID_category;
            productDTO.pro_dispo = product.pro_dispo;
            productDTO.image = product.image;

            db.SaveChanges();

            return Ok();
        }


        // DELETE api/<controller>/5
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
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