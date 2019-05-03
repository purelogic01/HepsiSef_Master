using HepsiSef.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.Entity.Definition
{
    public class RecipeRate : BaseEntity
    {
        public Guid RecipeID { get; set; }
        public Guid? UserID { get; set; }

 

        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Rate { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
