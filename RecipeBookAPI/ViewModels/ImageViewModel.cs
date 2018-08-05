using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RecipeBookAPI.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ImageViewModel : BaseViewModel
    {
        #region
        public ImageViewModel() { }
        #endregion

        #region
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ImageName { get; set; }
        public int ImageFormat { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Type { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Flags { get; set; }

        #endregion
    }
}
