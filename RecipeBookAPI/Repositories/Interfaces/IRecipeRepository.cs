using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Data;
using RecipeBookAPI.Data.Models;

namespace RecipeBookAPI.Repositories
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        IQueryable<Recipe> GetAll();

        string GetTest();
    }
}
