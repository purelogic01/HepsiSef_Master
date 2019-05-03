using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.Definition
{
    public class RecipeImage : BaseEntity
    {
        public Guid RecipeID { get; set; }
        public string Image { get; set; }
        public bool ISCover { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
