using HepsiSef.Entity.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.App.Interface
{
    public interface ICategoryNonBaseEntityRepository<T> where T : Category
    {


        List<T> GetAllBySearch(string search);
    }
}
