using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.App
{
    public class Contact : BaseEntity
    {
        public string IPAddress { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public string Subject { get; set; }
        public string Message { get; set; }
    }
}
