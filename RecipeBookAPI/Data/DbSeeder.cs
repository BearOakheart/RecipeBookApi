using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Data.Models;


namespace RecipeBookAPI.Data
{
    public class DbSeeder
    {
        #region Public methods
        public static void Seed(ApplicationDbContext dbContext)
        {
            // create default users if there is none
            if(dbContext.Users.Any() == false)
            {
                CreateUsers(dbContext);
            }

            // create default recipes if there is none
            if(dbContext.Recipes.Any() == false)
            {
                CreateRecipes(dbContext);
            }

        }
        #endregion 

        #region Seed methods (private)
        private static void CreateUsers(ApplicationDbContext dbContext)
        {
            DateTime createdDate = new DateTime(2017,06,05, 12, 15, 00);
            DateTime modifiedDate = DateTime.Now;

            var user_Admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "Admin",
                Email = "akorkiatupa@gmail.com",
                CreateDate = createdDate,
                ModifiedDate = modifiedDate
            };

            dbContext.Users.Add(user_Admin);

//#if DEBUG -- todo: find a fix
            var user_Anu = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "Anu",
                Email = "random@random.com",
                CreateDate = createdDate,
                ModifiedDate = modifiedDate
            };

            dbContext.Users.AddRange(user_Admin, user_Anu);

//#endif
            dbContext.SaveChanges();
        }

        private static void CreateRecipes(ApplicationDbContext dbContext)
        {
            DateTime createdDate = new DateTime(2017, 06, 05, 12, 15, 00);
            DateTime modifiedDate = DateTime.Now;


            var authorId = dbContext.Users.Where(o => o.Username == "Admin").FirstOrDefault().Id;

//#if DEBUG -- todo: find a fix
            var amount = 5;

            for (int i = 0; i <= amount; i++)
            {
                var recipe = new Recipe()
                {
                    UserId = authorId,
                    Title = "Some recipe title",
                    Description = "Tasty food",
                    Instructions = "How to make it",
                    ViewCount = 1,
                    CreateDate = createdDate,
                    ModifiedDate = modifiedDate
                };
                dbContext.Recipes.Add(recipe);
            }
            
            dbContext.SaveChanges();
//#endif
        }
        #endregion
        
    }
}
