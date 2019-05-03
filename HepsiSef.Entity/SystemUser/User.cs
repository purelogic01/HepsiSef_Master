using HepsiSef.Core.Entity;
using HepsiSef.Entity.App;
using HepsiSef.Entity.Definition;
using System;
using System.Collections.Generic;
using System.Text;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.Entity.SystemUser
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        //public Guid? ActivationCode { get; set; }

        //Relations
        public virtual IList<Recipe> Recipes { get; set; }
        public virtual IList<Bookmark> Bookmarks { get; set; }
        public virtual IList<ExternalLogin> ExternalLogins { get; set; }
        public virtual IList<ForgatPassword> ForgatPasswords { get; set; }
    }
}
