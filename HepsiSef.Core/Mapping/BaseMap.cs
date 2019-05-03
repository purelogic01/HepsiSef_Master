using HepsiSef.Core.Entity;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Core.Mapping
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.UpdateDate);
            builder.Property(x => x.RecordStatus).IsRequired();
        }
    }
}
