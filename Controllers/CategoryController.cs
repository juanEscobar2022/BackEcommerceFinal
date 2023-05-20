using EcommerceFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceFinal.Controllers
{
    public class CategoryController : ApiController
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET api/<controller>
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                var categories = db.Category
                     .ToList() // carga los registros en memoria
                     .Select(c => new {
                         Id = c.ID_category,
                         Name = c.cat_name,
                         Description = c.cat_description,
                         Image = Convert.ToBase64String(c.image)
                     })
                     .ToList();

                if (categories.Any())
                {
                    return Ok(categories);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }






        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult CreateCategory(Category categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var category = new Category
                {
                    cat_name = categoryDto.cat_name,
                    cat_description = categoryDto.cat_description,
                    image = categoryDto.image
                };

                db.Category.Add(category);
                db.SaveChanges();

                categoryDto.ID_category = category.ID_category;

                return Created(new Uri(Request.RequestUri + "/" + categoryDto.ID_category), categoryDto);
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var categoryInDb = db.Category.SingleOrDefault(c => c.ID_category == id);

                if (categoryInDb == null)
                    return NotFound();

                categoryInDb.cat_name = categoryDto.cat_name;
                categoryInDb.cat_description = categoryDto.cat_description;
                categoryInDb.image = categoryDto.image;

                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE api/category/5
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = db.Category.SingleOrDefault(c => c.ID_category == id);

            if (categoryInDb == null)
                return NotFound();

            db.Category.Remove(categoryInDb);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}