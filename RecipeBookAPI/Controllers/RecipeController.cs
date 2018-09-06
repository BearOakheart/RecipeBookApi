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
using RecipeBookAPI.Components;
using RecipeBookAPI.Data;

namespace RecipeBookAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]s")]
    public class RecipeController : BaseApiController
    {
        private IRecipeRepository repository;
        private ApplicationDbContext dbContext;

        #region Constuctor
        public RecipeController(IRecipeRepository recipes, ApplicationDbContext dbContext)
        {
            this.repository = recipes;
            this.dbContext = dbContext;
        }
        #endregion

        #region Actions 
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // get all recipes
            //var recipes = repository.GetAll(); // repository pattern way
            var recipes = dbContext.Recipes.ToArray(); // default way
            
            // return json action result with results mapped to RecipeViewModel
            return new JsonResult(
               recipes.Adapt<RecipeViewModel[]>(),
               JsonSettings);
            
            //return new string[] { "value1", "value2" };
        }

        [HttpGet("latest/{num:int?}")]
        public IActionResult Latest(int num = 10)
        {
            var recipes = dbContext.Recipes // get recipes
                .OrderByDescending(obj => obj.CreateDate) // order recipes by row object date desc
                .Take(num) // take only number amount of recipes
                .ToArray(); // add the recipes into array

            return new JsonResult(recipes.Adapt<RecipeViewModel[]>(), JsonSettings);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var recipe = repository.GetById(id); // repository pattern way
            var recipe = dbContext.Recipes.Where(obj => obj.Id == id).FirstOrDefault(); // default way

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

            //repository.Insert(recipe); // repository pattern way
            dbContext.Recipes.Add(recipe); // basic way
            dbContext.SaveChanges(); // basic way

            return new JsonResult(recipe.Adapt<RecipeViewModel>(),
                JsonSettings);

        }

        // TODO: figure out how to use object mapping without overriding values from viewmodel
        // if there is no way write own extension.
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RecipeViewModel model)
        {
            if (model == null) return new StatusCodeResult(500);

            //var recipe = repository.GetById(id); // repository way
            var recipe = dbContext.Recipes.Where(obj => obj.Id == id).FirstOrDefault(); // basic way

            // write helper class to bind viewModel attributes to model attributes 
            
            recipe.Title = model.Title;

            recipe.Description = model.Description;
            recipe.Instructions = model.Instructions;
            recipe.Notes = model.Notes;

            //repository.Update(recipe); // repository way
            dbContext.SaveChanges(); // basic way

            return new JsonResult(recipe.Adapt<RecipeViewModel>(), JsonSettings);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var recipe = repository.GetById(id); // repository way
            var recipe = dbContext.Recipes.Where(obj => obj.Id == id).FirstOrDefault(); // basic way
            

            if(recipe == null)
            {
                return NotFound(new { Error = String.Format("Recipe Id {0} has not been found", id) });
            }

            //repository.Delete(recipe); // repository way

            dbContext.Recipes.Remove(recipe); // basic way
            dbContext.SaveChanges(); // basic way

            return new NoContentResult();
        }

        #endregion
    }
}