using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Response.Category
{
    public class CategoryAllResponse
    {
        public CategoryAllResponse()
        {
            Items = new List<HepsiSef.Entity.App.Category>();
        }

        public List<HepsiSef.Entity.App.Category> Items { get; set; }
    }

    public class CategoryAllResponse2
    {
        public CategoryAllResponse2()
        {
            Items = new List<CategoryMM>();
        }

        public List<CategoryMM> Items { get; set; }
    }

    public class CategoryMM
    {
        public Guid value { get; set; }
        public string label { get; set; }
        public Guid? ParentID { get; set; }
        public List<CategoryMM> children { get; set; }
    }
}
