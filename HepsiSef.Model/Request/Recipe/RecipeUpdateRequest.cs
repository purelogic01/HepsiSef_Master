using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Request.Recipe
{
    public class RecipeUpdateRequest
    {
        public RecipeUpdateRequest()
        {
            Ingredients = new List<RecipeIngredientMM>();
            Steps = new List<RecipeStep>();
            Images = new List<RecipeImagesMM>();
            Categories = new List<RecipeCategoryMM>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int ServiceCount { get; set; }
        public int Calories { get; set; }
        public int PrepareTime { get; set; }
        public int CookingTime { get; set; }



        public List<RecipeIngredientMM> Ingredients { get; set; }
        public List<RecipeStep> Steps { get; set; }
        public List<RecipeImagesMM> Images { get; set; }
        public List<RecipeCategoryMM> Categories { get; set; }



    }

    public class RecipeIngredientMM
    {
        public string Title { get; set; }
    }

    public class RecipeStep
    {
        public string Title { get; set; }
    }

    public class RecipeImagesMM
    {
        public string Image { get; set; }
    }
    public class RecipeCategoryMM
    {
        public Guid CategoryID { get; set; }
    }
}
