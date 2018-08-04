using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Data;
using RecipeBookAPI.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBookAPI.Repositories.Interfaces;


namespace RecipeBookAPI.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        // inherit dbContext from parent
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        

    }
}
