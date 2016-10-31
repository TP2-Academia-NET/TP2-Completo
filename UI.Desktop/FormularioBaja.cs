using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class FormularioBaja : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }

        public FormularioBaja()
        {            
            InitializeComponent();
        }

        public FormularioBaja(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public FormularioBaja(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            labelUsuario.Text = UsuarioActual.Apellido + ", " + UsuarioActual.Nombre + ".";            
            MapearDeDatos();
        }

        public virtual void MapearADatos()
        {           
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = Usuario.States.Deleted;
            }
        }
        public virtual void GuardarCambios()
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }       
        
        private void txtBorrar_TextChanged(object sender, EventArgs e)
        {
            if (Validaciones.ComparaString(txtBorrar.Text, "borrar"))
            {
                btnAceptar.Enabled = true;
            }
        }
    }
}
