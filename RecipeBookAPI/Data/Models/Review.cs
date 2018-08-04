using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookAPI.Data.Models
{
    public class Review : DbStandardModel
    {
        #region Constructor
        public Review()
        {

        }
        #endregion

        #region Properties

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId {get;set;}

        [Required]
        public string Text { get; set; }

        [Required]
        public int Stars { get; set; }

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
