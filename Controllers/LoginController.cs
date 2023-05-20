using EcommerceFinal.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceFinal.Controllers
{
    public class LoginController : ApiController
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

        // POST api/<controller>[FromBody] JObject json
        [HttpPost]
        //public IHttpActionResult Login([FromBody] User userLogin)
        //{
        //    var user = db.User.FirstOrDefault(u => u.email == userLogin.email && u.password == userLogin.password);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}
        public IHttpActionResult Login(User userLogin)
        {
            try
            {
                var user = db.User
                         .Where(u => u.email == userLogin.email && u.password == userLogin.password)
                         .Select(u => new {
                             u.ID_user,
                             u.email,
                             u.name,
                             u.surname,
                             //u.password,
                             u.address,
                             u.country,
                             u.phone
                         })
                         .FirstOrDefault();

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }catch(Exception ex)
            {
                return InternalServerError(ex);

            }

        }





        //}

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