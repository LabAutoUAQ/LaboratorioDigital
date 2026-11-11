namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    partial class InventarioForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnImportarCsv = new Button();
            btnAjustarExistencia = new Button();
            btnModificarMaterial = new Button();
            btnNuevoMaterial = new Button();
            btnBuscar = new Button();
            txtFiltro = new TextBox();
            lblFiltro = new Label();
            chkSoloExistencia = new CheckBox();
            lblTitulo = new Label();
            dgvInventario = new DataGridView();
            panelDerecho = new Panel();
            btnCargarFoto = new Button();
            lblDetalleUbicacion = new Label();
            lblDetalleExistencia = new Label();
            lblDetalleDesc = new Label();
            lblDetalleCodigo = new Label();
            lblPanelDetalle = new Label();
            panelPicContenedor = new Panel();
            lblSinImagen = new Label();
            picFoto = new PictureBox();
            panelFooter = new Panel();
            lblTotalItems = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            panelDerecho.SuspendLayout();
            panelPicContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(btnImportarCsv);
            panelHeader.Controls.Add(btnAjustarExistencia);
            panelHeader.Controls.Add(btnModificarMaterial);
            panelHeader.Controls.Add(btnNuevoMaterial);
            panelHeader.Controls.Add(btnBuscar);
            panelHeader.Controls.Add(txtFiltro);
            panelHeader.Controls.Add(lblFiltro);
            panelHeader.Controls.Add(chkSoloExistencia);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1184, 80);
            panelHeader.TabIndex = 0;
            // 
            // btnImportarCsv
            // 
            btnImportarCsv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImportarCsv.BackColor = Color.White;
            btnImportarCsv.Cursor = Cursors.Hand;
            btnImportarCsv.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnImportarCsv.FlatStyle = FlatStyle.Flat;
            btnImportarCsv.Font = new Font("Segoe UI", 9F);
            btnImportarCsv.ForeColor = Color.FromArgb(31, 41, 55);
            btnImportarCsv.Location = new Point(1025, 20);
            btnImportarCsv.Name = "btnImportarCsv";
            btnImportarCsv.Size = new Size(145, 34);
            btnImportarCsv.TabIndex = 6;
            btnImportarCsv.Text = "📥 Importar CSV...";
            btnImportarCsv.UseVisualStyleBackColor = false;
            // 
            // btnAjustarExistencia
            // 
            btnAjustarExistencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAjustarExistencia.BackColor = Color.White;
            btnAjustarExistencia.Cursor = Cursors.Hand;
            btnAjustarExistencia.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnAjustarExistencia.FlatStyle = FlatStyle.Flat;
            btnAjustarExistencia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAjustarExistencia.ForeColor = Color.FromArgb(185, 28, 28);
            btnAjustarExistencia.Location = new Point(875, 20);
            btnAjustarExistencia.Name = "btnAjustarExistencia";
            btnAjustarExistencia.Size = new Size(144, 34);
            btnAjustarExistencia.TabIndex = 5;
            btnAjustarExistencia.Text = "⚡ Ajustar Stock";
            btnAjustarExistencia.UseVisualStyleBackColor = false;
            // 
            // btnModificarMaterial
            // 
            btnModificarMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificarMaterial.BackColor = Color.White;
            btnModificarMaterial.Cursor = Cursors.Hand;
            btnModificarMaterial.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnModificarMaterial.FlatStyle = FlatStyle.Flat;
            btnModificarMaterial.Font = new Font("Segoe UI", 9F);
            btnModificarMaterial.ForeColor = Color.FromArgb(31, 41, 55);
            btnModificarMaterial.Location = new Point(735, 20);
            btnModificarMaterial.Name = "btnModificarMaterial";
            btnModificarMaterial.Size = new Size(134, 34);
            btnModificarMaterial.TabIndex = 4;
            btnModificarMaterial.Text = "✏ Modificar";
            btnModificarMaterial.UseVisualStyleBackColor = false;
            // 
            // btnNuevoMaterial
            // 
            btnNuevoMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMaterial.BackColor = Color.FromArgb(185, 28, 28);
            btnNuevoMaterial.Cursor = Cursors.Hand;
            btnNuevoMaterial.FlatAppearance.BorderSize = 0;
            btnNuevoMaterial.FlatStyle = FlatStyle.Flat;
            btnNuevoMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevoMaterial.ForeColor = Color.White;
            btnNuevoMaterial.Location = new Point(590, 20);
            btnNuevoMaterial.Name = "btnNuevoMaterial";
            btnNuevoMaterial.Size = new Size(138, 34);
            btnNuevoMaterial.TabIndex = 3;
            btnNuevoMaterial.Text = "➕ Nuevo Material";
            btnNuevoMaterial.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.Location = new Point(485, 42);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 26);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtFiltro
            // 
            txtFiltro.Font = new Font("Segoe UI", 9.5F);
            txtFiltro.Location = new Point(235, 43);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PlaceholderText = "Escriba código o nombre...";
            txtFiltro.Size = new Size(244, 24);
            txtFiltro.TabIndex = 1;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltro.ForeColor = Color.FromArgb(55, 65, 81);
            lblFiltro.Location = new Point(175, 47);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(54, 15);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Buscar:";
            // 
            // chkSoloExistencia
            // 
            chkSoloExistencia.AutoSize = true;
            chkSoloExistencia.Font = new Font("Segoe UI", 9F);
            chkSoloExistencia.ForeColor = Color.FromArgb(55, 65, 81);
            chkSoloExistencia.Location = new Point(18, 46);
            chkSoloExistencia.Name = "chkSoloExistencia";
            chkSoloExistencia.Size = new Size(150, 19);
            chkSoloExistencia.TabIndex = 1;
            chkSoloExistencia.Text = "Solo con existencia > 0";
            chkSoloExistencia.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(185, 28, 28);
            lblTitulo.Location = new Point(14, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(335, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Almacén e Inventario de Materiales";
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.BackgroundColor = Color.White;
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(0, 80);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(864, 520);
            dgvInventario.TabIndex = 1;
            // 
            // panelDerecho
            // 
            panelDerecho.BackColor = Color.White;
            panelDerecho.Controls.Add(btnCargarFoto);
            panelDerecho.Controls.Add(lblDetalleUbicacion);
            panelDerecho.Controls.Add(lblDetalleExistencia);
            panelDerecho.Controls.Add(lblDetalleDesc);
            panelDerecho.Controls.Add(lblDetalleCodigo);
            panelDerecho.Controls.Add(lblPanelDetalle);
            panelDerecho.Controls.Add(panelPicContenedor);
            panelDerecho.Dock = DockStyle.Right;
            panelDerecho.Location = new Point(864, 80);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Padding = new Padding(15);
            panelDerecho.Size = new Size(320, 520);
            panelDerecho.TabIndex = 2;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCargarFoto.BackColor = Color.White;
            btnCargarFoto.Cursor = Cursors.Hand;
            btnCargarFoto.Enabled = false;
            btnCargarFoto.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnCargarFoto.FlatStyle = FlatStyle.Flat;
            btnCargarFoto.Font = new Font("Segoe UI", 9F);
            btnCargarFoto.Location = new Point(15, 410);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(290, 32);
            btnCargarFoto.TabIndex = 6;
            btnCargarFoto.Text = "📷 Cargar / Cambiar Foto...";
            btnCargarFoto.UseVisualStyleBackColor = false;
            // 
            // lblDetalleUbicacion
            // 
            lblDetalleUbicacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalleUbicacion.Font = new Font("Segoe UI", 9F);
            lblDetalleUbicacion.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetalleUbicacion.Location = new Point(15, 370);
            lblDetalleUbicacion.Name = "lblDetalleUbicacion";
            lblDetalleUbicacion.Size = new Size(290, 25);
            lblDetalleUbicacion.TabIndex = 5;
            lblDetalleUbicacion.Text = "Ubicación: -";
            // 
            // lblDetalleExistencia
            // 
            lblDetalleExistencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalleExistencia.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDetalleExistencia.ForeColor = Color.FromArgb(185, 28, 28);
            lblDetalleExistencia.Location = new Point(15, 340);
            lblDetalleExistencia.Name = "lblDetalleExistencia";
            lblDetalleExistencia.Size = new Size(290, 25);
            lblDetalleExistencia.TabIndex = 4;
            lblDetalleExistencia.Text = "Existencia: -";
            // 
            // lblDetalleDesc
            // 
            lblDetalleDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalleDesc.Font = new Font("Segoe UI", 9.5F);
            lblDetalleDesc.ForeColor = Color.FromArgb(31, 41, 55);
            lblDetalleDesc.Location = new Point(15, 285);
            lblDetalleDesc.Name = "lblDetalleDesc";
            lblDetalleDesc.Size = new Size(290, 48);
            lblDetalleDesc.TabIndex = 3;
            lblDetalleDesc.Text = "Descripción...";
            // 
            // lblDetalleCodigo
            // 
            lblDetalleCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalleCodigo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetalleCodigo.ForeColor = Color.FromArgb(55, 65, 81);
            lblDetalleCodigo.Location = new Point(15, 260);
            lblDetalleCodigo.Name = "lblDetalleCodigo";
            lblDetalleCodigo.Size = new Size(290, 20);
            lblDetalleCodigo.TabIndex = 2;
            lblDetalleCodigo.Text = "Código: -";
            // 
            // lblPanelDetalle
            // 
            lblPanelDetalle.AutoSize = true;
            lblPanelDetalle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPanelDetalle.ForeColor = Color.FromArgb(185, 28, 28);
            lblPanelDetalle.Location = new Point(15, 12);
            lblPanelDetalle.Name = "lblPanelDetalle";
            lblPanelDetalle.Size = new Size(147, 19);
            lblPanelDetalle.TabIndex = 1;
            lblPanelDetalle.Text = "Fotografía / Muestra";
            // 
            // panelPicContenedor
            // 
            panelPicContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPicContenedor.BackColor = Color.FromArgb(249, 250, 251);
            panelPicContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelPicContenedor.Controls.Add(lblSinImagen);
            panelPicContenedor.Controls.Add(picFoto);
            panelPicContenedor.Location = new Point(15, 40);
            panelPicContenedor.Name = "panelPicContenedor";
            panelPicContenedor.Size = new Size(290, 205);
            panelPicContenedor.TabIndex = 0;
            // 
            // lblSinImagen
            // 
            lblSinImagen.Dock = DockStyle.Fill;
            lblSinImagen.Font = new Font("Segoe UI", 9F);
            lblSinImagen.ForeColor = Color.FromArgb(156, 163, 175);
            lblSinImagen.Location = new Point(0, 0);
            lblSinImagen.Name = "lblSinImagen";
            lblSinImagen.Size = new Size(288, 203);
            lblSinImagen.TabIndex = 1;
            lblSinImagen.Text = "(Sin fotografía asignada)\nClic abajo para agregar foto.";
            lblSinImagen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picFoto
            // 
            picFoto.Dock = DockStyle.Fill;
            picFoto.Location = new Point(0, 0);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(288, 203);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 0;
            picFoto.TabStop = false;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(243, 244, 246);
            panelFooter.Controls.Add(lblTotalItems);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 600);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1184, 35);
            panelFooter.TabIndex = 3;
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalItems.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotalItems.Location = new Point(15, 10);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new Size(16, 15);
            lblTotalItems.TabIndex = 0;
            lblTotalItems.Text = "...";
            // 
            // InventarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1184, 635);
            Controls.Add(dgvInventario);
            Controls.Add(panelDerecho);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            MinimumSize = new Size(1000, 550);
            Name = "InventarioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario y Materiales - Laboratorio de Automatización";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            panelDerecho.ResumeLayout(false);
            panelDerecho.PerformLayout();
            panelPicContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private CheckBox chkSoloExistencia;
        private Label lblFiltro;
        private TextBox txtFiltro;
        private Button btnBuscar;
        private Button btnImportarCsv;
        private Button btnNuevoMaterial;
        private Button btnModificarMaterial;
        private Button btnAjustarExistencia;
        private DataGridView dgvInventario;
        private Panel panelDerecho;
        private Panel panelPicContenedor;
        private PictureBox picFoto;
        private Label lblSinImagen;
        private Label lblPanelDetalle;
        private Label lblDetalleCodigo;
        private Label lblDetalleDesc;
        private Label lblDetalleExistencia;
        private Label lblDetalleUbicacion;
        private Button btnCargarFoto;
        private Panel panelFooter;
        private Label lblTotalItems;
    }
}
