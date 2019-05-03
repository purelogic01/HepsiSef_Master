using HepsiSef.DAL;
using HepsiSef.Entity.App;
using HepsiSef.Repository.App.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.App.Repository
{
    public class BookmarkRepository : BaseRepository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
