using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Response.Recipe
{
    public class RecipeFocusedResponse
    {
        public RecipeFocusedResponse()
            {
                Images = new List<ImageMMM>();
                Ingredients = new List<IngredientMMM>();
                Steps = new List<StepMMMM>();

            }


            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Details { get; set; }
            public Guid UserID { get; set; }
            public string Slug { get; set; }
            public int ServiceCount { get; set; }
            public int Calories { get; set; }
            public int PrepareTime { get; set; }
            public int CookingTime { get; set; }
            public string Username { get; set; }
            public DateTime CreateDate { get; set; }
            public decimal AvarageRate { get; set; }

        public List<ImageMMM> Images { get; set; }
            public List<IngredientMMM> Ingredients { get; set; }
            public List<StepMMMM> Steps { get; set; }
        }

        public class ImageMMM
        {
            public Guid Id { get; set; }
            public string Image { get; set; }
        }
        public class IngredientMMM
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
        public class StepMMMM
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
 }

