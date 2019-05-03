using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.SystemUser
{
    public class ForgatPassword : BaseEntity
    {
        public Guid UserID { get; set; }
        public string Key { get; set; }



        // Relationships

        public virtual User User { get; set; }

    }
}
