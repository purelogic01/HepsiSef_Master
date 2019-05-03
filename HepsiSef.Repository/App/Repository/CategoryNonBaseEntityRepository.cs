using HepsiSef.DAL;
using HepsiSef.Entity.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.Repository.App.Repository
{
    public class CategoryNonBaseEntityRepository<T> where T : Category //: ICategoryNonBaseEntityRepository
    {



        protected ApplicationContext _context;

        public CategoryNonBaseEntityRepository(ApplicationContext context)
        {
            _context = context;
        }


        public virtual List<T> GetAllBySearch(string search)
        {
            return _context.Set<T>().Where(x => x.Title.Contains(search) && x.RecordStatus != RecordStatus.Deleted).ToList();
        }

    }
}
