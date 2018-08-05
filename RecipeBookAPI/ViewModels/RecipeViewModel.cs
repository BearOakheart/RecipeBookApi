using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RecipeBookAPI.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class RecipeViewModel : BaseViewModel
    {

        #region Constructor

        public RecipeViewModel()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Notes { get; set; }
        public string ViewCount { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Type { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Flags { get; set; }
     
        #endregion
    }
}
