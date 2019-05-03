using HepsiSef.Core.BaseRepository;
using HepsiSef.DAL;
using HepsiSef.Entity.SystemUser;
using HepsiSef.Repository.SystemUser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.SystemUser.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
