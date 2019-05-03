using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.Definition
{
    public class RecipeIngredient : BaseEntity
    {
        public Guid RecipeID { get; set; }
        public string Title { get; set; }

        //RELATIONSHIPS
        public virtual Recipe Recipe { get; set; }
    }
}
