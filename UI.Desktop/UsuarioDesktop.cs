using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            MapearDeDatos();
        }

        public Usuario UsuarioActual { get; set; }

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
        }
        public virtual void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.State = Usuario.States.New;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;

            }
            if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = Usuario.States.Modified;
            }
            if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = Usuario.States.Unmodified;
            }
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
        public virtual bool Validar()
        {
            bool valida = false;
            string mensaje = "";

            if (Validaciones.isEmpty(txtNombre.Text))
                mensaje += "El nombre no puede estar en blanco" + "\n";
            if (txtApellido.Text.Trim() == "")
                mensaje += "El apellido no puede estar en blanco" + "\n";
            if (txtClave.Text.Length < 8)
                mensaje += "La clave debe contener al menos 8 caracteres" + "\n";
            if (txtUsuario.Text.Trim() == "")
                mensaje += "El usuario no puede estar en blanco" + "\n";
            if (txtEmail.Text.Trim() == "")
                mensaje += "El email no puede estar en blanco" + "\n";
            if (txtClave.Text.Trim() == "")
                mensaje += "La clave no puede estar en blanco" + "\n";
            if (txtConfirmarClave.Text.Trim() == "")
                mensaje += "Confirmar clave no puede estar en blanco" + "\n";
            if (txtClave.Text.Trim() != txtConfirmarClave.Text.Trim())
                mensaje += "Las claves no coinciden" + "\n";

            if (!String.IsNullOrEmpty(mensaje))
            {
                this.Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valida = true;
            }

            return valida;
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (Validaciones.isEmpty(txtNombre.Text)) { errorNombre.SetError(txtNombre, "Ingrese un Nombre"); }
            else
            {
                if (Validaciones.minChar(txtNombre.Text, 3)) { errorNombre.SetError(txtNombre, "Caracteres minimos 3"); }
                else { errorNombre.Clear(); }
            }           
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (Validaciones.isEmpty(txtApellido.Text)) { errorApellido.SetError(txtApellido, "Ingrese un Apellido"); }
            else
            {
                if (Validaciones.minChar(txtApellido.Text, 3)) { errorApellido.SetError(txtApellido, "Caracteres minimos 3"); }
                else { errorApellido.Clear(); }
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            errorNombre.Clear();
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            errorApellido.Clear();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Validaciones.isEmpty(txtEmail.Text)) { errorEmail.SetError(txtEmail, "Ingrese un Email"); } 
            else
            {
                if (!Validaciones.isEmail(txtEmail.Text)) { errorEmail.SetError(txtEmail, "No es un formato de Email valido"); }
                else { errorEmail.Clear(); } 
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            errorEmail.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {                
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (Validaciones.isEmpty(txtClave.Text)) { errorClave.SetError(txtClave, "Ingrese una Clave"); }
            else
            {
                if (Validaciones.minChar(txtClave.Text, 8)) { errorClave.SetError(txtClave, "Caracteres minimos 8"); }
                else { errorClave.Clear(); }
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            errorClave.Clear();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (Validaciones.isEmpty(txtUsuario.Text)) { errorUsuario.SetError(txtUsuario, "Ingrese un nombre de Usuario"); }
            else
            {
                if (Validaciones.minChar(txtUsuario.Text, 3)) { errorUsuario.SetError(txtUsuario, "Caracteres minimos 3"); }
                else { errorUsuario.Clear(); }
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            errorUsuario.Clear();
        }

        private void txtConfirmarClave_Leave(object sender, EventArgs e)
        {
            if (!Validaciones.coinciden(txtClave.Text, txtConfirmarClave.Text)) { errorConfirmarClave.SetError(txtConfirmarClave, "Las Claves no coinciden"); }
            else { errorConfirmarClave.Clear(); }
        }

        private void txtConfirmarClave_Enter(object sender, EventArgs e)
        {
            errorConfirmarClave.Clear();
        }

    }
}
