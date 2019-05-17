using HepsiSef.Core.Mapping;
using HepsiSef.Entity.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.App
{
    public class CommentMapping : BaseMap<Comment>
    {
        public CommentMapping(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Recipe).WithMany(x => x.Comments).HasForeignKey(x => x.RecipeID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
