using HepsiSef.DAL;
using HepsiSef.Entity.App;
using HepsiSef.Repository.App.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.App.Repository
{
    public class ContactRepositor : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepositor(ApplicationContext context) : base(context)
        {

        }
    }
}
