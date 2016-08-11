using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        Data.Database.UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Usuario GetOne( int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Usuario a)
        {
            UsuarioData.Save(a);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
    }
}
