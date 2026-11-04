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
            panelHeader = new System.Windows.Forms.Panel();
            btnVaciarInventario = new System.Windows.Forms.Button();
            btnImportarCsv = new System.Windows.Forms.Button();
            btnBuscar = new System.Windows.Forms.Button();
            txtFiltro = new System.Windows.Forms.TextBox();
            lblFiltro = new System.Windows.Forms.Label();
            chkSoloExistencia = new System.Windows.Forms.CheckBox();
            lblTitulo = new System.Windows.Forms.Label();
            dgvInventario = new System.Windows.Forms.DataGridView();
            panelDerecho = new System.Windows.Forms.Panel();
            btnCargarFoto = new System.Windows.Forms.Button();
            lblDetalleUbicacion = new System.Windows.Forms.Label();
            lblDetalleExistencia = new System.Windows.Forms.Label();
            lblDetalleDesc = new System.Windows.Forms.Label();
            lblDetalleCodigo = new System.Windows.Forms.Label();
            lblPanelDetalle = new System.Windows.Forms.Label();
            panelPicContenedor = new System.Windows.Forms.Panel();
            lblSinImagen = new System.Windows.Forms.Label();
            picFoto = new System.Windows.Forms.PictureBox();
            panelFooter = new System.Windows.Forms.Panel();
            lblTotalItems = new System.Windows.Forms.Label();
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
            panelHeader.BackColor = System.Drawing.Color.FromArgb(235, 242, 250);
            panelHeader.Controls.Add(btnVaciarInventario);
            panelHeader.Controls.Add(btnImportarCsv);
            panelHeader.Controls.Add(btnBuscar);
            panelHeader.Controls.Add(txtFiltro);
            panelHeader.Controls.Add(lblFiltro);
            panelHeader.Controls.Add(chkSoloExistencia);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1084, 75);
            panelHeader.TabIndex = 0;
            // 
            // btnVaciarInventario
            // 
            btnVaciarInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnVaciarInventario.ForeColor = System.Drawing.Color.Firebrick;
            btnVaciarInventario.Location = new System.Drawing.Point(920, 20);
            btnVaciarInventario.Name = "btnVaciarInventario";
            btnVaciarInventario.Size = new System.Drawing.Size(150, 32);
            btnVaciarInventario.TabIndex = 6;
            btnVaciarInventario.Text = "🗑 Vaciar Inventario";
            btnVaciarInventario.UseVisualStyleBackColor = true;
            btnVaciarInventario.Click += new System.EventHandler(btnVaciarInventario_Click);
            // 
            // btnImportarCsv
            // 
            btnImportarCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnImportarCsv.BackColor = System.Drawing.Color.ForestGreen;
            btnImportarCsv.ForeColor = System.Drawing.Color.White;
            btnImportarCsv.Location = new System.Drawing.Point(740, 20);
            btnImportarCsv.Name = "btnImportarCsv";
            btnImportarCsv.Size = new System.Drawing.Size(170, 32);
            btnImportarCsv.TabIndex = 5;
            btnImportarCsv.Text = "📥 Importar desde CSV...";
            btnImportarCsv.UseVisualStyleBackColor = false;
            btnImportarCsv.Click += new System.EventHandler(btnImportarCsv_Click);
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(540, 38);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(75, 25);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += new System.EventHandler(btnBuscar_Click);
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new System.Drawing.Point(340, 39);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new System.Drawing.Size(190, 23);
            txtFiltro.TabIndex = 3;
            txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(txtFiltro_KeyDown);
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new System.Drawing.Point(290, 42);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new System.Drawing.Size(45, 15);
            lblFiltro.TabIndex = 2;
            lblFiltro.Text = "Buscar:";
            // 
            // chkSoloExistencia
            // 
            chkSoloExistencia.AutoSize = true;
            chkSoloExistencia.Location = new System.Drawing.Point(18, 41);
            chkSoloExistencia.Name = "chkSoloExistencia";
            chkSoloExistencia.Size = new System.Drawing.Size(164, 19);
            chkSoloExistencia.TabIndex = 1;
            chkSoloExistencia.Text = "Ver solo con existencia > 0";
            chkSoloExistencia.UseVisualStyleBackColor = true;
            chkSoloExistencia.CheckedChanged += new System.EventHandler(chkSoloExistencia_CheckedChanged);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.Navy;
            lblTitulo.Location = new System.Drawing.Point(14, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(377, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inventario de Materiales, Equipos y Herramientas";
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.BackgroundColor = System.Drawing.Color.White;
            dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvInventario.Location = new System.Drawing.Point(0, 75);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new System.Drawing.Size(764, 455);
            dgvInventario.TabIndex = 1;
            dgvInventario.SelectionChanged += new System.EventHandler(dgvInventario_SelectionChanged);
            // 
            // panelDerecho
            // 
            panelDerecho.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            panelDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDerecho.Controls.Add(btnCargarFoto);
            panelDerecho.Controls.Add(lblDetalleUbicacion);
            panelDerecho.Controls.Add(lblDetalleExistencia);
            panelDerecho.Controls.Add(lblDetalleDesc);
            panelDerecho.Controls.Add(lblDetalleCodigo);
            panelDerecho.Controls.Add(lblPanelDetalle);
            panelDerecho.Controls.Add(panelPicContenedor);
            panelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            panelDerecho.Location = new System.Drawing.Point(764, 75);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Size = new System.Drawing.Size(320, 455);
            panelDerecho.TabIndex = 2;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            btnCargarFoto.Enabled = false;
            btnCargarFoto.Location = new System.Drawing.Point(15, 385);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new System.Drawing.Size(290, 30);
            btnCargarFoto.TabIndex = 6;
            btnCargarFoto.Text = "📷 Cargar / Cambiar Foto...";
            btnCargarFoto.UseVisualStyleBackColor = true;
            btnCargarFoto.Click += new System.EventHandler(btnCargarFoto_Click);
            // 
            // lblDetalleUbicacion
            // 
            lblDetalleUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDetalleUbicacion.Location = new System.Drawing.Point(15, 345);
            lblDetalleUbicacion.Name = "lblDetalleUbicacion";
            lblDetalleUbicacion.Size = new System.Drawing.Size(290, 20);
            lblDetalleUbicacion.TabIndex = 5;
            lblDetalleUbicacion.Text = "Ubicación: -";
            // 
            // lblDetalleExistencia
            // 
            lblDetalleExistencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDetalleExistencia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblDetalleExistencia.ForeColor = System.Drawing.Color.DarkGreen;
            lblDetalleExistencia.Location = new System.Drawing.Point(15, 318);
            lblDetalleExistencia.Name = "lblDetalleExistencia";
            lblDetalleExistencia.Size = new System.Drawing.Size(290, 20);
            lblDetalleExistencia.TabIndex = 4;
            lblDetalleExistencia.Text = "Existencia: -";
            // 
            // lblDetalleDesc
            // 
            lblDetalleDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDetalleDesc.Location = new System.Drawing.Point(15, 270);
            lblDetalleDesc.Name = "lblDetalleDesc";
            lblDetalleDesc.Size = new System.Drawing.Size(290, 40);
            lblDetalleDesc.TabIndex = 3;
            lblDetalleDesc.Text = "Descripción...";
            // 
            // lblDetalleCodigo
            // 
            lblDetalleCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDetalleCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDetalleCodigo.Location = new System.Drawing.Point(15, 245);
            lblDetalleCodigo.Name = "lblDetalleCodigo";
            lblDetalleCodigo.Size = new System.Drawing.Size(290, 20);
            lblDetalleCodigo.TabIndex = 2;
            lblDetalleCodigo.Text = "Código: -";
            // 
            // lblPanelDetalle
            // 
            lblPanelDetalle.AutoSize = true;
            lblPanelDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPanelDetalle.Location = new System.Drawing.Point(15, 12);
            lblPanelDetalle.Name = "lblPanelDetalle";
            lblPanelDetalle.Size = new System.Drawing.Size(144, 19);
            lblPanelDetalle.TabIndex = 1;
            lblPanelDetalle.Text = "Fotografía / Muestra";
            // 
            // panelPicContenedor
            // 
            panelPicContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panelPicContenedor.BackColor = System.Drawing.Color.White;
            panelPicContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelPicContenedor.Controls.Add(lblSinImagen);
            panelPicContenedor.Controls.Add(picFoto);
            panelPicContenedor.Location = new System.Drawing.Point(15, 38);
            panelPicContenedor.Name = "panelPicContenedor";
            panelPicContenedor.Size = new System.Drawing.Size(290, 195);
            panelPicContenedor.TabIndex = 0;
            // 
            // lblSinImagen
            // 
            lblSinImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSinImagen.ForeColor = System.Drawing.Color.Gray;
            lblSinImagen.Location = new System.Drawing.Point(0, 0);
            lblSinImagen.Name = "lblSinImagen";
            lblSinImagen.Size = new System.Drawing.Size(288, 193);
            lblSinImagen.TabIndex = 1;
            lblSinImagen.Text = "(Sin fotografía asignada)\nClic abajo para agregar foto.";
            lblSinImagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picFoto
            // 
            picFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            picFoto.Location = new System.Drawing.Point(0, 0);
            picFoto.Name = "picFoto";
            picFoto.Size = new System.Drawing.Size(288, 193);
            picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 0;
            picFoto.TabStop = false;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(lblTotalItems);
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Location = new System.Drawing.Point(0, 530);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1084, 35);
            panelFooter.TabIndex = 3;
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalItems.Location = new System.Drawing.Point(15, 10);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new System.Drawing.Size(19, 15);
            lblTotalItems.TabIndex = 0;
            lblTotalItems.Text = "...";
            // 
            // InventarioForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1084, 565);
            Controls.Add(dgvInventario);
            Controls.Add(panelDerecho);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            MinimumSize = new System.Drawing.Size(950, 500);
            Name = "InventarioForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.CheckBox chkSoloExistencia;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnImportarCsv;
        private System.Windows.Forms.Button btnVaciarInventario;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Panel panelPicContenedor;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblSinImagen;
        private System.Windows.Forms.Label lblPanelDetalle;
        private System.Windows.Forms.Label lblDetalleCodigo;
        private System.Windows.Forms.Label lblDetalleDesc;
        private System.Windows.Forms.Label lblDetalleExistencia;
        private System.Windows.Forms.Label lblDetalleUbicacion;
        private System.Windows.Forms.Button btnCargarFoto;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblTotalItems;
    }
}

