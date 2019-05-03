using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.Entity.SystemUser
{
    public class ExternalLogin : BaseEntity
    {
        public Guid UserID { get; set; }
        public Provider ProviderName { get; set; }
        public string ProviderKey { get; set; }


        // Relationships

        public virtual User User { get; set; }
    }
}
