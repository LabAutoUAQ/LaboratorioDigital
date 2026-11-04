using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;

namespace LaboratorioDeAutomatizacion_Almacen
{
    public partial class Usuarios : Form
    {
        private readonly UsuarioRepository _usuarioRepo;
        private DataGridView _dgvUsuarios = null!;

        public Usuarios()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepository();

            ConfigurarControles();
            CargarUsuarios();
        }

        private void ConfigurarControles()
        {
            // Cargar Roles en comboBox1
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Director");
            comboBox1.Items.Add("Almacenista");
            comboBox1.Items.Add("Docente");
            comboBox1.Items.Add("Alumno(a)");
            comboBox1.Items.Add("Trabajador(a)");
            comboBox1.SelectedIndex = 2;

            // Configurar Grid en Panel 2
            _dgvUsuarios = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false
            };
            splitContainer1.Panel2.Controls.Add(_dgvUsuarios);

            _dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
            button1.Click += (s, e) => LimpiarFormulario();
            button2.Click += (s, e) => GuardarUsuario();
        }

        private void CargarUsuarios()
        {
            try
            {
                var lista = _usuarioRepo.ObtenerTodos();
                _dgvUsuarios.DataSource = lista;
                if (_dgvUsuarios.Columns["Clave"] is DataGridViewColumn colClave) colClave.Visible = false;
                if (_dgvUsuarios.Columns["Privilegios"] is DataGridViewColumn colPriv) colPriv.Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar usuarios: {ex.Message}");
            }
        }

        private void DgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (_dgvUsuarios.CurrentRow?.DataBoundItem is UsuarioLaboratorio u)
            {
                textBox1.Text = u.Nombre;
                textBox2.Text = u.Clave;
                textBox3.Text = u.Expediente;
                comboBox1.SelectedIndex = (int)u.Rol;
                textBox7.Text = UsuarioLaboratorio.ObtenerNombreEstado(u.Estado);
                textBox4.Text = u.Carrera;
                textBox5.Text = u.Email;
                textBox6.Text = u.Celular;
            }
        }

        private void LimpiarFormulario()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 2;
            textBox7.Text = "Alta";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }

        private void GuardarUsuario()
        {
            MessageBox.Show("Datos de usuario listos para sincronizar con la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
