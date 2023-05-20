using EcommerceFinal.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceFinal.Controllers
{
    public class OrderController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult AgregarProductos([FromBody] JObject json)
        {
            try
            {
                JArray productosJson = (JArray)json["productos"];
                var order = new Order();
                foreach (JObject productoJson in productosJson)
                {
                    order.ID_user = (int)productoJson["ID_user"];
                    order.ID_product = (int)productoJson["Id"];
                    order.ord_amount = (int)productoJson["cantidad"];
                    order.ord_price = (decimal)productoJson["Precio"];
                    order.ord_total = (decimal)productoJson["ord_total"];

                    // Aquí puedes guardar el producto en la base de datos

                    db.Order.Add(order);
                    db.SaveChanges();
                    return Ok();
                }
                return Ok();

            }
            catch  (Exception ex)
            {
                // Aquí puedes manejar la excepción y devolver una respuesta de error
                return InternalServerError(ex);
            }


        }




        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}