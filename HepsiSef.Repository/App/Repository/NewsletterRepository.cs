using HepsiSef.DAL;
using HepsiSef.Entity.App;
using HepsiSef.Repository.App.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.App.Repository
{
    public class NewsletterRepository : BaseRepository<Newsletter>, INewsletterRepository

    {
        public NewsletterRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
