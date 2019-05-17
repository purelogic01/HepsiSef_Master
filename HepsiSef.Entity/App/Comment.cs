using HepsiSef.Core.Entity;
using HepsiSef.Entity.Definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Entity.App
{

    public class Comment : BaseEntity
    {
        public string IPAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid?  UserID { get; set; }
        public Guid   RecipeID { get; set; }
        public string Message { get; set; }

        //Relations
        public virtual Recipe Recipe { get; set; }
    }
}
