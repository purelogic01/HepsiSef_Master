using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Request.Recipe
{
    public class RecipeAllRequest
    {

        public Guid? CategoryID { get; set; }
        public int? ServiceCount { get; set; }
        public int? CookingTime { get; set; }
    

        public int Skip { get; set; }
    }
}
