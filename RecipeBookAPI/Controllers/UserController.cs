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
    public class UserController : BaseApiController
    {
        private IUserRepository repository;

        #region Constructor
        public UserController(IUserRepository users)
        {
            this.repository = users;
        }
        #endregion
        
        #region Actions 
        [HttpGet]
        public IActionResult Get()
        {
            var user = repository.GetAll();

            return new JsonResult(
               user,
               JsonSettings);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound(new { Error = String.Format("User ID {0} has not been found", id) });
            }

            return new JsonResult(
               user,
               JsonSettings);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = repository.GetById(id);

            // how to determinate if user delete is true. (maybe change repository method to return boolean on success) 
            repository.Delete(user);

            return new NoContentResult();

        }
        #endregion
    }
}