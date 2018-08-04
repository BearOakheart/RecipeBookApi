using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace RecipeBookAPI.Repositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        
    }
}
