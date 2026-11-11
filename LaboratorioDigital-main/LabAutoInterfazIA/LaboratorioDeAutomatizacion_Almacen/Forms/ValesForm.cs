using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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

        private List<InventarioItem> _catalogoMateriales = new();
        private Vale? _valeActual;
        private bool _modoModificacion = false;

        public ValesForm(int idValeInicial = 0)
        {
            InitializeComponent();
            _valeRepository = new ValeRepository();
            _usuarioRepository = new UsuarioRepository();
            _inventarioRepository = new InventarioRepository();
            _impresionService = new ImpresionService();

            TemaVisual.AplicarTemaFormulario(this);
            TemaVisual.AplicarEstiloGrid(dgvMateriales);
            TemaVisual.AplicarBotonPrimario(btnGuardar);
            TemaVisual.AplicarBotonPrimario(btnAgregarItem);
            TemaVisual.AplicarBotonSecundario(btnNuevo);
            TemaVisual.AplicarBotonSecundario(btnRegistrarDevolucion);
            TemaVisual.AplicarBotonSecundario(btnEliminarItem);
            TemaVisual.AplicarBotonSecundario(btnBuscarExpediente);
            TemaVisual.AplicarBotonSecundario(btnResumenDiario);
            TemaVisual.AplicarBotonSecundario(btnCerrarSesion);
            TemaVisual.AplicarBotonSecundario(btnValePrimero);
            TemaVisual.AplicarBotonSecundario(btnValeAnterior);
            TemaVisual.AplicarBotonSecundario(btnValeSiguiente);
            TemaVisual.AplicarBotonSecundario(btnValeUltimo);

            ConfigurarGrid();
            CargarCatalogoMateriales();
            ConfigurarEventos();

            if (idValeInicial > 0)
            {
                CargarVale(idValeInicial);
            }
            else
            {
                // Si el usuario es prestatario, verificar primero si tiene un vale vigente
                if (!SesionActual.EsAdministrativo && SesionActual.UsuarioLogueado != null)
                {
                    var valeVigente = _valeRepository.ObtenerValeVigentePorUsuario(SesionActual.UsuarioLogueado.Id);
                    if (valeVigente != null)
                    {
                        CargarVale(valeVigente.Id);
                    }
                    else
                    {
                        NuevoVale();
                    }
                }
                else
                {
                    // Si es Almacenista/Director, cargar por defecto el último vale registrado o uno nuevo si no hay
                    int ultimoId = _valeRepository.ObtenerUltimoIdVale();
                    if (ultimoId > 0)
                    {
                        CargarVale(ultimoId);
                    }
                    else
                    {
                        NuevoVale();
                    }
                }
            }
        }

        private void ConfigurarGrid()
        {
            dgvMateriales.AutoGenerateColumns = false;
            dgvMateriales.Columns.Clear();

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código / Barras",
                Width = 130,
                ReadOnly = true
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción del Material",
                Width = 340,
                ReadOnly = true
            });

            dgvMateriales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Width = 90
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
                Width = 240
            });
        }

        private void CargarCatalogoMateriales()
        {
            try
            {
                _catalogoMateriales = _inventarioRepository.ObtenerTodos(soloConExistencia: false);

                cmbMateriales.DataSource = null;
                cmbMateriales.DataSource = _catalogoMateriales.OrderBy(m => m.Descripcion).ToList();
                cmbMateriales.DisplayMember = "Descripcion";
                cmbMateriales.ValueMember = "Id";

                if (cmbMateriales.Items.Count > 0) cmbMateriales.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar materiales: {ex.Message}");
            }
        }

        private void ConfigurarEventos()
        {
            // SOLUCIÓN A OBSERVACIÓN: Soporte nativo para lector de código de barras
            txtCodigoBarras.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ProcesarEscaneoCodigoBarras();
                }
            };

            // SOLUCIÓN A OBSERVACIÓN: Flechas de navegación entre vales
            btnValePrimero.Click += (s, e) => NavegarVale(NavegacionDireccion.Primero);
            btnValeAnterior.Click += (s, e) => NavegarVale(NavegacionDireccion.Anterior);
            btnValeSiguiente.Click += (s, e) => NavegarVale(NavegacionDireccion.Siguiente);
            btnValeUltimo.Click += (s, e) => NavegarVale(NavegacionDireccion.Ultimo);

            txtBuscarIdVale.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (int.TryParse(txtBuscarIdVale.Text.Trim(), out int idBuscado))
                    {
                        CargarVale(idBuscado);
                    }
                }
            };

            btnBuscarExpediente.Click += BtnBuscarExpediente_Click;
            txtExpediente.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnBuscarExpediente_Click(s, e);
                }
            };

            btnAgregarItem.Click += (s, e) => AgregarMaterialDesdeCombo();
            btnEliminarItem.Click += BtnEliminarItem_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnRegistrarDevolucion.Click += BtnRegistrarDevolucion_Click;
            btnNuevo.Click += (s, e) => NuevoVale();
            btnResumenDiario.Click += BtnResumenDiario_Click;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
        }

        private enum NavegacionDireccion { Primero, Anterior, Siguiente, Ultimo }

        private void NavegarVale(NavegacionDireccion direccion)
        {
            int actualId = _valeActual?.Id ?? 0;
            int destinoId = 0;

            switch (direccion)
            {
                case NavegacionDireccion.Primero:
                    destinoId = _valeRepository.ObtenerPrimerIdVale();
                    break;
                case NavegacionDireccion.Anterior:
                    destinoId = _valeRepository.ObtenerIdValeAnterior(actualId);
                    if (destinoId <= 0)
                    {
                        MessageBox.Show("Ya se encuentra en el primer vale registrado.", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case NavegacionDireccion.Siguiente:
                    destinoId = _valeRepository.ObtenerIdValeSiguiente(actualId);
                    if (destinoId <= 0)
                    {
                        MessageBox.Show("Ya se encuentra en el último vale registrado.", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case NavegacionDireccion.Ultimo:
                    destinoId = _valeRepository.ObtenerUltimoIdVale();
                    break;
            }

            if (destinoId > 0)
            {
                CargarVale(destinoId);
            }
            else
            {
                MessageBox.Show("No hay vales disponibles para mostrar.", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO / OBSERVACIÓN:
        /// Captura automática por lector de código de barras.
        /// </summary>
        private void ProcesarEscaneoCodigoBarras()
        {
            string codigo = txtCodigoBarras.Text.Trim();
            if (string.IsNullOrEmpty(codigo)) return;

            // 1. Buscar en caché local o base de datos
            InventarioItem? item = _catalogoMateriales.FirstOrDefault(m => string.Equals(m.Codigo?.Trim(), codigo, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                item = _inventarioRepository.BuscarPorCodigo(codigo);
                if (item != null)
                {
                    _catalogoMateriales.Add(item);
                }
            }

            // Si aún no se encuentra, intentar coincidencia aproximada
            if (item == null)
            {
                item = BusquedaFuzzyService.FiltrarInventario(_catalogoMateriales, codigo, 0.70).FirstOrDefault();
            }

            if (item == null)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show($"No se encontró ningún material registrado con el código de barras:\n'{codigo}'", "Código No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.SelectAll();
                txtCodigoBarras.Focus();
                return;
            }

            decimal cant = numCantidad.Value;
            if (cant <= 0) cant = 1;

            if (_valeActual == null) NuevoVale();

            // Verificar si el material ya está en el vale
            var movExistente = _valeActual!.Movimientos.FirstOrDefault(m => m.IdInventario == item.Id || string.Equals(m.Codigo?.Trim(), item.Codigo?.Trim(), StringComparison.OrdinalIgnoreCase));
            if (movExistente != null)
            {
                movExistente.Cantidad += cant;
            }
            else
            {
                _valeActual.Movimientos.Add(new ValeMovimiento
                {
                    IdInventario = item.Id,
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion,
                    Cantidad = cant,
                    Unidad = item.Unidad,
                    Observaciones = txtItemObs.Text.Trim()
                });
            }

            if (_valeActual.Id > 0)
            {
                _modoModificacion = true;
                _valeActual.RequiereReautorizacion = true;
            }

            SystemSounds.Asterisk.Play();
            ActualizarGridMateriales();
            ActualizarEstadoControles();

            // Dejar el campo limpio y con foco listo para el siguiente escaneo
            txtCodigoBarras.Clear();
            numCantidad.Value = 1;
            txtItemObs.Clear();
            txtCodigoBarras.Focus();
        }

        private void AgregarMaterialDesdeCombo()
        {
            if (cmbMateriales.SelectedItem is not InventarioItem item)
            {
                MessageBox.Show("Seleccione un material de la lista o escanee su código de barras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
                return;
            }

            txtCodigoBarras.Text = item.Codigo;
            ProcesarEscaneoCodigoBarras();
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
            txtBuscarIdVale.Text = _valeActual.Id.ToString();
            txtFecha.Text = _valeActual.Fecha.ToString("dd/MM/yyyy HH:mm");
            dtpFechaEntrega.Value = _valeActual.FechaParaEntregar ?? DateTime.Now.AddDays(1);
            txtExpediente.Text = _valeActual.ExpedienteUsuario;
            txtNombreSolicitante.Text = _valeActual.NombreUsuario;
            txtEmail.Text = _valeActual.EmailUsuario;
            txtCelular.Text = _valeActual.CelularUsuario;
            txtCarrera.Text = _valeActual.Carrera;
            txtMateria.Text = _valeActual.Materia;
            txtObservaciones.Text = _valeActual.Observaciones;

            string autorizo = string.IsNullOrEmpty(_valeActual.NombreAutorizo) ? "Pendiente" : _valeActual.NombreAutorizo;
            string recibio = string.IsNullOrEmpty(_valeActual.NombreRecibio) ? "Pendiente" : _valeActual.NombreRecibio;
            lblInfoAdmin.Text = $"Autorizado por: {autorizo}  |  Recibió devolución: {recibio}";

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

            // Se permite agregar materiales si es un vale nuevo o si está activo sin concluir
            bool permitirCaptura = !estaRecibido || esNuevo || _modoModificacion;

            pnlCapturaMaterial.Enabled = permitirCaptura;
            btnEliminarItem.Enabled = permitirCaptura;
            txtMateria.ReadOnly = estaRecibido;
            txtObservaciones.ReadOnly = estaRecibido;
            dtpFechaEntrega.Enabled = !estaRecibido;

            btnGuardar.Enabled = permitirCaptura;
            btnRegistrarDevolucion.Enabled = esAdmin && !esNuevo && estaAutorizado && !estaRecibido;

            if (_modoModificacion || (_valeActual.Id > 0 && _valeActual.RequiereReautorizacion))
            {
                lblBadgeEstado.Text = "⚠ MODIFICACIÓN ACTIVA (Guardar requerirá autorización)";
                lblBadgeEstado.ForeColor = TemaVisual.RojoPrimario;
            }
            else if (estaRecibido)
            {
                lblBadgeEstado.Text = "✔ VALE ENTREGADO / CONCLUIDO";
                lblBadgeEstado.ForeColor = Color.DarkGreen;
            }
            else if (estaAutorizado)
            {
                lblBadgeEstado.Text = "✔ EN PRÉSTAMO VIGENTE (Puede escanear más artículos)";
                lblBadgeEstado.ForeColor = Color.FromArgb(30, 64, 175);
            }
            else
            {
                lblBadgeEstado.Text = "NUEVO VALE (Listo para escanear materiales)";
                lblBadgeEstado.ForeColor = TemaVisual.GrisTextoMuted;
            }
        }

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
            txtBuscarIdVale.Text = "";
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtExpediente.Text = "";
            txtNombreSolicitante.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCarrera.Text = "";
            txtMateria.Text = "";
            txtObservaciones.Text = "";
            lblInfoAdmin.Text = "Autorizado por: (Pendiente)  |  Recibió: (Pendiente)";

            // Si es un prestatario que inició sesión, precargar automáticamente todos sus datos
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
                txtEmail.Text = u.Email;
                txtCelular.Text = u.Celular;
            }

            ActualizarGridMateriales();
            ActualizarEstadoControles();

            if (SesionActual.EsAdministrativo) txtExpediente.Focus();
            else txtCodigoBarras.Focus();
        }

        private void BtnBuscarExpediente_Click(object? sender, EventArgs e)
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
                MessageBox.Show("No se encontró ningún usuario con ese número de expediente.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar condiciones negativas
            if (usuario.Estado == EstadoUsuario.Baja)
            {
                MessageBox.Show("El usuario se encuentra dado de baja en el sistema.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (usuario.Estado == EstadoUsuario.Suspendido)
            {
                MessageBox.Show("El usuario se encuentra suspendido del almacén por infracción.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario.TieneAdeudos)
            {
                MessageBox.Show($"El usuario {usuario.Nombre} tiene adeudos pendientes de vales anteriores vencidos.\nDebe acudir a ventanilla del almacén.", "Adeudo Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // REQUERIMIENTO: Abrir de manera automática el vale vigente si existe uno en curso
            var valeVigente = _valeRepository.ObtenerValeVigentePorUsuario(usuario.Id);
            if (valeVigente != null)
            {
                MessageBox.Show($"El usuario {usuario.Nombre} ya cuenta con un vale vigente activo (Folio #{valeVigente.Id}).\nSe ha abierto automáticamente para su consulta o adición de materiales.", "Vale Activo Vigente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVale(valeVigente.Id);
                txtCodigoBarras.Focus();
                return;
            }

            // Si no tiene vale vigente, precargar automáticamente todos sus datos
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
                txtEmail.Text = usuario.Email;
                txtCelular.Text = usuario.Celular;
            }

            txtMateria.Focus();
        }

        private void BtnEliminarItem_Click(object? sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow?.DataBoundItem is ValeMovimiento mov)
            {
                _valeActual?.Movimientos.Remove(mov);

                if (_valeActual != null && _valeActual.Id > 0)
                {
                    _modoModificacion = true;
                    _valeActual.RequiereReautorizacion = true;
                }

                ActualizarGridMateriales();
                ActualizarEstadoControles();
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
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
                MessageBox.Show("Debe agregar al menos un artículo o material al vale escaneando su código de barras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
                return;
            }

            _valeActual.Materia = txtMateria.Text.Trim();
            _valeActual.Carrera = txtCarrera.Text.Trim();
            _valeActual.Observaciones = txtObservaciones.Text.Trim();
            _valeActual.FechaParaEntregar = dtpFechaEntrega.Value;

            bool esNuevo = _valeActual.Id == 0;
            string mensajeDialog = (!esNuevo)
                ? $"Modificación del Vale #{_valeActual.Id}: Ingrese credenciales del administrativo para re-autorizar:"
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

            if (esNuevo)
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
                string msgExito = (!esNuevo)
                    ? $"¡El Vale #{_valeActual.Id} fue modificado y re-autorizado exitosamente por {authDialog.SupervisorAutorizado.Nombre}!"
                    : $"¡Vale #{_valeActual.Id} creado y autorizado exitosamente por {authDialog.SupervisorAutorizado.Nombre}!";

                MessageBox.Show(msgExito, "Guardado con éxito en Oracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _modoModificacion = false;
                CargarVale(_valeActual.Id);
            }
            else
            {
                MessageBox.Show($"Error al guardar el vale en base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistrarDevolucion_Click(object? sender, EventArgs e)
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
                MessageBox.Show($"Error al registrar devolución en base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResumenDiario_Click(object? sender, EventArgs e)
        {
            using var resumenForm = new ResumenDiarioForm();
            resumenForm.EstablecerFecha(_valeActual?.Fecha ?? DateTime.Today);
            resumenForm.ShowDialog(this);
        }

        private void BtnCerrarSesion_Click(object? sender, EventArgs e)
        {
            SesionActual.CerrarSesion();
            Close();
        }
    }
}
