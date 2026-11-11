using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Models;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    public class MaterialDialog : Form
    {
        public InventarioItem Item { get; private set; }
        public bool EsNuevo { get; }

        private TextBox txtCodigo = null!;
        private TextBox txtDescripcion = null!;
        private NumericUpDown numCantidad = null!;
        private ComboBox cmbUnidad = null!;
        private TextBox txtLocalizacion = null!;
        private TextBox txtObservaciones = null!;
        private Button btnGuardar = null!;
        private Button btnCancelar = null!;

        public MaterialDialog(InventarioItem? itemExistente = null)
        {
            EsNuevo = itemExistente == null;
            Item = itemExistente != null
                ? new InventarioItem
                {
                    Id = itemExistente.Id,
                    Codigo = itemExistente.Codigo,
                    Descripcion = itemExistente.Descripcion,
                    Cantidad = itemExistente.Cantidad,
                    Unidad = itemExistente.Unidad,
                    Localizacion = itemExistente.Localizacion,
                    Observaciones = itemExistente.Observaciones,
                    Estatus = itemExistente.Estatus,
                    Resguardo = itemExistente.Resguardo
                }
                : new InventarioItem { Cantidad = 1, Unidad = "Pza" };

            InicializarComponentes();
            CargarDatos();
        }

        private void InicializarComponentes()
        {
            TemaVisual.AplicarTemaFormulario(this);

            Text = EsNuevo ? "Nuevo Material - Almacén" : $"Modificar Material - ID #{Item.Id}";
            ClientSize = new Size(460, 480);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            // Panel Header
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = TemaVisual.Blanco
            };
            var lblTitulo = new Label
            {
                Text = EsNuevo ? "Alta de Nuevo Material" : "Modificar Datos del Material",
                Location = new Point(20, 12),
                AutoSize = true
            };
            var lblSub = new Label
            {
                Text = "Ingrese los datos que serán guardados directamente en la base de datos",
                Location = new Point(20, 36),
                AutoSize = true
            };
            TemaVisual.AplicarPanelCabecera(pnlHeader, lblTitulo, lblSub);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSub);

            // Campos
            int top = 75;
            int lblX = 25;
            int inputX = 25;
            int inputW = 410;

            // Código
            var lblCod = new Label { Text = "Código / Clave:", Location = new Point(lblX, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            top += 20;
            txtCodigo = new TextBox { Location = new Point(inputX, top), Width = inputW, Font = TemaVisual.FuenteNormal };
            top += 35;

            // Descripción
            var lblDesc = new Label { Text = "Descripción del Material / Herramienta:", Location = new Point(lblX, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            top += 20;
            txtDescripcion = new TextBox { Location = new Point(inputX, top), Width = inputW, Font = TemaVisual.FuenteNormal };
            top += 35;

            // Cantidad y Unidad
            var lblCant = new Label { Text = "Cantidad Inicial:", Location = new Point(lblX, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            var lblUni = new Label { Text = "Unidad de Medida:", Location = new Point(lblX + 210, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            top += 20;

            numCantidad = new NumericUpDown
            {
                Location = new Point(inputX, top),
                Width = 190,
                Font = TemaVisual.FuenteNormal,
                Minimum = 0,
                Maximum = 99999,
                DecimalPlaces = 0,
                Value = 1
            };
            if (!EsNuevo) numCantidad.Enabled = false; // El stock existente se modifica mediante el botón Ajustar Existencias

            cmbUnidad = new ComboBox
            {
                Location = new Point(inputX + 210, top),
                Width = 200,
                Font = TemaVisual.FuenteNormal,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbUnidad.Items.AddRange(new object[] { "Pza", "Mts", "Kgs", "Juego", "Kit", "Caja", "Rollo", "Lote" });
            cmbUnidad.SelectedIndex = 0;
            top += 35;

            // Localización
            var lblLoc = new Label { Text = "Localización / Ubicación en Almacén:", Location = new Point(lblX, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            top += 20;
            txtLocalizacion = new TextBox { Location = new Point(inputX, top), Width = inputW, Font = TemaVisual.FuenteNormal };
            top += 35;

            // Observaciones
            var lblObs = new Label { Text = "Observaciones adicionales:", Location = new Point(lblX, top), AutoSize = true, Font = TemaVisual.FuenteNormal };
            top += 20;
            txtObservaciones = new TextBox { Location = new Point(inputX, top), Width = inputW, Height = 48, Multiline = true, Font = TemaVisual.FuenteNormal };
            top += 60;

            // Botones
            btnGuardar = new Button
            {
                Text = "💾 Guardar en BD",
                Location = new Point(230, top),
                Width = 205,
                Height = 36
            };
            TemaVisual.AplicarBotonPrimario(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(25, top),
                Width = 195,
                Height = 36
            };
            TemaVisual.AplicarBotonSecundario(btnCancelar);
            btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[]
            {
                pnlHeader,
                lblCod, txtCodigo,
                lblDesc, txtDescripcion,
                lblCant, numCantidad,
                lblUni, cmbUnidad,
                lblLoc, txtLocalizacion,
                lblObs, txtObservaciones,
                btnGuardar, btnCancelar
            });
        }

        private void CargarDatos()
        {
            txtCodigo.Text = Item.Codigo;
            txtDescripcion.Text = Item.Descripcion;
            numCantidad.Value = Math.Max(0, Item.Cantidad);

            int index = cmbUnidad.FindStringExact(Item.Unidad);
            if (index >= 0) cmbUnidad.SelectedIndex = index;
            else
            {
                cmbUnidad.Items.Add(Item.Unidad);
                cmbUnidad.SelectedItem = Item.Unidad;
            }

            txtLocalizacion.Text = Item.Localizacion;
            txtObservaciones.Text = Item.Observaciones;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string cod = txtCodigo.Text.Trim();
            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(cod))
            {
                MessageBox.Show("El código del material es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("La descripción del material es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            Item.Codigo = cod;
            Item.Descripcion = desc;
            Item.Cantidad = numCantidad.Value;
            Item.Unidad = cmbUnidad.SelectedItem?.ToString() ?? "Pza";
            Item.Localizacion = txtLocalizacion.Text.Trim();
            Item.Observaciones = txtObservaciones.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

