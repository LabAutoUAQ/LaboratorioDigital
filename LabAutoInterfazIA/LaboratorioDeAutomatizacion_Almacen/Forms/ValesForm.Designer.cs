namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    partial class ValesForm
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
            btnCerrarSesion = new System.Windows.Forms.Button();
            btnResumenDiario = new System.Windows.Forms.Button();
            btnBuscarVale = new System.Windows.Forms.Button();
            txtBuscarIdVale = new System.Windows.Forms.TextBox();
            lblBuscarVale = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            panelDatos = new System.Windows.Forms.Panel();
            lblEstadoModo = new System.Windows.Forms.Label();
            txtRecibio = new System.Windows.Forms.TextBox();
            lblRecibio = new System.Windows.Forms.Label();
            txtAutorizo = new System.Windows.Forms.TextBox();
            lblAutorizo = new System.Windows.Forms.Label();
            txtObservaciones = new System.Windows.Forms.TextBox();
            lblObs = new System.Windows.Forms.Label();
            txtMateria = new System.Windows.Forms.TextBox();
            lblMateria = new System.Windows.Forms.Label();
            txtCarrera = new System.Windows.Forms.TextBox();
            lblCarrera = new System.Windows.Forms.Label();
            txtNombreSolicitante = new System.Windows.Forms.TextBox();
            lblNombreSol = new System.Windows.Forms.Label();
            btnBuscarExpediente = new System.Windows.Forms.Button();
            txtExpediente = new System.Windows.Forms.TextBox();
            lblExpediente = new System.Windows.Forms.Label();
            dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            lblFechaEntrega = new System.Windows.Forms.Label();
            txtFecha = new System.Windows.Forms.TextBox();
            lblFecha = new System.Windows.Forms.Label();
            txtValeId = new System.Windows.Forms.TextBox();
            lblValeId = new System.Windows.Forms.Label();
            pnlAgregarMaterial = new System.Windows.Forms.Panel();
            picMiniMaterial = new System.Windows.Forms.PictureBox();
            btnEliminarItem = new System.Windows.Forms.Button();
            btnAgregarItem = new System.Windows.Forms.Button();
            txtItemObs = new System.Windows.Forms.TextBox();
            lblItemObs = new System.Windows.Forms.Label();
            numCantidad = new System.Windows.Forms.NumericUpDown();
            lblCantidad = new System.Windows.Forms.Label();
            cmbMateriales = new System.Windows.Forms.ComboBox();
            lblMaterial = new System.Windows.Forms.Label();
            dgvMateriales = new System.Windows.Forms.DataGridView();
            panelFooter = new System.Windows.Forms.Panel();
            btnRegistrarDevolucion = new System.Windows.Forms.Button();
            btnModificar = new System.Windows.Forms.Button();
            btnGuardar = new System.Windows.Forms.Button();
            btnNuevo = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            panelDatos.SuspendLayout();
            pnlAgregarMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMiniMaterial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(235, 240, 248);
            panelHeader.Controls.Add(btnCerrarSesion);
            panelHeader.Controls.Add(btnResumenDiario);
            panelHeader.Controls.Add(btnBuscarVale);
            panelHeader.Controls.Add(txtBuscarIdVale);
            panelHeader.Controls.Add(lblBuscarVale);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1020, 60);
            panelHeader.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnCerrarSesion.Location = new System.Drawing.Point(865, 14);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new System.Drawing.Size(145, 30);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "🔒 Cambiar Usuario";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += new System.EventHandler(btnCerrarSesion_Click);
            // 
            // btnResumenDiario
            // 
            btnResumenDiario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnResumenDiario.BackColor = System.Drawing.Color.DarkSlateGray;
            btnResumenDiario.ForeColor = System.Drawing.Color.White;
            btnResumenDiario.Location = new System.Drawing.Point(670, 14);
            btnResumenDiario.Name = "btnResumenDiario";
            btnResumenDiario.Size = new System.Drawing.Size(190, 30);
            btnResumenDiario.TabIndex = 4;
            btnResumenDiario.Text = "🖨 Resumen Diario";
            btnResumenDiario.UseVisualStyleBackColor = false;
            btnResumenDiario.Click += new System.EventHandler(btnResumenDiario_Click);
            // 
            // btnBuscarVale
            // 
            btnBuscarVale.Location = new System.Drawing.Point(545, 16);
            btnBuscarVale.Name = "btnBuscarVale";
            btnBuscarVale.Size = new System.Drawing.Size(75, 26);
            btnBuscarVale.TabIndex = 3;
            btnBuscarVale.Text = "Buscar";
            btnBuscarVale.UseVisualStyleBackColor = true;
            btnBuscarVale.Click += new System.EventHandler(btnBuscarVale_Click);
            // 
            // txtBuscarIdVale
            // 
            txtBuscarIdVale.Location = new System.Drawing.Point(445, 18);
            txtBuscarIdVale.Name = "txtBuscarIdVale";
            txtBuscarIdVale.Size = new System.Drawing.Size(95, 23);
            txtBuscarIdVale.TabIndex = 2;
            // 
            // lblBuscarVale
            // 
            lblBuscarVale.AutoSize = true;
            lblBuscarVale.Location = new System.Drawing.Point(365, 21);
            lblBuscarVale.Name = "lblBuscarVale";
            lblBuscarVale.Size = new System.Drawing.Size(74, 15);
            lblBuscarVale.TabIndex = 1;
            lblBuscarVale.Text = "Cargar Vale #";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            lblTitulo.Location = new System.Drawing.Point(14, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(296, 23);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de Préstamo de Materiales";
            // 
            // panelDatos
            // 
            panelDatos.Controls.Add(lblEstadoModo);
            panelDatos.Controls.Add(txtRecibio);
            panelDatos.Controls.Add(lblRecibio);
            panelDatos.Controls.Add(txtAutorizo);
            panelDatos.Controls.Add(lblAutorizo);
            panelDatos.Controls.Add(txtObservaciones);
            panelDatos.Controls.Add(lblObs);
            panelDatos.Controls.Add(txtMateria);
            panelDatos.Controls.Add(lblMateria);
            panelDatos.Controls.Add(txtCarrera);
            panelDatos.Controls.Add(lblCarrera);
            panelDatos.Controls.Add(txtNombreSolicitante);
            panelDatos.Controls.Add(lblNombreSol);
            panelDatos.Controls.Add(btnBuscarExpediente);
            panelDatos.Controls.Add(txtExpediente);
            panelDatos.Controls.Add(lblExpediente);
            panelDatos.Controls.Add(dtpFechaEntrega);
            panelDatos.Controls.Add(lblFechaEntrega);
            panelDatos.Controls.Add(txtFecha);
            panelDatos.Controls.Add(lblFecha);
            panelDatos.Controls.Add(txtValeId);
            panelDatos.Controls.Add(lblValeId);
            panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            panelDatos.Location = new System.Drawing.Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new System.Drawing.Size(1020, 185);
            panelDatos.TabIndex = 1;
            // 
            // lblEstadoModo
            // 
            lblEstadoModo.AutoSize = true;
            lblEstadoModo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblEstadoModo.Location = new System.Drawing.Point(16, 155);
            lblEstadoModo.Name = "lblEstadoModo";
            lblEstadoModo.Size = new System.Drawing.Size(17, 17);
            lblEstadoModo.TabIndex = 21;
            lblEstadoModo.Text = "...";
            // 
            // txtRecibio
            // 
            txtRecibio.BackColor = System.Drawing.Color.WhiteSmoke;
            txtRecibio.Location = new System.Drawing.Point(750, 115);
            txtRecibio.Name = "txtRecibio";
            txtRecibio.ReadOnly = true;
            txtRecibio.Size = new System.Drawing.Size(240, 23);
            txtRecibio.TabIndex = 20;
            // 
            // lblRecibio
            // 
            lblRecibio.AutoSize = true;
            lblRecibio.Location = new System.Drawing.Point(670, 118);
            lblRecibio.Name = "lblRecibio";
            lblRecibio.Size = new System.Drawing.Size(69, 15);
            lblRecibio.TabIndex = 19;
            lblRecibio.Text = "Recibió dev:";
            // 
            // txtAutorizo
            // 
            txtAutorizo.BackColor = System.Drawing.Color.WhiteSmoke;
            txtAutorizo.Location = new System.Drawing.Point(425, 115);
            txtAutorizo.Name = "txtAutorizo";
            txtAutorizo.ReadOnly = true;
            txtAutorizo.Size = new System.Drawing.Size(225, 23);
            txtAutorizo.TabIndex = 18;
            // 
            // lblAutorizo
            // 
            lblAutorizo.AutoSize = true;
            lblAutorizo.Location = new System.Drawing.Point(340, 118);
            lblAutorizo.Name = "lblAutorizo";
            lblAutorizo.Size = new System.Drawing.Size(81, 15);
            lblAutorizo.TabIndex = 17;
            lblAutorizo.Text = "Autorizado por:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new System.Drawing.Point(105, 115);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new System.Drawing.Size(215, 23);
            txtObservaciones.TabIndex = 16;
            // 
            // lblObs
            // 
            lblObs.AutoSize = true;
            lblObs.Location = new System.Drawing.Point(16, 118);
            lblObs.Name = "lblObs";
            lblObs.Size = new System.Drawing.Size(87, 15);
            lblObs.TabIndex = 15;
            lblObs.Text = "Observaciones:";
            // 
            // txtMateria
            // 
            txtMateria.Location = new System.Drawing.Point(750, 77);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new System.Drawing.Size(240, 23);
            txtMateria.TabIndex = 14;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new System.Drawing.Point(670, 80);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new System.Drawing.Size(50, 15);
            lblMateria.TabIndex = 13;
            lblMateria.Text = "Materia:";
            // 
            // txtCarrera
            // 
            txtCarrera.Location = new System.Drawing.Point(425, 77);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.Size = new System.Drawing.Size(225, 23);
            txtCarrera.TabIndex = 12;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Location = new System.Drawing.Point(365, 80);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new System.Drawing.Size(48, 15);
            lblCarrera.TabIndex = 11;
            lblCarrera.Text = "Carrera:";
            // 
            // txtNombreSolicitante
            // 
            txtNombreSolicitante.BackColor = System.Drawing.Color.WhiteSmoke;
            txtNombreSolicitante.Location = new System.Drawing.Point(105, 77);
            txtNombreSolicitante.Name = "txtNombreSolicitante";
            txtNombreSolicitante.ReadOnly = true;
            txtNombreSolicitante.Size = new System.Drawing.Size(215, 23);
            txtNombreSolicitante.TabIndex = 10;
            // 
            // lblNombreSol
            // 
            lblNombreSol.AutoSize = true;
            lblNombreSol.Location = new System.Drawing.Point(16, 80);
            lblNombreSol.Name = "lblNombreSol";
            lblNombreSol.Size = new System.Drawing.Size(65, 15);
            lblNombreSol.TabIndex = 9;
            lblNombreSol.Text = "Solicitante:";
            // 
            // btnBuscarExpediente
            // 
            btnBuscarExpediente.Location = new System.Drawing.Point(905, 38);
            btnBuscarExpediente.Name = "btnBuscarExpediente";
            btnBuscarExpediente.Size = new System.Drawing.Size(85, 25);
            btnBuscarExpediente.TabIndex = 8;
            btnBuscarExpediente.Text = "Buscar Exp";
            btnBuscarExpediente.UseVisualStyleBackColor = true;
            btnBuscarExpediente.Click += new System.EventHandler(btnBuscarExpediente_Click);
            // 
            // txtExpediente
            // 
            txtExpediente.Location = new System.Drawing.Point(750, 40);
            txtExpediente.Name = "txtExpediente";
            txtExpediente.Size = new System.Drawing.Size(145, 23);
            txtExpediente.TabIndex = 7;
            // 
            // lblExpediente
            // 
            lblExpediente.AutoSize = true;
            lblExpediente.Location = new System.Drawing.Point(670, 43);
            lblExpediente.Name = "lblExpediente";
            lblExpediente.Size = new System.Drawing.Size(68, 15);
            lblExpediente.TabIndex = 6;
            lblExpediente.Text = "Expediente:";
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFechaEntrega.Location = new System.Drawing.Point(425, 40);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new System.Drawing.Size(170, 23);
            dtpFechaEntrega.TabIndex = 5;
            // 
            // lblFechaEntrega
            // 
            lblFechaEntrega.AutoSize = true;
            lblFechaEntrega.Location = new System.Drawing.Point(340, 43);
            lblFechaEntrega.Name = "lblFechaEntrega";
            lblFechaEntrega.Size = new System.Drawing.Size(85, 15);
            lblFechaEntrega.TabIndex = 4;
            lblFechaEntrega.Text = "Fecha Entrega:";
            // 
            // txtFecha
            // 
            txtFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            txtFecha.Location = new System.Drawing.Point(180, 40);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new System.Drawing.Size(140, 23);
            txtFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new System.Drawing.Point(135, 43);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new System.Drawing.Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // txtValeId
            // 
            txtValeId.BackColor = System.Drawing.Color.WhiteSmoke;
            txtValeId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            txtValeId.Location = new System.Drawing.Point(60, 40);
            txtValeId.Name = "txtValeId";
            txtValeId.ReadOnly = true;
            txtValeId.Size = new System.Drawing.Size(65, 23);
            txtValeId.TabIndex = 1;
            // 
            // lblValeId
            // 
            lblValeId.AutoSize = true;
            lblValeId.Location = new System.Drawing.Point(16, 43);
            lblValeId.Name = "lblValeId";
            lblValeId.Size = new System.Drawing.Size(43, 15);
            lblValeId.TabIndex = 0;
            lblValeId.Text = "Vale #:";
            // 
            // pnlAgregarMaterial
            // 
            pnlAgregarMaterial.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            pnlAgregarMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlAgregarMaterial.Controls.Add(picMiniMaterial);
            pnlAgregarMaterial.Controls.Add(btnEliminarItem);
            pnlAgregarMaterial.Controls.Add(btnAgregarItem);
            pnlAgregarMaterial.Controls.Add(txtItemObs);
            pnlAgregarMaterial.Controls.Add(lblItemObs);
            pnlAgregarMaterial.Controls.Add(numCantidad);
            pnlAgregarMaterial.Controls.Add(lblCantidad);
            pnlAgregarMaterial.Controls.Add(cmbMateriales);
            pnlAgregarMaterial.Controls.Add(lblMaterial);
            pnlAgregarMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            pnlAgregarMaterial.Location = new System.Drawing.Point(0, 245);
            pnlAgregarMaterial.Name = "pnlAgregarMaterial";
            pnlAgregarMaterial.Size = new System.Drawing.Size(1020, 65);
            pnlAgregarMaterial.TabIndex = 2;
            // 
            // picMiniMaterial
            // 
            picMiniMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            picMiniMaterial.BackColor = System.Drawing.Color.White;
            picMiniMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picMiniMaterial.Location = new System.Drawing.Point(950, 5);
            picMiniMaterial.Name = "picMiniMaterial";
            picMiniMaterial.Size = new System.Drawing.Size(55, 52);
            picMiniMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picMiniMaterial.TabIndex = 8;
            picMiniMaterial.TabStop = false;
            // 
            // btnEliminarItem
            // 
            btnEliminarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnEliminarItem.ForeColor = System.Drawing.Color.DarkRed;
            btnEliminarItem.Location = new System.Drawing.Point(855, 17);
            btnEliminarItem.Name = "btnEliminarItem";
            btnEliminarItem.Size = new System.Drawing.Size(85, 28);
            btnEliminarItem.TabIndex = 7;
            btnEliminarItem.Text = "Quitar Fila";
            btnEliminarItem.UseVisualStyleBackColor = true;
            btnEliminarItem.Click += new System.EventHandler(btnEliminarItem_Click);
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnAgregarItem.BackColor = System.Drawing.Color.SteelBlue;
            btnAgregarItem.ForeColor = System.Drawing.Color.White;
            btnAgregarItem.Location = new System.Drawing.Point(745, 17);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new System.Drawing.Size(100, 28);
            btnAgregarItem.TabIndex = 6;
            btnAgregarItem.Text = "+ Agregar";
            btnAgregarItem.UseVisualStyleBackColor = false;
            btnAgregarItem.Click += new System.EventHandler(btnAgregarItem_Click);
            // 
            // txtItemObs
            // 
            txtItemObs.Location = new System.Drawing.Point(535, 20);
            txtItemObs.Name = "txtItemObs";
            txtItemObs.Size = new System.Drawing.Size(195, 23);
            txtItemObs.TabIndex = 5;
            // 
            // lblItemObs
            // 
            lblItemObs.AutoSize = true;
            lblItemObs.Location = new System.Drawing.Point(500, 23);
            lblItemObs.Name = "lblItemObs";
            lblItemObs.Size = new System.Drawing.Size(31, 15);
            lblItemObs.TabIndex = 4;
            lblItemObs.Text = "Obs:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new System.Drawing.Point(430, 21);
            numCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new System.Drawing.Size(60, 23);
            numCantidad.TabIndex = 3;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new System.Drawing.Point(370, 23);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new System.Drawing.Size(58, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad:";
            // 
            // cmbMateriales
            // 
            cmbMateriales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbMateriales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbMateriales.FormattingEnabled = true;
            cmbMateriales.Location = new System.Drawing.Point(70, 20);
            cmbMateriales.Name = "cmbMateriales";
            cmbMateriales.Size = new System.Drawing.Size(290, 23);
            cmbMateriales.TabIndex = 1;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new System.Drawing.Point(12, 23);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new System.Drawing.Size(53, 15);
            lblMaterial.TabIndex = 0;
            lblMaterial.Text = "Material:";
            // 
            // dgvMateriales
            // 
            dgvMateriales.AllowUserToAddRows = false;
            dgvMateriales.BackgroundColor = System.Drawing.Color.White;
            dgvMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMateriales.Location = new System.Drawing.Point(0, 310);
            dgvMateriales.Name = "dgvMateriales";
            dgvMateriales.Size = new System.Drawing.Size(1020, 240);
            dgvMateriales.TabIndex = 3;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(btnRegistrarDevolucion);
            panelFooter.Controls.Add(btnModificar);
            panelFooter.Controls.Add(btnGuardar);
            panelFooter.Controls.Add(btnNuevo);
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Location = new System.Drawing.Point(0, 550);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1020, 60);
            panelFooter.TabIndex = 4;
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.BackColor = System.Drawing.Color.SteelBlue;
            btnRegistrarDevolucion.ForeColor = System.Drawing.Color.White;
            btnRegistrarDevolucion.Location = new System.Drawing.Point(620, 14);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new System.Drawing.Size(160, 34);
            btnRegistrarDevolucion.TabIndex = 3;
            btnRegistrarDevolucion.Text = "📥 Registrar Devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            btnRegistrarDevolucion.Click += new System.EventHandler(btnRegistrarDevolucion_Click);
            // 
            // btnModificar
            // 
            btnModificar.BackColor = System.Drawing.Color.DarkOrange;
            btnModificar.ForeColor = System.Drawing.Color.Black;
            btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnModificar.Location = new System.Drawing.Point(400, 14);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(200, 34);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "✏ Modificar Vale Existente";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += new System.EventHandler(btnModificar_Click);
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnGuardar.Location = new System.Drawing.Point(150, 14);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(230, 34);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "💾 Guardar y Autorizar Vale";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += new System.EventHandler(btnGuardar_Click);
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new System.Drawing.Point(16, 14);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new System.Drawing.Size(115, 34);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo Vale";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += new System.EventHandler(btnNuevo_Click);
            // 
            // ValesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1020, 610);
            Controls.Add(dgvMateriales);
            Controls.Add(pnlAgregarMaterial);
            Controls.Add(panelDatos);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            MinimumSize = new System.Drawing.Size(950, 550);
            Name = "ValesForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gestión de Vales de Materiales - Laboratorio de Automatización";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            pnlAgregarMaterial.ResumeLayout(false);
            pnlAgregarMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMiniMaterial).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnResumenDiario;
        private System.Windows.Forms.Button btnBuscarVale;
        private System.Windows.Forms.TextBox txtBuscarIdVale;
        private System.Windows.Forms.Label lblBuscarVale;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblValeId;
        private System.Windows.Forms.TextBox txtValeId;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblExpediente;
        private System.Windows.Forms.TextBox txtExpediente;
        private System.Windows.Forms.Button btnBuscarExpediente;
        private System.Windows.Forms.Label lblNombreSol;
        private System.Windows.Forms.TextBox txtNombreSolicitante;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblAutorizo;
        private System.Windows.Forms.TextBox txtAutorizo;
        private System.Windows.Forms.Label lblRecibio;
        private System.Windows.Forms.TextBox txtRecibio;
        private System.Windows.Forms.Label lblEstadoModo;
        private System.Windows.Forms.Panel pnlAgregarMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMateriales;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblItemObs;
        private System.Windows.Forms.TextBox txtItemObs;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Button btnEliminarItem;
        private System.Windows.Forms.PictureBox picMiniMaterial;
        private System.Windows.Forms.DataGridView dgvMateriales;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
    }
}
