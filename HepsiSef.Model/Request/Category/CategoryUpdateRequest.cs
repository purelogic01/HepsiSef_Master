using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HepsiSef.Model.Request.Category
{
    public class CategoryUptadeRequest
    {
        [MinLength(3)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }


    }
}
