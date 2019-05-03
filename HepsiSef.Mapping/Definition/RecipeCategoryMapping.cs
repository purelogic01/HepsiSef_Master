using HepsiSef.Core.Mapping;
using HepsiSef.Entity.Definition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.Definition
{
    public class RecipeCategoryMapping : BaseMap<RecipeCategory>
    {
        public RecipeCategoryMapping(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.RecipeCategories).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeCategories).HasForeignKey(x => x.RecipeID).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
