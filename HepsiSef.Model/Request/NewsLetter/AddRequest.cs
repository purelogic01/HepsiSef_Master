using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HepsiSef.Model.Request.NewsLetter
{
    public class AddRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
