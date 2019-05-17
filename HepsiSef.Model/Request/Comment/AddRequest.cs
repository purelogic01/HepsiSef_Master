using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HepsiSef.Model.Request.Comment
{
    public class AddRequest
    {
        public string IPAddress { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Guid? UserID { get; set; }

        [Required]
        public Guid RecipeID { get; set; }

        [Required]
        [MinLength(6)]
        public string Message { get; set; }


    }
}
