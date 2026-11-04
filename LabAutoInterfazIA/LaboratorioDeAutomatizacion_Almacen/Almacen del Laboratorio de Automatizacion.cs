using System;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Forms;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen
{
    public partial class Almacen_del_Laboratorio_de_Automatizacion : Form
    {
        public Almacen_del_Laboratorio_de_Automatizacion()
        {
            InitializeComponent();
            ConfigurarSegunRol();
        }

        private void ConfigurarSegunRol()
        {
            var u = SesionActual.UsuarioLogueado;
            if (u == null) return;

            Text = $"Almacén del Laboratorio de Automatización - [{u.Nombre} ({UsuarioLaboratorio.ObtenerNombreRol(u.Rol)})]";

            // Aplicar privilegios según rol (como en el sistema Java)
            if (!u.EsDirector)
            {
                usuariosToolStripMenuItem.Visible = u.PuedeAbrir("902");
                parámetrosDelSistemaToolStripMenuItem.Visible = u.PuedeAbrir("903");
                instruccionesSQLToolStripMenuItem.Visible = u.PuedeAbrir("904");
            }
        }

        private void almacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inventarioForm = new InventarioForm();
            inventarioForm.Show(this);
        }

        private void capturaValesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var valesForm = new ValesForm();
            valesForm.Show(this);
        }

        private void resumenDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resumenForm = new ResumenDiarioForm();
            resumenForm.ShowDialog(this);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var usuariosForm = new Usuarios();
            usuariosForm.Show(this);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Almacén del Laboratorio de Automatización\n" +
                "Facultad de Ingeniería - Universidad Autónoma de Querétaro\n\n" +
                "Migración y Sistema .NET 10 / Windows Forms\n" +
                "Base de Datos Oracle",
                "Acerca de...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionActual.CerrarSesion();
            Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
