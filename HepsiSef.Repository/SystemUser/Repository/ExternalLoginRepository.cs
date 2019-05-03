using HepsiSef.DAL;
using HepsiSef.Entity.SystemUser;
using HepsiSef.Repository.SystemUser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.SystemUser.Repository
{
    public class ExternalLoginRepository : BaseRepository<ExternalLogin>, IExternalLoginRepository

    {
        public ExternalLoginRepository(ApplicationContext context) : base(context)
        {

        }


    }
}
