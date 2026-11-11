using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;
using LaboratorioDeAutomatizacion_Almacen.Forms;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen
{
    public partial class InicioDeSesion : Form
    {
        private readonly UsuarioRepository _usuarioRepo;

        public InicioDeSesion()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepository();

            StartPosition = FormStartPosition.CenterScreen;
            textBox2.PasswordChar = '●';

            CargarListaUsuarios();
            ConfigurarEventos();
        }

        private void CargarListaUsuarios()
        {
            try
            {
                var usuarios = _usuarioRepo.ObtenerAdministrativos();
                comboBox1.DataSource = usuarios;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar usuarios iniciales: {ex.Message}");
            }
        }

        private void ConfigurarEventos()
        {
            comboBox1.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedItem is UsuarioLaboratorio u)
                {
                    textBox1.Text = u.Expediente;
                    textBox2.Focus();
                }
            };

            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BuscarPorExpediente();
                }
            };

            textBox2.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    IniciarSesion();
                }
            };

            btnIngresar.Click += (s, e) => IniciarSesion();
            btnLimpiar.Click += (s, e) => LimpiarCampos();
        }

        /// <summary>
        /// SOLUCIÓN A OBSERVACIÓN: Permite borrar y limpiar el expediente y contraseña
        /// sin trabas ni cierres forzados del programa.
        /// </summary>
        private void LimpiarCampos()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void BuscarPorExpediente()
        {
            string exp = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(exp)) return;

            var usuario = _usuarioRepo.BuscarPorExpediente(exp);
            if (usuario != null)
            {
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró ningún usuario con ese expediente.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void IniciarSesion()
        {
            string exp = textBox1.Text.Trim();
            string clave = textBox2.Text.Trim();

            UsuarioLaboratorio? usuario = null;

            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedItem is UsuarioLaboratorio u)
            {
                usuario = u;
            }
            else if (!string.IsNullOrEmpty(exp))
            {
                usuario = _usuarioRepo.BuscarPorExpediente(exp);
            }

            if (usuario == null)
            {
                MessageBox.Show("Por favor seleccione un usuario o ingrese su número de expediente.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (!usuario.ValidarClave(clave))
            {
                MessageBox.Show("Contraseña incorrecta.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.SelectAll();
                textBox2.Focus();
                return;
            }

            if (usuario.Estado == EstadoUsuario.Baja)
            {
                MessageBox.Show("El usuario se encuentra dado de baja en el sistema.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (usuario.Estado == EstadoUsuario.Suspendido)
            {
                MessageBox.Show("El usuario se encuentra suspendido.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usuarioRepo.ActualizarUltimaFecha(usuario.Id);
            SesionActual.UsuarioLogueado = usuario;

            if (usuario.EsAdministrativo)
            {
                var principal = new Almacen_del_Laboratorio_de_Automatizacion();
                principal.FormClosed += (s, e) =>
                {
                    SesionActual.CerrarSesion();
                    LimpiarCampos();
                    Show();
                };
                principal.Show();
                Hide();
            }
            else
            {
                if (usuario.TieneAdeudos)
                {
                    MessageBox.Show($"{usuario.Nombre}, tienes adeudos de materiales pendientes.\nFavor de acudir a ventanilla del Almacén.", "Adeudo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SOLUCIÓN A REQUERIMIENTO:
                // Si existe un vale vigente para el usuario, abrirlo automáticamente
                var valeRepo = new ValeRepository();
                var valeVigente = valeRepo.ObtenerValeVigentePorUsuario(usuario.Id);

                ValesForm valesForm;
                if (valeVigente != null)
                {
                    MessageBox.Show($"Bienvenido(a), {usuario.Nombre}.\nTienes un vale activo en curso (Folio #{valeVigente.Id}).\nSe abrirá automáticamente.", "Vale Vigente Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valesForm = new ValesForm(valeVigente.Id);
                }
                else
                {
                    valesForm = new ValesForm();
                }

                valesForm.FormClosed += (s, e) =>
                {
                    SesionActual.CerrarSesion();
                    LimpiarCampos();
                    Show();
                };
                valesForm.Show();
                Hide();
            }
        }
    }
}
