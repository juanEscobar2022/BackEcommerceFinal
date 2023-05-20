using EcommerceFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceFinal.Controllers
{
    public class CartController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();

        // GET api/<controller>
        private List<Cart> cartItems = new List<Cart>();



        // POST api/<controller>
        public IHttpActionResult AddToCart([FromBody] Cart cartItemDto)
        {
            var product = db.Product.FirstOrDefault(p => p.ID_product == cartItemDto.ID_product);
            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Cart
            {
                ID_product = cartItemDto.ID_product,
                ID_user = cartItemDto.ID_user,
                Cant = cartItemDto.Cant,
                total = product.pro_price * cartItemDto.Cant
            };

            cartItems.Add(cartItem);

            return Ok();
        }

        public IEnumerable<Cart> GetCart()
        {
            return cartItems;
        }

        // PUT api/<controller>/5
        public IHttpActionResult UpdateCart(int cartItemId, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(c => c.ID_cart == cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }
            var product = db.Product.FirstOrDefault(p => p.ID_product == cartItem.ID_product);
            if (product == null)
            {
                return NotFound();
            }
            cartItem.Cant = quantity;
            cartItem.total = product.pro_price * quantity;
            return Ok();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = cartItems.FirstOrDefault(c => c.ID_cart == cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }
            cartItems.Remove(cartItem);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult ClearCart()
        {
            cartItems.Clear();
            return Ok();
        }
    }
}