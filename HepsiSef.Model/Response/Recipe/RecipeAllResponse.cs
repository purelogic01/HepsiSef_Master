﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Response.Recipe
{
    public class RecipeAllResponse
    {
        public RecipeAllResponse()
        {
            Items = new List<RecipeMM>();
        }

        public List<RecipeMM> Items { get; set; }
        public int Count { get; set; }
    }

    public class RecipeMM
    {
       
              
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid UserID { get; set; }
        public string Slug { get; set; }
        public int ServiceCount { get; set; }
        public int PrepareTime { get; set; }
        public string Username { get;  set; }
        public DateTime CreateDate { get; set; }
        public List<ImageMM> Images { get; set; }

    }

    public class ImageMM
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
    }
   
}
