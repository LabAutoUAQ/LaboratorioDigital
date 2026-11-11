using System;
using System.Drawing;
using System.Windows.Forms;

namespace LaboratorioDeAutomatizacion_Almacen.Services
{
    public static class TemaVisual
    {
        // Paleta de Colores: Blancos, Grises y Rojos
        public static readonly Color Blanco = Color.FromArgb(255, 255, 255);
        public static readonly Color FondoApp = Color.FromArgb(249, 250, 251);       // #F9FAFB Gris casi blanco
        public static readonly Color GrisSuperficie = Color.FromArgb(243, 244, 246); // #F3F4F6 Gris suave
        public static readonly Color GrisBorde = Color.FromArgb(229, 231, 235);      // #E5E7EB Gris de bordes
        public static readonly Color GrisTextoMuted = Color.FromArgb(107, 114, 128); // #6B7280 Gris texto secundario
        public static readonly Color TextoPrincipal = Color.FromArgb(17, 24, 39);    // #111827 Gris oscuro casi negro

        // Acento Rojo
        public static readonly Color RojoPrimario = Color.FromArgb(185, 28, 28);     // #B91C1C Rojo oscuro moderno
        public static readonly Color RojoHover = Color.FromArgb(153, 27, 27);        // #991B1B Rojo intenso al pasar ratón
        public static readonly Color RojoSuave = Color.FromArgb(254, 242, 242);       // #FEF2F2 Fondo rojo muy suave
        public static readonly Color RojoBorde = Color.FromArgb(248, 113, 113);      // #F87171 Borde rojo tenue

        // Fuentes estándar modernas
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 13.5f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 10.5f, FontStyle.Regular);
        public static readonly Font FuenteNormal = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FuentePequena = new Font("Segoe UI", 8.5f, FontStyle.Regular);

        public static void AplicarTemaFormulario(Form form)
        {
            form.BackColor = FondoApp;
            form.ForeColor = TextoPrincipal;
            form.Font = FuenteNormal;
        }

        public static void AplicarBotonPrimario(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = RojoPrimario;
            btn.ForeColor = Blanco;
            btn.Font = FuenteNegrita;
            btn.Cursor = Cursors.Hand;
            btn.Height = Math.Max(btn.Height, 32);

            btn.MouseEnter -= BtnPrimario_MouseEnter;
            btn.MouseLeave -= BtnPrimario_MouseLeave;
            btn.MouseEnter += BtnPrimario_MouseEnter;
            btn.MouseLeave += BtnPrimario_MouseLeave;
        }

        private static void BtnPrimario_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Enabled) b.BackColor = RojoHover;
        }

        private static void BtnPrimario_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Enabled) b.BackColor = RojoPrimario;
        }

        public static void AplicarBotonSecundario(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = GrisBorde;
            btn.BackColor = Blanco;
            btn.ForeColor = TextoPrincipal;
            btn.Font = FuenteNormal;
            btn.Cursor = Cursors.Hand;
            btn.Height = Math.Max(btn.Height, 32);

            btn.MouseEnter -= BtnSecundario_MouseEnter;
            btn.MouseLeave -= BtnSecundario_MouseLeave;
            btn.MouseEnter += BtnSecundario_MouseEnter;
            btn.MouseLeave += BtnSecundario_MouseLeave;
        }

        private static void BtnSecundario_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Enabled) b.BackColor = GrisSuperficie;
        }

        private static void BtnSecundario_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button b && b.Enabled) b.BackColor = Blanco;
        }

        public static void AplicarEstiloGrid(DataGridView grid)
        {
            grid.BackgroundColor = Blanco;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = GrisBorde;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowTemplate.Height = 32;
            grid.Font = FuenteNormal;

            // Encabezados
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 36;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = GrisSuperficie;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextoPrincipal;
            grid.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            // Filas
            grid.DefaultCellStyle.BackColor = Blanco;
            grid.DefaultCellStyle.ForeColor = TextoPrincipal;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.DefaultCellStyle.SelectionBackColor = RojoSuave;
            grid.DefaultCellStyle.SelectionForeColor = RojoHover;

            // Alternadas
            grid.AlternatingRowsDefaultCellStyle.BackColor = FondoApp;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = TextoPrincipal;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = RojoSuave;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = RojoHover;
        }

        public static void AplicarPanelCabecera(Panel panel, Label lblTitulo, Label? lblSub = null)
        {
            panel.BackColor = Blanco;
            panel.BorderStyle = BorderStyle.None;

            lblTitulo.Font = FuenteTitulo;
            lblTitulo.ForeColor = RojoPrimario;

            if (lblSub != null)
            {
                lblSub.Font = FuentePequena;
                lblSub.ForeColor = GrisTextoMuted;
            }
        }
    }
}

