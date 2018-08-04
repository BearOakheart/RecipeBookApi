using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Repositories.Interfaces;
using RecipeBookAPI.Data;
using RecipeBookAPI.Data.Models;

namespace RecipeBookAPI.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
