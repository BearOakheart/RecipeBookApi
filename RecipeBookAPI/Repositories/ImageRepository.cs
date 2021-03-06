﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBookAPI.Data;
using RecipeBookAPI.Data.Models;
using RecipeBookAPI.Repositories.Interfaces;

namespace RecipeBookAPI.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
