using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecipeBookAPI.Data.Models;

namespace RecipeBookAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           
        }

        #endregion
        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // build Users
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().HasMany(o => o.Recipes).WithOne(o => o.User);

            // build Recipes
            modelBuilder.Entity<Recipe>().ToTable("Recipes");
            modelBuilder.Entity<Recipe>().Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Recipe>().HasOne(o => o.User).WithMany(o => o.Recipes);
            modelBuilder.Entity<Recipe>().HasMany(o => o.Images).WithOne(o => o.Recipe);
            modelBuilder.Entity<Recipe>().HasMany(o => o.Reviews).WithOne(o => o.Recipe);

            // build Images

            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Image>().Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>().HasOne(o => o.Recipe).WithMany(o => o.Images);

            // build Reviews

            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<Review>().Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>().HasOne(o => o.Recipe).WithMany(o => o.Reviews);



        }

        #endregion
        #region Properties

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
       
        #endregion

    }
}
