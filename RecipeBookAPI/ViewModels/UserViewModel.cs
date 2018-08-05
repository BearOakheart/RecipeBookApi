using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RecipeBookAPI.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class UserViewModel : BaseViewModel
    {

        #region Constuctor
        public UserViewModel()
        {

        }
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Type { get; set; }

        [JsonIgnore]
        [DefaultValue(0)]
        public int Flags { get; set; }
 
        #endregion       
    }
}
