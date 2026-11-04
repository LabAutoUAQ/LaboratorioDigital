using System;
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
        private InventarioItem? _itemSeleccionado;

        public InventarioForm()
        {
            InitializeComponent();
            _inventarioRepo = new InventarioRepository();
            ConfigurarGrid();
            CargarInventario();
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
                Width = 260,
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
                Width = 70,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Localizacion",
                HeaderText = "Localización",
                Width = 120,
                ReadOnly = true
            });

            dgvInventario.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                Width = 150,
                ReadOnly = true
            });
        }

        public void CargarInventario()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                bool soloExistencia = chkSoloExistencia.Checked;
                string filtro = txtFiltro.Text.Trim();
                var items = _inventarioRepo.ObtenerTodos(soloExistencia, filtro);
                dgvInventario.DataSource = items;
                lblTotalItems.Text = $"Total artículos: {items.Count} | Existencia total sumada: {items.Sum(i => i.Cantidad)}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow?.DataBoundItem is InventarioItem item)
            {
                _itemSeleccionado = item;
                lblDetalleCodigo.Text = $"Código: {item.Codigo}";
                lblDetalleDesc.Text = item.Descripcion;
                lblDetalleExistencia.Text = $"Existencia: {item.Cantidad} {item.Unidad}";
                lblDetalleUbicacion.Text = $"Ubicación: {item.Localizacion}";

                CargarImagenItem(item);
                btnCargarFoto.Enabled = true;
            }
            else
            {
                _itemSeleccionado = null;
                picFoto.Image?.Dispose();
                picFoto.Image = null;
                btnCargarFoto.Enabled = false;
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

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            if (_itemSeleccionado == null) return;

            using var ofd = new OpenFileDialog();
            ofd.Title = $"Seleccionar imagen para { _itemSeleccionado.Descripcion }";
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

        /// <summary>
        /// SOLUCIÓN OBSERVACIÓN NO. 2:
        /// Importación de CSV respetando y persistiendo la cantidad/existencia indicada.
        /// </summary>
        private void btnImportarCsv_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar archivo CSV de inventario";
            ofd.Filter = "Archivos CSV (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt";

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            var r = MessageBox.Show(
                "¿Desea VACIAR el inventario anterior antes de cargar el nuevo archivo CSV?\n\n- 'Sí': Elimina los artículos anteriores e inserta los del CSV con sus existencias.\n- 'No': Conserva los actuales y añade los nuevos del archivo.",
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
                    $"¡Se importaron correctamente {total} artículos con su existencia real asignada!\n\nLas existencias están ahora disponibles inmediatamente en inventario.",
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

        private void btnVaciarInventario_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(
                "¿Está seguro de que desea eliminar TODO el contenido del inventario?\nEsta acción no se puede deshacer.",
                "Confirmar vaciado de inventario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                if (_inventarioRepo.VaciarInventario(out string error))
                {
                    MessageBox.Show("El inventario ha sido vaciado con éxito.", "Inventario Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                else
                {
                    MessageBox.Show($"Error al vaciar inventario: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarInventario();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void chkSoloExistencia_CheckedChanged(object sender, EventArgs e)
        {
            CargarInventario();
        }
    }
}

