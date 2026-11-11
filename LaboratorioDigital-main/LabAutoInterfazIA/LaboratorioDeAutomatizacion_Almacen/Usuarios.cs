using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen
{
    public partial class Usuarios : Form
    {
        private readonly UsuarioRepository _usuarioRepo;
        private List<UsuarioLaboratorio> _todosLosUsuarios = new();
        private UsuarioLaboratorio? _usuarioSeleccionado;
        private bool _claveVisible = false;

        public Usuarios()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepository();

            TemaVisual.AplicarTemaFormulario(this);
            TemaVisual.AplicarPanelCabecera(panelHeader, lblTitulo, lblSubtitulo);
            TemaVisual.AplicarEstiloGrid(dgvUsuarios);
            TemaVisual.AplicarBotonPrimario(btnGuardar);
            TemaVisual.AplicarBotonSecundario(btnNuevo);
            TemaVisual.AplicarBotonSecundario(btnVerClave);

            ConfigurarPermisosDirector();
            ConfigurarControles();
            CargarUsuarios();
        }

        private void ConfigurarPermisosDirector()
        {
            bool esDirector = SesionActual.EsDirector;

            lblAvisoDirector.Visible = esDirector;
            cmbRol.Enabled = esDirector;
            btnVerClave.Visible = esDirector;

            if (!esDirector)
            {
                lblAvisoDirector.Text = "Solo el Director puede modificar roles o consultar contraseñas.";
                lblAvisoDirector.ForeColor = TemaVisual.GrisTextoMuted;
                lblAvisoDirector.Visible = true;
            }
        }

        private void ConfigurarControles()
        {
            // Columnas del Grid
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Expediente",
                HeaderText = "Expediente",
                Width = 100,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre Completo",
                Width = 240,
                ReadOnly = true
            });

            // Rol descriptivo
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rol",
                Width = 110,
                ReadOnly = true
            });

            // Estado descriptivo
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado",
                Width = 90,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Carrera",
                HeaderText = "Carrera",
                Width = 140,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 160,
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Celular",
                HeaderText = "Celular",
                Width = 110,
                ReadOnly = true
            });

            // Contraseña visible solo para Director
            var colClave = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Clave",
                HeaderText = "Contraseña",
                Width = 110,
                ReadOnly = true,
                Visible = SesionActual.EsDirector
            };
            dgvUsuarios.Columns.Add(colClave);

            dgvUsuarios.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvUsuarios.Rows.Count) return;
                if (dgvUsuarios.Rows[e.RowIndex].DataBoundItem is UsuarioLaboratorio u)
                {
                    if (e.ColumnIndex == 3) // Rol
                    {
                        e.Value = UsuarioLaboratorio.ObtenerNombreRol(u.Rol);
                    }
                    else if (e.ColumnIndex == 4) // Estado
                    {
                        e.Value = UsuarioLaboratorio.ObtenerNombreEstado(u.Estado);
                    }
                }
            };

            // Llenar ComboBoxes de Roles
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Director");
            cmbRol.Items.Add("Almacenista");
            cmbRol.Items.Add("Docente");
            cmbRol.Items.Add("Alumno(a)");
            cmbRol.Items.Add("Trabajador(a)");
            cmbRol.SelectedIndex = 3;

            cmbFiltroRol.Items.Clear();
            cmbFiltroRol.Items.Add("Todos los roles");
            cmbFiltroRol.Items.Add("Director");
            cmbFiltroRol.Items.Add("Almacenista");
            cmbFiltroRol.Items.Add("Docente");
            cmbFiltroRol.Items.Add("Alumno(a)");
            cmbFiltroRol.Items.Add("Trabajador(a)");
            cmbFiltroRol.SelectedIndex = 0;

            // Llenar ComboBoxes de Estados
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Baja");
            cmbEstado.Items.Add("Alta");
            cmbEstado.Items.Add("Suspendido");
            cmbEstado.Items.Add("Vacaciones");
            cmbEstado.SelectedIndex = 1;

            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todos los estados");
            cmbFiltroEstado.Items.Add("Baja");
            cmbFiltroEstado.Items.Add("Alta");
            cmbFiltroEstado.Items.Add("Suspendido");
            cmbFiltroEstado.Items.Add("Vacaciones");
            cmbFiltroEstado.SelectedIndex = 0;

            // Eventos
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;

            txtBuscarUsuario.TextChanged += (s, e) => AplicarFiltrosYOrden();
            cmbFiltroRol.SelectedIndexChanged += (s, e) => AplicarFiltrosYOrden();
            cmbFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltrosYOrden();

            btnVerClave.Click += BtnVerClave_Click;
            btnNuevo.Click += (s, e) => LimpiarFormulario();
            btnGuardar.Click += (s, e) => GuardarUsuario();
        }

        private void CargarUsuarios()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _todosLosUsuarios = _usuarioRepo.ObtenerTodos();
                AplicarFiltrosYOrden();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AplicarFiltrosYOrden()
        {
            IEnumerable<UsuarioLaboratorio> filtrados = _todosLosUsuarios;

            // 1. Filtro por Rol
            if (cmbFiltroRol.SelectedIndex > 0)
            {
                RolUsuario rolFiltro = (RolUsuario)(cmbFiltroRol.SelectedIndex - 1);
                filtrados = filtrados.Where(u => u.Rol == rolFiltro);
            }

            // 2. Filtro por Estado
            if (cmbFiltroEstado.SelectedIndex > 0)
            {
                EstadoUsuario estadoFiltro = (EstadoUsuario)(cmbFiltroEstado.SelectedIndex - 1);
                filtrados = filtrados.Where(u => u.Estado == estadoFiltro);
            }

            // 3. Búsqueda con tolerancia a errores tipográficos (Fuzzy Search)
            string textoBusqueda = txtBuscarUsuario.Text.Trim();
            List<UsuarioLaboratorio> listaFinal;
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFinal = BusquedaFuzzyService.FiltrarUsuarios(filtrados, textoBusqueda, umbralMinimo: 0.55);
            }
            else
            {
                listaFinal = filtrados.OrderBy(u => u.Nombre).ToList();
            }

            dgvUsuarios.DataSource = listaFinal;
            lblTotalUsuarios.Text = $"Total: {listaFinal.Count} usuarios";
        }

        private void DgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is UsuarioLaboratorio u)
            {
                _usuarioSeleccionado = u;
                txtNombre.Text = u.Nombre;
                txtExpediente.Text = u.Expediente;

                // Contraseña: solo Director puede verla
                if (SesionActual.EsDirector)
                {
                    txtClave.Text = u.Clave;
                    txtClave.PasswordChar = _claveVisible ? '\0' : '●';
                    txtClave.ReadOnly = false;
                }
                else
                {
                    txtClave.Text = "••••••••";
                    txtClave.PasswordChar = '●';
                    txtClave.ReadOnly = true;
                }

                cmbRol.SelectedIndex = Math.Clamp((int)u.Rol, 0, 4);
                cmbEstado.SelectedIndex = Math.Clamp((int)u.Estado, 0, 3);
                txtCarrera.Text = u.Carrera;
                txtEmail.Text = u.Email;
                txtCelular.Text = u.Celular;

                lblTituloDetalle.Text = $"Editar: {u.Nombre}";
            }
        }

        private void BtnVerClave_Click(object? sender, EventArgs e)
        {
            if (!SesionActual.EsDirector) return;

            _claveVisible = !_claveVisible;
            txtClave.PasswordChar = _claveVisible ? '\0' : '●';
            btnVerClave.Text = _claveVisible ? "🙈 Ocultar" : "👁 Ver";
        }

        private void LimpiarFormulario()
        {
            _usuarioSeleccionado = null;
            txtNombre.Clear();
            txtExpediente.Clear();
            txtClave.Clear();
            txtClave.ReadOnly = false;
            txtClave.PasswordChar = '●';
            _claveVisible = false;
            btnVerClave.Text = "👁 Ver";

            cmbRol.SelectedIndex = 3; // Alumno por defecto
            cmbEstado.SelectedIndex = 1; // Alta por defecto
            txtCarrera.Clear();
            txtEmail.Clear();
            txtCelular.Clear();

            lblTituloDetalle.Text = "Nuevo Usuario";
            txtNombre.Focus();
        }

        private void GuardarUsuario()
        {
            string nombre = txtNombre.Text.Trim();
            string exp = txtExpediente.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(exp))
            {
                MessageBox.Show("El número de expediente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExpediente.Focus();
                return;
            }

            RolUsuario rolSeleccionado = (RolUsuario)Math.Clamp(cmbRol.SelectedIndex, 0, 4);
            EstadoUsuario estadoSeleccionado = (EstadoUsuario)Math.Clamp(cmbEstado.SelectedIndex, 0, 3);

            // Si es un usuario existente
            if (_usuarioSeleccionado != null && _usuarioSeleccionado.Id > 0)
            {
                _usuarioSeleccionado.Nombre = nombre;
                _usuarioSeleccionado.Expediente = exp;
                _usuarioSeleccionado.Estado = estadoSeleccionado;
                _usuarioSeleccionado.Carrera = txtCarrera.Text.Trim();
                _usuarioSeleccionado.Email = txtEmail.Text.Trim();
                _usuarioSeleccionado.Celular = txtCelular.Text.Trim();

                // Rol solo si es Director
                if (SesionActual.EsDirector)
                {
                    _usuarioSeleccionado.Rol = rolSeleccionado;
                    if (clave != "••••••••" && !string.IsNullOrEmpty(clave))
                    {
                        _usuarioSeleccionado.Clave = clave;
                    }
                }

                if (_usuarioRepo.ActualizarUsuario(_usuarioSeleccionado, out string error))
                {
                    MessageBox.Show("Usuario actualizado y guardado correctamente en la base de datos Oracle.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show($"Error al guardar en base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Usuario Nuevo
                if (string.IsNullOrEmpty(clave) || clave == "••••••••")
                {
                    MessageBox.Show("Debe asignar una contraseña para el nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }

                UsuarioLaboratorio nuevo = rolSeleccionado switch
                {
                    RolUsuario.Director => new Administrativo { Departamento = "Dirección" },
                    RolUsuario.Almacenista => new Almacenista { Turno = "Matutino" },
                    _ => new Prestatario()
                };

                nuevo.Nombre = nombre;
                nuevo.Expediente = exp;
                nuevo.Clave = clave;
                nuevo.Rol = SesionActual.EsDirector ? rolSeleccionado : RolUsuario.Alumno;
                nuevo.Estado = estadoSeleccionado;
                nuevo.Carrera = txtCarrera.Text.Trim();
                nuevo.Email = txtEmail.Text.Trim();
                nuevo.Celular = txtCelular.Text.Trim();

                if (_usuarioRepo.CrearUsuario(nuevo, out string error))
                {
                    MessageBox.Show("Usuario registrado y guardado exitosamente en la base de datos Oracle.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show($"Error al insertar en la base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
