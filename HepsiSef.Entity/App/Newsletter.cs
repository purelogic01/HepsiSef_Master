using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.App
{
    public class Newsletter : BaseEntity
    {
        public string IPAddress { get; set; }
        public string Email { get; set; }
    }
}
