using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Request.Recipe
{
    public class RecipeCreateRequest
    {
        public RecipeCreateRequest()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            Images = new List<Image>();
            Categories = new List<Category>();
        }

        public string Title { get; set; }
        public string Details { get; set; }
        public int ServiceCount { get; set; }
        public int Calories { get; set; }
        public int PrepareTime { get; set; }
        public int CookingTime { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public List<Image> Images { get; set; }
        public List<Category> Categories { get; set; }
     }

    public class Ingredient
    {
        public string Title { get; set; }
    }
    public class Step
    {
        public string Title { get; set; }
    }
    public class Image
    {
        public string image { get; set; }
    }

    public class Category
    {
        public Guid CategoryID { get; set; }
    }
}
