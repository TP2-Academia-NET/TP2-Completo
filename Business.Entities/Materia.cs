using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        public String Descripcion { get; set;}

        public int HSSemanales { get; set; }

        public int HSTotales { get; set; }

        public int IDPlan { get; set; }
    }
}
