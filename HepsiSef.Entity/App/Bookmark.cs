using HepsiSef.Core.Entity;
using HepsiSef.Entity.Definition;
using HepsiSef.Entity.SystemUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.App
{
    public class Bookmark : BaseEntity
    {
        public Guid UserID { get; set; }
        public Guid RecipeID { get; set; }

        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
