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
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[]
        public int Rate { get; set; }
        [Required]
        public string Comment { get; set; }




    }
}
