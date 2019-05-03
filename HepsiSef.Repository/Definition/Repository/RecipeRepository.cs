using HepsiSef.DAL;
using HepsiSef.Entity.Definition;
using HepsiSef.Repository.Definition.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.Definition.Repository
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationContext context) : base(context)
        {

        }


    }
}
