using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBookAPI.Repositories;
using RecipeBookAPI.Repositories.Interfaces;
using RecipeBookAPI.Data.Models;
using Newtonsoft.Json;

namespace RecipeBookAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]s")]
    public class ReviewController : BaseApiController
    {
        private IBaseRepository<Review> reviewsRepository;
        // GET api/values
        #region Constuctor
        
        public ReviewController(IBaseRepository<Review> reviews)
        {
            this.reviewsRepository = reviews;
        }
        #endregion

        #region Actions 

        
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = reviewsRepository.GetAll();

            return new JsonResult(
               reviews,
               JsonSettings);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = reviewsRepository.GetById(id);

            return new JsonResult(
               review,
               JsonSettings);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}