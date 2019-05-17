using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Model.Response.Comment
{
   public class ShowRecipeComment
    {

        public ShowRecipeComment()
        {
            Items = new List<CommentMM>();
        }

        public List<CommentMM> Items { get; set; }
        public int Count { get; set; }

        public class CommentMM
        {

            public Guid Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public DateTime CreateTime { get; set; }
        }

    }
}
