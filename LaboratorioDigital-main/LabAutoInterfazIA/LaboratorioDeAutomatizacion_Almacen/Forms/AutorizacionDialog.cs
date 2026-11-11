using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;

namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    public partial class AutorizacionDialog : Form
    {
        private readonly UsuarioRepository _usuarioRepo;
        public UsuarioLaboratorio? SupervisorAutorizado { get; private set; }

        public AutorizacionDialog(string mensajeAccion = "Se requiere autorización para modificar este vale:")
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepository();
            lblMensaje.Text = mensajeAccion;
            CargarSupervisores();
        }

        private void CargarSupervisores()
        {
            var admins = _usuarioRepo.ObtenerAdministrativos();
            cmbSupervisor.Items.Clear();
            foreach (var a in admins)
            {
                cmbSupervisor.Items.Add(a);
            }

            if (cmbSupervisor.Items.Count > 0)
            {
                cmbSupervisor.SelectedIndex = 0;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbSupervisor.SelectedItem is not UsuarioLaboratorio admin)
            {
                MessageBox.Show("Por favor seleccione un supervisor o administrativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clave = txtClave.Text.Trim();
            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor ingrese la contraseña del supervisor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (!admin.ValidarClave(clave))
            {
                MessageBox.Show("La contraseña ingresada es incorrecta.", "Autorización rechazada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.SelectAll();
                txtClave.Focus();
                return;
            }

            SupervisorAutorizado = admin;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
    }
}

