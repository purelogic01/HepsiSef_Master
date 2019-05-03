using HepsiSef.Core.Entity;
using HepsiSef.Entity.Definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.App
{
    public class Category : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
  
        public string Slug { get; set; }
        public Guid? ParentID { get; set; }
        public bool ShowOnMenu { get; set; }


        public virtual IList<RecipeCategory> RecipeCategories { get; set; }
    }
}
