using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        Data.Database.EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);            
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Especialidad a)
        {
            EspecialidadData.Save(a);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }


    }
}
