using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookAPI.Components
{
    public static class Helper
    {

        public static string UpdateIfNotEmpty(string newValue, string originalValue)
        {
            if (string.IsNullOrEmpty(newValue))
                return originalValue;
            else
                return newValue;
        }

       
    }
}
