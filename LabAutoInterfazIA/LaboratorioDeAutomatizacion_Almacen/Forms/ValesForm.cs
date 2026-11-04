using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;
using LaboratorioDeAutomatizacion_Almacen.Models;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    public partial class ValesForm : Form
    {
        private readonly ValeRepository _valeRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly InventarioRepository _inventarioRepository;
        private readonly ImpresionService _impresionService;

        private Vale? _valeActual;
        private bool _modoModificacion = false;

        public ValesForm(int idValeInicial = 0)
        {
            InitializeComponent();
            _valeRepository = new ValeRepository();
            _usuarioRepository = new UsuarioRepository();
            _inventarioRepository = new InventarioRepository();
            _impresionService = new ImpresionService();

            ConfigurarGrid();
            CargarMaterialesCombo();

            cmbMateriales.SelectedIndexChanged += CmbMateriales_SelectedIndexChanged;

            if (idValeInicial > 0)
            {
                CargarVale(idValeInicial);
            }
            else
            {
                NuevoVale();
            }
        }

        private void ConfigurarGrid()
        {
            dgvMateriales.AutoGenerateColumns = false;
            dgvMateriales.Columns.Clear();

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código",
                Width = 100,
                ReadOnly = true
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 260,
                ReadOnly = true
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Width = 80
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unidad",
                HeaderText = "Unidad",
                Width = 80,
                ReadOnly = true
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Recibido",
                HeaderText = "Devuelto",
                Width = 80
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                Width = 180
            });
        }

        private void CargarMaterialesCombo()
        {
            try
            {
                var inventario = _inventarioRepository.ObtenerTodos(soloConExistencia: false);
                cmbMateriales.DataSource = inventario;
                cmbMateriales.DisplayMember = "Descripcion";
                cmbMateriales.ValueMember = "Id";
                if (cmbMateriales.Items.Count > 0) cmbMateriales.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar materiales: {ex.Message}");
            }
        }

        private void CmbMateriales_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbMateriales.SelectedItem is InventarioItem item)
            {
                CargarMiniaturaMaterial(item);
            }
            else
            {
                picMiniMaterial.Image?.Dispose();
                picMiniMaterial.Image = null;
            }
        }

        private void CargarMiniaturaMaterial(InventarioItem item)
        {
            try
            {
                picMiniMaterial.Image?.Dispose();
                picMiniMaterial.Image = null;

                string ruta = item.ObtenerRutaImagen();
                if (!string.IsNullOrEmpty(ruta) && File.Exists(ruta))
                {
                    using var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    picMiniMaterial.Image = Image.FromStream(stream);
                }
            }
            catch
            {
                picMiniMaterial.Image = null;
            }
        }

        public void CargarVale(int valeId)
        {
            var vale = _valeRepository.BuscarPorId(valeId);
            if (vale == null)
            {
                MessageBox.Show($"No se encontró el vale #{valeId}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _valeActual = vale;
            _modoModificacion = false;
            MostrarDatosVale();
        }

        private void MostrarDatosVale()
        {
            if (_valeActual == null) return;

            txtValeId.Text = _valeActual.Id.ToString();
            txtFecha.Text = _valeActual.Fecha.ToString("dd/MM/yyyy HH:mm");
            dtpFechaEntrega.Value = _valeActual.FechaParaEntregar ?? DateTime.Now.AddDays(1);
            txtExpediente.Text = _valeActual.ExpedienteUsuario;
            txtNombreSolicitante.Text = _valeActual.NombreUsuario;
            txtCarrera.Text = _valeActual.Carrera;
            txtMateria.Text = _valeActual.Materia;
            txtObservaciones.Text = _valeActual.Observaciones;

            txtAutorizo.Text = string.IsNullOrEmpty(_valeActual.NombreAutorizo) ? "(Pendiente de autorizar)" : _valeActual.NombreAutorizo;
            txtRecibio.Text = string.IsNullOrEmpty(_valeActual.NombreRecibio) ? "(Pendiente de devolución)" : _valeActual.NombreRecibio;

            ActualizarGridMateriales();
            ActualizarEstadoControles();
        }

        private void ActualizarGridMateriales()
        {
            dgvMateriales.DataSource = null;
            if (_valeActual != null)
            {
                dgvMateriales.DataSource = _valeActual.Movimientos.ToList();
            }
        }

        private void ActualizarEstadoControles()
        {
            if (_valeActual == null) return;

            bool esNuevo = _valeActual.Id == 0;
            bool estaAutorizado = _valeActual.EstaAutorizado;
            bool estaRecibido = _valeActual.EstaRecibido;
            bool esAdmin = SesionActual.EsAdministrativo;

            // En modo modificación o nuevo se permite editar datos y agregar materiales
            bool permitirEdicion = esNuevo || _modoModificacion;

            pnlAgregarMaterial.Enabled = permitirEdicion && !estaRecibido;
            btnEliminarItem.Enabled = permitirEdicion && !estaRecibido;
            txtMateria.ReadOnly = !permitirEdicion;
            txtCarrera.ReadOnly = !permitirEdicion;
            txtObservaciones.ReadOnly = !permitirEdicion;
            dtpFechaEntrega.Enabled = permitirEdicion;

            // OBSERVACIÓN 1: El alumno NO puede modificar un vale existente. 
            // El botón 'Modificar Vale' SOLO es visible y accesible para perfiles administrativos (Director o Almacenista)
            btnModificar.Visible = esAdmin && !esNuevo && !estaRecibido;
            btnModificar.Enabled = esAdmin && !esNuevo && !_modoModificacion && !estaRecibido;

            btnGuardar.Enabled = permitirEdicion;
            btnRegistrarDevolucion.Enabled = esAdmin && !esNuevo && estaAutorizado && !estaRecibido;

            if (_modoModificacion)
            {
                lblEstadoModo.Text = "⚠ MODO MODIFICACIÓN ACTIVO (Administrador): Puede agregar/quitar materiales. Guardar requerirá autorización.";
                lblEstadoModo.ForeColor = Color.DarkRed;
                lblEstadoModo.Visible = true;
            }
            else if (estaRecibido)
            {
                lblEstadoModo.Text = "✔ VALE ENTREGADO / CONCLUIDO";
                lblEstadoModo.ForeColor = Color.DarkGreen;
                lblEstadoModo.Visible = true;
            }
            else if (estaAutorizado)
            {
                lblEstadoModo.Text = "✔ VALE AUTORIZADO Y EN PRÉSTAMO";
                lblEstadoModo.ForeColor = Color.Navy;
                lblEstadoModo.Visible = true;
            }
            else
            {
                lblEstadoModo.Text = "NUEVO VALE (Listo para capturar materiales)";
                lblEstadoModo.ForeColor = Color.DimGray;
                lblEstadoModo.Visible = true;
            }
        }

        /// <summary>
        /// OBSERVACIÓN 1: Generar un vale nuevo en cualquier momento sin necesidad de borrar 
        /// el vale existente ni reiniciar el programa.
        /// </summary>
        private void NuevoVale()
        {
            _valeActual = new Vale
            {
                Id = 0,
                Fecha = DateTime.Now,
                FechaParaEntregar = DateTime.Now.AddDays(1)
            };
            _modoModificacion = false;

            txtValeId.Text = "(Nuevo)";
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtExpediente.Text = "";
            txtNombreSolicitante.Text = "";
            txtCarrera.Text = "";
            txtMateria.Text = "";
            txtObservaciones.Text = "";
            txtAutorizo.Text = "(Pendiente)";
            txtRecibio.Text = "(Pendiente)";

            // Si el usuario logueado es alumno/prestatario, prellenamos automáticamente su expediente
            if (!SesionActual.EsAdministrativo && SesionActual.UsuarioLogueado != null)
            {
                var u = SesionActual.UsuarioLogueado;
                _valeActual.IdUsuario = u.Id;
                _valeActual.NombreUsuario = u.Nombre;
                _valeActual.ExpedienteUsuario = u.Expediente;
                _valeActual.Carrera = u.Carrera;
                _valeActual.EmailUsuario = u.Email;
                _valeActual.CelularUsuario = u.Celular;

                txtExpediente.Text = u.Expediente;
                txtNombreSolicitante.Text = u.Nombre;
                txtCarrera.Text = u.Carrera;
            }

            ActualizarGridMateriales();
            ActualizarEstadoControles();
            txtExpediente.Focus();
        }

        private void btnBuscarExpediente_Click(object sender, EventArgs e)
        {
            string exp = txtExpediente.Text.Trim();
            if (string.IsNullOrEmpty(exp))
            {
                MessageBox.Show("Ingrese un número de expediente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var usuario = _usuarioRepository.BuscarPorExpediente(exp);
            if (usuario == null)
            {
                MessageBox.Show("No se encontró ningún usuario con ese expediente.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario.TieneAdeudos)
            {
                MessageBox.Show($"El usuario {usuario.Nombre} tiene adeudos pendientes de vales anteriores.", "Adeudo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (_valeActual != null)
            {
                _valeActual.IdUsuario = usuario.Id;
                _valeActual.NombreUsuario = usuario.Nombre;
                _valeActual.ExpedienteUsuario = usuario.Expediente;
                _valeActual.Carrera = usuario.Carrera;
                _valeActual.EmailUsuario = usuario.Email;
                _valeActual.CelularUsuario = usuario.Celular;

                txtNombreSolicitante.Text = usuario.Nombre;
                txtCarrera.Text = usuario.Carrera;
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (cmbMateriales.SelectedItem is not InventarioItem item)
            {
                MessageBox.Show("Seleccione un material de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cant = numCantidad.Value;
            if (cant <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _valeActual?.Movimientos.Add(new ValeMovimiento
            {
                IdInventario = item.Id,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion,
                Cantidad = cant,
                Unidad = item.Unidad,
                Observaciones = txtItemObs.Text.Trim()
            });

            ActualizarGridMateriales();
            numCantidad.Value = 1;
            txtItemObs.Text = "";
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow?.DataBoundItem is ValeMovimiento mov)
            {
                _valeActual?.Movimientos.Remove(mov);
                ActualizarGridMateriales();
            }
        }

        /// <summary>
        /// OBSERVACIÓN 1 & REQUERIMIENTO 2:
        /// El administrador puede modificar un vale para eliminar Y agregar elementos.
        /// Al guardar las modificaciones, se solicita re-autorización formal.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrativo)
            {
                MessageBox.Show("La modificación de vales ya existentes solo puede ser realizada por personal administrativo.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (_valeActual == null || _valeActual.Id == 0) return;

            var r = MessageBox.Show(
                $"¿Habilitar modificación del vale #{_valeActual.Id}?\n\nPodrá agregar o quitar artículos. Al guardar se requerirá la contraseña de autorización.",
                "Modificar Vale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                _modoModificacion = true;
                _valeActual.RequiereReautorizacion = true;
                ActualizarEstadoControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_valeActual == null) return;

            if (_valeActual.IdUsuario <= 0)
            {
                MessageBox.Show("Debe especificar un solicitante válido mediante su expediente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExpediente.Focus();
                return;
            }

            if (_valeActual.Movimientos.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un artículo o material al vale.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _valeActual.Materia = txtMateria.Text.Trim();
            _valeActual.Carrera = txtCarrera.Text.Trim();
            _valeActual.Observaciones = txtObservaciones.Text.Trim();
            _valeActual.FechaParaEntregar = dtpFechaEntrega.Value;

            string mensajeDialog = _modoModificacion
                ? $"Modificación del Vale #{_valeActual.Id}: Ingrese credenciales para re-autorizar:"
                : "Autorización de nuevo vale de materiales:";

            using var authDialog = new AutorizacionDialog(mensajeDialog);
            if (authDialog.ShowDialog(this) != DialogResult.OK || authDialog.SupervisorAutorizado == null)
            {
                MessageBox.Show("La operación fue cancelada o no se autorizó.", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idSupervisor = authDialog.SupervisorAutorizado.Id;
            bool ok;
            string error;

            if (_valeActual.Id == 0)
            {
                _valeActual.IdAutorizo = idSupervisor;
                ok = _valeRepository.CrearNuevoVale(_valeActual, out error);
            }
            else
            {
                ok = _valeRepository.ModificarValeConReautorizacion(_valeActual, idSupervisor, out error);
            }

            if (ok)
            {
                string msgExito = _modoModificacion
                    ? $"¡El Vale #{_valeActual.Id} fue modificado y re-autorizado exitosamente por {authDialog.SupervisorAutorizado.Nombre}!"
                    : $"¡Vale #{_valeActual.Id} creado y autorizado exitosamente por {authDialog.SupervisorAutorizado.Nombre}!";

                MessageBox.Show(msgExito, "Guardado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _modoModificacion = false;
                CargarVale(_valeActual.Id);
            }
            else
            {
                MessageBox.Show($"Error al guardar el vale: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (_valeActual == null || _valeActual.Id == 0) return;

            using var authDialog = new AutorizacionDialog($"Devolución de Vale #{_valeActual.Id}: Ingrese credenciales del administrativo que recibe:");
            if (authDialog.ShowDialog(this) != DialogResult.OK || authDialog.SupervisorAutorizado == null)
            {
                return;
            }

            foreach (var m in _valeActual.Movimientos)
            {
                if (m.Recibido <= 0) m.Recibido = m.Cantidad;
            }

            if (_valeRepository.RegistrarRecepcion(_valeActual.Id, authDialog.SupervisorAutorizado.Id, _valeActual.Movimientos, out string error))
            {
                MessageBox.Show($"Recepción de materiales registrada por {authDialog.SupervisorAutorizado.Nombre}.", "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVale(_valeActual.Id);
            }
            else
            {
                MessageBox.Show($"Error al registrar devolución: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoVale();
        }

        private void btnBuscarVale_Click(object sender, EventArgs e)
        {
            string idStr = txtBuscarIdVale.Text.Trim();
            if (int.TryParse(idStr, out int vid))
            {
                CargarVale(vid);
            }
            else
            {
                MessageBox.Show("Ingrese un número de vale válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResumenDiario_Click(object sender, EventArgs e)
        {
            using var resumenForm = new ResumenDiarioForm();
            resumenForm.EstablecerFecha(_valeActual?.Fecha ?? DateTime.Today);
            resumenForm.ShowDialog(this);
        }

        /// <summary>
        /// OBSERVACIÓN 1: Permite cambiar de usuario o cerrar sesión inmediatamente
        /// sin tener que cerrar forzadamente la aplicación.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionActual.CerrarSesion();
            Close();
        }
    }
}
