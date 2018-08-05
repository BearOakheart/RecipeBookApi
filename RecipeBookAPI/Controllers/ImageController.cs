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
    public class ImageController : BaseApiController
    {
        private IImageRepository repository;

        #region Constructor
        
        public ImageController(IImageRepository images) {
            this.repository = images;
        }
        #endregion

        #region Actions 
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var images = repository.GetAll();

            return new JsonResult(
               images,
               JsonSettings);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var image = repository.GetById(id);

            return new JsonResult(
               image,
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