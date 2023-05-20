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
    public class UserController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET api/<controller>
        public IHttpActionResult GetUsers()
        {
            var users = db.User.ToList();
            if (users.Any())
            {
                return Ok(users);

            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult GetUserById(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<controller>
        public IHttpActionResult CreateUser(User user )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);
            try
            {
                db.SaveChanges();

            }
            catch (DbUpdateException)
            {
                if (user.ID_user == 0)
                {
                    return Conflict();

                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.ID_user }, user);
        }

        // PUT api/<controller>/5
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID_user)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            db.SaveChanges();
          
            return Ok();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }
       

    }
}