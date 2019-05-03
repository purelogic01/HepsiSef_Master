using HepsiSef.Core.Entity;
using HepsiSef.Entity.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.Definition
{
    public class RecipeCategory : BaseEntity
    {
        public Guid RecipeID { get; set; }
        public Guid CategoryID { get; set; }

        //RELATIONSHIPS
        public virtual Category Category { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
