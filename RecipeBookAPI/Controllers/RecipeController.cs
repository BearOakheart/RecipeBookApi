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
using RecipeBookAPI.ViewModels;
using Mapster;

namespace RecipeBookAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]s")]
    public class RecipeController : BaseApiController
    {
        private IRecipeRepository repository;

        #region Constuctor
        public RecipeController(IRecipeRepository recipes)
        {
            this.repository = recipes;
        }
        #endregion

        #region Actions 
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // get all recipes
            var recipes = repository.GetAll();
            
            // return json action result with results mapped to RecipeViewModel
            return new JsonResult(
               recipes.Adapt<RecipeViewModel[]>(),
               JsonSettings);
            
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = repository.GetById(id);

            return new JsonResult(
               recipe.Adapt<RecipeViewModel>(),
               JsonSettings);
            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]RecipeViewModel model)
        {
            if (model == null) return new StatusCodeResult(500);

            var recipe = new Recipe();

            // later will fetch this with token.
            recipe.CreateUserId = "e8e664fd-4366-4823-bcf1-543eabf56f80";

            recipe.Title = model.Title;
            recipe.Description = model.Description;
            recipe.Instructions = model.Instructions;
            recipe.ViewCount = 1;
            recipe.CreateDate = DateTime.Now;

            repository.Insert(recipe);

            return new JsonResult(recipe.Adapt<RecipeViewModel>(),
                JsonSettings);

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