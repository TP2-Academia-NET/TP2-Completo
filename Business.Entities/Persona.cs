﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        public enum TiposPersonas { Administrativo, Docente, Alumno }

        public String Apellido { get; set; }

        public String Direccion { get; set; }

        public String Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IDPlan { get; set; }

        public int Legajo { get; set; }

        public String Nombre { get; set; }

        public String Telefono { get; set; }

        public TiposPersonas TipoPersona { get; set; }
    }
}
