using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RecipeBookAPI.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class BaseViewModel
    {
        #region Constructor
        public BaseViewModel() { }
        #endregion

        #region General properties

        // db standard propertioes
        public string CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedUserId { get; set; }
        public DateTime ModifiedDate { get; set; }

        #endregion
    }
}
