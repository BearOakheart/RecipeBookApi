using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI.Data.Models
{
    public class Image : DbStandardModel
    {

        #region Constructor

        public Image()
        {

        }
        #endregion

        #region Properties

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImageFormat { get; set;}

        [DefaultValue(0)]
        public int Type { get; set; }

        [DefaultValue(0)]
        public int Flags { get; set; }

       
        #endregion

        #region Lazy load properties

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
        
        #endregion
    }
}
