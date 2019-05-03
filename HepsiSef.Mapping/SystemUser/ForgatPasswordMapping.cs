﻿using HepsiSef.Core.Mapping;
using HepsiSef.Entity.SystemUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.SystemUser
{
    public class ForgatPasswordMapping : BaseMap<ForgatPassword>
    {
        public ForgatPasswordMapping(EntityTypeBuilder<ForgatPassword> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.ForgatPasswords).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
