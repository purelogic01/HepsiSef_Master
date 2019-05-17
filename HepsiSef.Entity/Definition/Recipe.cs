using HepsiSef.Core.Entity;
using HepsiSef.Entity.App;
using HepsiSef.Entity.SystemUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.Definition
{
    public class Recipe : BaseEntity
    {

        public string Title { get; set; }
        public string Details { get; set; }
        public Guid UserID { get; set; }
        public string Slug { get; set; }
        public int ServiceCount { get; set; }
        public int Calories { get; set; }
        public int PrepareTime { get; set; }
        public int CookingTime { get; set; }
        public decimal AvarageRate { get; set; }
        public string VideoLink { get; set; }

        //RELATIONSHIPS        
        public virtual User User { get; set; }
        public virtual IList<RecipeIngredient> Ingredients { get; set; }
        public virtual IList<Step> Steps { get; set; }
        public virtual IList<RecipeCategory> RecipeCategories { get; set; }
        public virtual IList<RecipeRate> Rates { get; set; }
        public virtual IList<RecipeImage> Images { get; set; }
        public virtual IList<Bookmark> Bookmarks { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
