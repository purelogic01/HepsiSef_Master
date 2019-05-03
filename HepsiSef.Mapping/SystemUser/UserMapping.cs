using HepsiSef.Core.Mapping;
using HepsiSef.Entity.SystemUser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.SystemUser
{
    public class UserMapping : BaseMap<User>
    {
        public UserMapping(EntityTypeBuilder<User> builder)
        {

        }
    }
}
