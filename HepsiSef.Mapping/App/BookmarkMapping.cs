using HepsiSef.Core.Mapping;
using HepsiSef.Entity.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Mapping.App
{
    public class BookmarkMapping : BaseMap<Bookmark>
    {
        public BookmarkMapping(EntityTypeBuilder<Bookmark> buider)
        {
            buider.HasOne(x => x.Recipe).WithMany(x => x.Bookmarks).HasForeignKey(x => x.RecipeID).OnDelete(DeleteBehavior.Restrict);
            buider.HasOne(x => x.User).WithMany(x => x.Bookmarks).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
