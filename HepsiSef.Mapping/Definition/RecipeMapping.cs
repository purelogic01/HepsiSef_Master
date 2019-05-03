using HepsiSef.Core.Mapping;
using HepsiSef.Entity.Definition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.Definition
{
    public class RecipeMapping : BaseMap<Recipe>
    {
        public RecipeMapping(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Recipes).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
