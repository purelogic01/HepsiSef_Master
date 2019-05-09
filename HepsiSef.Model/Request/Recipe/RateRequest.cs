using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HepsiSef.Model.Request.Recipe
{
    public class RateRequest
    {
        [Required]
        public Guid RecipeID { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
