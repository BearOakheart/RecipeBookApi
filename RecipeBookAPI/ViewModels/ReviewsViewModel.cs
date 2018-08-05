using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RecipeBookAPI.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ReviewsViewModel : BaseViewModel
    {
        #region Constructor
        public ReviewsViewModel() { }
        #endregion

        #region Properties
        
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Type { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Flags { get; set; }

        #endregion
    }
}
