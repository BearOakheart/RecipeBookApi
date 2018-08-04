using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI.Data.Models
{
    // provides Database standard, these fields should exist in every table. Allways
    public abstract class DbStandardModel
    {

        public string CreateUserId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public string ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }
        
    }
}
