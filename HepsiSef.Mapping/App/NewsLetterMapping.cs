using HepsiSef.Core.Mapping;
using HepsiSef.Entity.App;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.App
{
    public class NewsletterMapping : BaseMap<Newsletter>
    {
        public NewsletterMapping(EntityTypeBuilder<Newsletter> builder)
        {

        }

    }
}
