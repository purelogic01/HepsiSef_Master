using HepsiSef.Core.Mapping;
using HepsiSef.Entity.App;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.App
{
    public class CategoryMapping : BaseMap<Category>
    {
        public CategoryMapping(EntityTypeBuilder<Category> builder)
        {

        }

    }
}
