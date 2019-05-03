using HepsiSef.Core.Mapping;
using HepsiSef.Entity.Definition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.Definition
{
    public class RecipeIngredientMapping : BaseMap<RecipeIngredient>
    {
        public RecipeIngredientMapping(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasOne(x => x.Recipe).WithMany(x => x.Ingredients).HasForeignKey(x => x.RecipeID).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
