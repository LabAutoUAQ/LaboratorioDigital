using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Models;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    public class AjusteStockDialog : Form
    {
        public decimal NuevaCantidad => numCantidad.Value;
        public string Motivo => cmbMotivo.Text.Trim();

        private NumericUpDown numCantidad = null!;
        private ComboBox cmbMotivo = null!;
        private Button btnAplicar = null!;
        private Button btnCancelar = null!;

        public AjusteStockDialog(InventarioItem item)
        {
            TemaVisual.AplicarTemaFormulario(this);

            Text = $"Ajustar Existencia - {item.Codigo}";
            ClientSize = new Size(420, 360);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = TemaVisual.Blanco
            };
            var lblTitulo = new Label
            {
                Text = "Ajuste Rápido de Existencias",
                Location = new Point(20, 12),
                AutoSize = true
            };
            var lblSub = new Label
            {
                Text = "Actualiza el stock y genera el registro en movimientos automáticamente",
                Location = new Point(20, 36),
                AutoSize = true
            };
            TemaVisual.AplicarPanelCabecera(pnlHeader, lblTitulo, lblSub);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSub);

            int top = 75;

            var lblMaterial = new Label
            {
                Text = $"Material: {item.Codigo} - {item.Descripcion}",
                Location = new Point(25, top),
                Width = 370,
                Font = TemaVisual.FuenteNegrita,
                ForeColor = TemaVisual.TextoPrincipal
            };
            top += 25;

            var lblStockActual = new Label
            {
                Text = $"Existencia actual en almacén: {item.Cantidad} {item.Unidad}",
                Location = new Point(25, top),
                Width = 370,
                Font = TemaVisual.FuenteNormal,
                ForeColor = TemaVisual.GrisTextoMuted
            };
            top += 35;

            var lblNueva = new Label
            {
                Text = "Nueva Cantidad / Existencia Real:",
                Location = new Point(25, top),
                AutoSize = true,
                Font = TemaVisual.FuenteNormal
            };
            top += 22;

            numCantidad = new NumericUpDown
            {
                Location = new Point(25, top),
                Width = 370,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Minimum = 0,
                Maximum = 99999,
                DecimalPlaces = 0,
                Value = Math.Max(0, item.Cantidad)
            };
            top += 40;

            var lblMotivo = new Label
            {
                Text = "Motivo del Ajuste (se guardará en historial de movimientos):",
                Location = new Point(25, top),
                AutoSize = true,
                Font = TemaVisual.FuenteNormal
            };
            top += 22;

            cmbMotivo = new ComboBox
            {
                Location = new Point(25, top),
                Width = 370,
                Font = TemaVisual.FuenteNormal
            };
            cmbMotivo.Items.AddRange(new object[]
            {
                "Conteo físico / Corrección de inventario",
                "Entrada directa / Compra de material",
                "Donación recibida",
                "Merma / Material dañado o extraviado",
                "Devolución especial",
                "Otro ajuste autorizado"
            });
            cmbMotivo.SelectedIndex = 0;
            top += 50;

            btnAplicar = new Button
            {
                Text = "⚡ Aplicar y Guardar",
                Location = new Point(215, top),
                Width = 180,
                Height = 36
            };
            TemaVisual.AplicarBotonPrimario(btnAplicar);
            btnAplicar.Click += (s, e) =>
            {
                DialogResult = DialogResult.OK;
                Close();
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(25, top),
                Width = 180,
                Height = 36
            };
            TemaVisual.AplicarBotonSecundario(btnCancelar);
            btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[]
            {
                pnlHeader,
                lblMaterial,
                lblStockActual,
                lblNueva,
                numCantidad,
                lblMotivo,
                cmbMotivo,
                btnAplicar,
                btnCancelar
            });
        }
    }
}

