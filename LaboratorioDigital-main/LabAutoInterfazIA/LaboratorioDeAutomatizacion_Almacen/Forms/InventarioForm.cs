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
    public partial class InventarioForm : Form
    {
        private readonly InventarioRepository _inventarioRepo;
        private List<InventarioItem> _inventarioCache = new();
        private InventarioItem? _itemSeleccionado;

        public InventarioForm()
        {
            InitializeComponent();
            _inventarioRepo = new InventarioRepository();

            TemaVisual.AplicarTemaFormulario(this);
            TemaVisual.AplicarEstiloGrid(dgvInventario);
            TemaVisual.AplicarBotonPrimario(btnNuevoMaterial);
            TemaVisual.AplicarBotonSecundario(btnModificarMaterial);
            TemaVisual.AplicarBotonSecundario(btnAjustarExistencia);
            TemaVisual.AplicarBotonSecundario(btnImportarCsv);
            TemaVisual.AplicarBotonSecundario(btnBuscar);
            TemaVisual.AplicarBotonSecundario(btnCargarFoto);

            ConfigurarPermisosSegunRol();
            ConfigurarGrid();
            ConfigurarEventos();
            CargarInventario();
        }

        private void ConfigurarPermisosSegunRol()
        {
            bool esAdmin = SesionActual.EsAdministrativo; // Director o Almacenista
            btnNuevoMaterial.Enabled = esAdmin;
            btnModificarMaterial.Enabled = esAdmin;
            btnAjustarExistencia.Enabled = esAdmin;
            btnImportarCsv.Enabled = esAdmin;
            btnCargarFoto.Enabled = esAdmin;
        }

        private void ConfigurarGrid()
        {
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.Columns.Clear();

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código",
                Width = 110,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 280,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Existencia",
                Width = 90,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unidad",
                HeaderText = "Unidad",
                Width = 80,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Localizacion",
                HeaderText = "Localización",
                Width = 130,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                Width = 160,
                ReadOnly = true
            });
        }

        private void ConfigurarEventos()
        {
            dgvInventario.SelectionChanged += dgvInventario_SelectionChanged;

            btnBuscar.Click += (s, e) => FiltrarYMostrar();
            txtFiltro.TextChanged += (s, e) => FiltrarYMostrar();
            txtFiltro.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    FiltrarYMostrar();
                }
            };

            chkSoloExistencia.CheckedChanged += (s, e) => FiltrarYMostrar();

            btnNuevoMaterial.Click += BtnNuevoMaterial_Click;
            btnModificarMaterial.Click += BtnModificarMaterial_Click;
            btnAjustarExistencia.Click += BtnAjustarExistencia_Click;
            btnImportarCsv.Click += btnImportarCsv_Click;
            btnCargarFoto.Click += btnCargarFoto_Click;
        }

        public void CargarInventario()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _inventarioCache = _inventarioRepo.ObtenerTodos(soloConExistencia: false, filtro: string.Empty);
                FiltrarYMostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO:
        /// Búsqueda inteligente con tolerancia a errores de escritura (Fuzzy Search)
        /// y filtro rápido por stock.
        /// </summary>
        private void FiltrarYMostrar()
        {
            IEnumerable<InventarioItem> lista = _inventarioCache;

            if (chkSoloExistencia.Checked)
            {
                lista = lista.Where(i => i.Cantidad > 0);
            }

            string filtro = txtFiltro.Text.Trim();
            List<InventarioItem> resultado;

            if (!string.IsNullOrEmpty(filtro))
            {
                resultado = BusquedaFuzzyService.FiltrarInventario(lista, filtro, umbralMinimo: 0.55);
            }
            else
            {
                resultado = lista.OrderBy(i => i.Descripcion).ToList();
            }

            dgvInventario.DataSource = resultado;
            lblTotalItems.Text = $"Artículos mostrados: {resultado.Count} | Existencia total sumada: {resultado.Sum(i => i.Cantidad)}";
        }

        private void dgvInventario_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow?.DataBoundItem is InventarioItem item)
            {
                _itemSeleccionado = item;
                lblDetalleCodigo.Text = $"Código: {item.Codigo}";
                lblDetalleDesc.Text = item.Descripcion;
                lblDetalleExistencia.Text = $"Existencia: {item.Cantidad} {item.Unidad}";
                lblDetalleUbicacion.Text = string.IsNullOrEmpty(item.Localizacion) ? "Ubicación: (No especificada)" : $"Ubicación: {item.Localizacion}";

                CargarImagenItem(item);
                btnCargarFoto.Enabled = SesionActual.EsAdministrativo;
                btnModificarMaterial.Enabled = SesionActual.EsAdministrativo;
                btnAjustarExistencia.Enabled = SesionActual.EsAdministrativo;
            }
            else
            {
                _itemSeleccionado = null;
                picFoto.Image?.Dispose();
                picFoto.Image = null;
                lblSinImagen.Visible = true;
                lblDetalleCodigo.Text = "Código: -";
                lblDetalleDesc.Text = "Seleccione un material para ver detalles.";
                lblDetalleExistencia.Text = "Existencia: -";
                lblDetalleUbicacion.Text = "Ubicación: -";

                btnCargarFoto.Enabled = false;
                btnModificarMaterial.Enabled = false;
                btnAjustarExistencia.Enabled = false;
            }
        }

        private void CargarImagenItem(InventarioItem item)
        {
            try
            {
                picFoto.Image?.Dispose();
                picFoto.Image = null;

                string ruta = item.ObtenerRutaImagen();
                if (!string.IsNullOrEmpty(ruta) && File.Exists(ruta))
                {
                    using var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    picFoto.Image = Image.FromStream(stream);
                    lblSinImagen.Visible = false;
                }
                else
                {
                    lblSinImagen.Visible = true;
                }
            }
            catch
            {
                lblSinImagen.Visible = true;
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO:
        /// Agregar manualmente materiales guardándolos directamente en la base de datos Oracle.
        /// </summary>
        private void BtnNuevoMaterial_Click(object? sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrativo)
            {
                MessageBox.Show("Solo el Almacenista o Director pueden dar de alta materiales.", "Permiso Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new MaterialDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int idUsuario = SesionActual.UsuarioLogueado?.Id ?? 1;
                if (_inventarioRepo.AgregarMaterial(dlg.Item, idUsuario, out int nuevoId, out string error))
                {
                    MessageBox.Show($"¡Material #{nuevoId} '{dlg.Item.Descripcion}' agregado y guardado exitosamente en Oracle!", "Guardado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                else
                {
                    MessageBox.Show($"Error al guardar en base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO:
        /// Modificar materiales guardando cambios directamente en la base de datos Oracle.
        /// </summary>
        private void BtnModificarMaterial_Click(object? sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrativo)
            {
                MessageBox.Show("Solo el Almacenista o Director pueden modificar materiales.", "Permiso Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_itemSeleccionado == null)
            {
                MessageBox.Show("Seleccione un material de la lista para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new MaterialDialog(_itemSeleccionado);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int idUsuario = SesionActual.UsuarioLogueado?.Id ?? 1;
                if (_inventarioRepo.ActualizarMaterial(dlg.Item, idUsuario, out string error))
                {
                    MessageBox.Show("Material actualizado correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar en base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO:
        /// Modificación rápida de existencias con registro automático en movimientos.
        /// </summary>
        private void BtnAjustarExistencia_Click(object? sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrativo)
            {
                MessageBox.Show("Solo el Almacenista o Director pueden ajustar existencias.", "Permiso Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_itemSeleccionado == null)
            {
                MessageBox.Show("Seleccione un material de la lista para ajustar su existencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new AjusteStockDialog(_itemSeleccionado);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int idUsuario = SesionActual.UsuarioLogueado?.Id ?? 1;
                if (_inventarioRepo.ActualizarExistenciaConMovimiento(_itemSeleccionado.Id, dlg.NuevaCantidad, dlg.Motivo, idUsuario, out string error))
                {
                    MessageBox.Show($"Existencia actualizada exitosamente a {dlg.NuevaCantidad} {_itemSeleccionado.Unidad}.\nSe generó automáticamente el registro en la auditoría de movimientos.", "Stock Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la existencia: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCargarFoto_Click(object? sender, EventArgs e)
        {
            if (_itemSeleccionado == null) return;

            using var ofd = new OpenFileDialog();
            ofd.Title = $"Seleccionar imagen para {_itemSeleccionado.Descripcion}";
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos (*.*)|*.*";

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                if (_inventarioRepo.GuardarImagenParaCodigo(_itemSeleccionado.Codigo, ofd.FileName, out string rutaGuardada, out string error))
                {
                    _itemSeleccionado.ImagenPath = rutaGuardada;
                    CargarImagenItem(_itemSeleccionado);
                    MessageBox.Show("Imagen asociada correctamente al elemento.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error al guardar la imagen: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportarCsv_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar archivo CSV de inventario";
            ofd.Filter = "Archivos CSV (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt";

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            var r = MessageBox.Show(
                "¿Desea VACIAR el inventario anterior antes de cargar el nuevo archivo CSV?\n\n- 'Sí': Elimina los artículos anteriores e inserta los del CSV.\n- 'No': Conserva los actuales y añade los nuevos del archivo.",
                "Opciones de Importación",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (r == DialogResult.Cancel) return;
            bool vaciar = (r == DialogResult.Yes);

            int idUsuario = SesionActual.UsuarioLogueado?.Id ?? 1;

            Cursor = Cursors.WaitCursor;
            bool exito = _inventarioRepo.ImportarDesdeCsv(ofd.FileName, vaciar, idUsuario, out int total, out string error);
            Cursor = Cursors.Default;

            if (exito)
            {
                MessageBox.Show(
                    $"¡Se importaron correctamente {total} artículos con su existencia real asignada!\n\nLas existencias están ahora sincronizadas en la base de datos.",
                    "Importación Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                CargarInventario();
            }
            else
            {
                MessageBox.Show($"Error durante la importación: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
