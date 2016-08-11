using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.Text = "Agregar Especialidad";
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID,ApplicationForm.ModoForm.Modificacion);
                formEspecialidad.Text = "Modificar Especialidad";
                formEspecialidad.ShowDialog();
            }

            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID,ApplicationForm.ModoForm.Baja);
                formEspecialidad.Text = "Eliminar Especialidad";
                formEspecialidad.ShowDialog();
            }

            Listar();
        }
    }
}
