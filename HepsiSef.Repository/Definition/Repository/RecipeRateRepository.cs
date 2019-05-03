using HepsiSef.DAL;
using HepsiSef.Entity.Definition;
using HepsiSef.Repository.Definition.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.Definition.Repository
{
    public class RecipeRateRepository : BaseRepository<RecipeRate>, IRecipeRateRepository
    {
        public RecipeRateRepository(ApplicationContext context) : base(context)
        {

        }


    }
}
