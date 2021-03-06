﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeBookAPI.Data;
using RecipeBookAPI.Repositories;
using RecipeBookAPI.Repositories.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add entityframework core
            services.AddEntityFrameworkSqlServer();

            // Add ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // todo: figure out if there is a way to register whole folder of repositories. This gets annoying if environment is massive
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));           
            services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));           
            services.AddScoped(typeof(IImageRepository), typeof(ImageRepository));           
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));           
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            DbSeeder.Seed(dbContext);
        }
    }
}
