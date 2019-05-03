using HepsiSef.DAL;
using HepsiSef.Entity.Definition;
using HepsiSef.Repository.Definition.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiSef.Repository.Definition.Repository
{
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        public StepRepository(ApplicationContext context) : base(context)
        {

        }


    }
}
