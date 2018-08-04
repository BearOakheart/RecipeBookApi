using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI.Data.Models
{
    public class ApplicationUser : DbStandardModel
    {
        #region Constuctor
        public ApplicationUser()
        {

        }
        #endregion

        #region Properties

        /* Note that Application user Id is a string because net core auth & authorization structure */
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Notes { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Flags { get; set; }
              
        #endregion

        #region Lazy load properties

        public virtual List<Recipe> Recipes { get; set; }

        #endregion
    }
}
