using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HepsiSef.Model.Request.Contact
{
    public class ContactRequest
    {
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(3)]
        public string Message { get; set; }

    }
}
