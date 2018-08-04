using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI.Data.Models
{
    public class Recipe : DbStandardModel
    {

        #region Constuctor
        public Recipe()
        {

        }
        #endregion

        #region Properties

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }


        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public string Notes { get; set; }

        [Required]
        public int ViewCount { get; set; }

        [DefaultValue(0)]
        public int Type { get; set; }

        [DefaultValue(0)]
        public int Flags { get; set; }
        
       
        #endregion

        #region Lazy load properties

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual List<Review> Reviews { get; set; }

        #endregion
    }
}
