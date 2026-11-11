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
            panelHeader = new Panel();
            btnCerrarSesion = new Button();
            btnResumenDiario = new Button();
            pnlNavegacion = new Panel();
            btnValeUltimo = new Button();
            btnValeSiguiente = new Button();
            txtBuscarIdVale = new TextBox();
            lblValeNum = new Label();
            btnValeAnterior = new Button();
            btnValePrimero = new Button();
            lblTitulo = new Label();
            panelDatos = new Panel();
            lblBadgeEstado = new Label();
            txtObservaciones = new TextBox();
            lblObs = new Label();
            txtCelular = new TextBox();
            lblCelular = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtCarrera = new TextBox();
            lblCarrera = new Label();
            dtpFechaEntrega = new DateTimePicker();
            lblFechaEntrega = new Label();
            txtMateria = new TextBox();
            lblMateria = new Label();
            txtNombreSolicitante = new TextBox();
            lblNombreSol = new Label();
            btnBuscarExpediente = new Button();
            txtExpediente = new TextBox();
            lblExpediente = new Label();
            txtFecha = new TextBox();
            lblFecha = new Label();
            txtValeId = new TextBox();
            lblValeId = new Label();
            pnlCapturaMaterial = new Panel();
            btnEliminarItem = new Button();
            btnAgregarItem = new Button();
            txtItemObs = new TextBox();
            lblItemObs = new Label();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            cmbMateriales = new ComboBox();
            lblO = new Label();
            txtCodigoBarras = new TextBox();
            lblCodigoBarras = new Label();
            dgvMateriales = new DataGridView();
            panelFooter = new Panel();
            lblInfoAdmin = new Label();
            btnRegistrarDevolucion = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            panelHeader.SuspendLayout();
            pnlNavegacion.SuspendLayout();
            panelDatos.SuspendLayout();
            pnlCapturaMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(btnCerrarSesion);
            panelHeader.Controls.Add(btnResumenDiario);
            panelHeader.Controls.Add(pnlNavegacion);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1184, 56);
            panelHeader.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.White;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 8.5F);
            btnCerrarSesion.ForeColor = Color.FromArgb(55, 65, 81);
            btnCerrarSesion.Location = new Point(1060, 12);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(112, 32);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "🔒 Salir / Cambiar";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // btnResumenDiario
            // 
            btnResumenDiario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResumenDiario.BackColor = Color.White;
            btnResumenDiario.Cursor = Cursors.Hand;
            btnResumenDiario.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnResumenDiario.FlatStyle = FlatStyle.Flat;
            btnResumenDiario.Font = new Font("Segoe UI", 8.5F);
            btnResumenDiario.ForeColor = Color.FromArgb(55, 65, 81);
            btnResumenDiario.Location = new Point(915, 12);
            btnResumenDiario.Name = "btnResumenDiario";
            btnResumenDiario.Size = new Size(140, 32);
            btnResumenDiario.TabIndex = 4;
            btnResumenDiario.Text = "🖨 Resumen Diario";
            btnResumenDiario.UseVisualStyleBackColor = false;
            // 
            // pnlNavegacion
            // 
            pnlNavegacion.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlNavegacion.Controls.Add(btnValeUltimo);
            pnlNavegacion.Controls.Add(btnValeSiguiente);
            pnlNavegacion.Controls.Add(txtBuscarIdVale);
            pnlNavegacion.Controls.Add(lblValeNum);
            pnlNavegacion.Controls.Add(btnValeAnterior);
            pnlNavegacion.Controls.Add(btnValePrimero);
            pnlNavegacion.Location = new Point(320, 10);
            pnlNavegacion.Name = "pnlNavegacion";
            pnlNavegacion.Size = new Size(460, 36);
            pnlNavegacion.TabIndex = 1;
            // 
            // btnValeUltimo
            // 
            btnValeUltimo.BackColor = Color.White;
            btnValeUltimo.Cursor = Cursors.Hand;
            btnValeUltimo.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnValeUltimo.FlatStyle = FlatStyle.Flat;
            btnValeUltimo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValeUltimo.Location = new Point(395, 2);
            btnValeUltimo.Name = "btnValeUltimo";
            btnValeUltimo.Size = new Size(50, 30);
            btnValeUltimo.TabIndex = 5;
            btnValeUltimo.Text = "▶|";
            btnValeUltimo.UseVisualStyleBackColor = false;
            // 
            // btnValeSiguiente
            // 
            btnValeSiguiente.BackColor = Color.White;
            btnValeSiguiente.Cursor = Cursors.Hand;
            btnValeSiguiente.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnValeSiguiente.FlatStyle = FlatStyle.Flat;
            btnValeSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValeSiguiente.Location = new Point(290, 2);
            btnValeSiguiente.Name = "btnValeSiguiente";
            btnValeSiguiente.Size = new Size(100, 30);
            btnValeSiguiente.TabIndex = 4;
            btnValeSiguiente.Text = "Siguiente ▶";
            btnValeSiguiente.UseVisualStyleBackColor = false;
            // 
            // txtBuscarIdVale
            // 
            txtBuscarIdVale.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtBuscarIdVale.ForeColor = Color.FromArgb(185, 28, 28);
            txtBuscarIdVale.Location = new Point(208, 4);
            txtBuscarIdVale.Name = "txtBuscarIdVale";
            txtBuscarIdVale.Size = new Size(76, 25);
            txtBuscarIdVale.TabIndex = 3;
            txtBuscarIdVale.TextAlign = HorizontalAlignment.Center;
            // 
            // lblValeNum
            // 
            lblValeNum.AutoSize = true;
            lblValeNum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblValeNum.ForeColor = Color.FromArgb(55, 65, 81);
            lblValeNum.Location = new Point(160, 9);
            lblValeNum.Name = "lblValeNum";
            lblValeNum.Size = new Size(46, 15);
            lblValeNum.TabIndex = 2;
            lblValeNum.Text = "Vale #:";
            // 
            // btnValeAnterior
            // 
            btnValeAnterior.BackColor = Color.White;
            btnValeAnterior.Cursor = Cursors.Hand;
            btnValeAnterior.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnValeAnterior.FlatStyle = FlatStyle.Flat;
            btnValeAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValeAnterior.Location = new Point(55, 2);
            btnValeAnterior.Name = "btnValeAnterior";
            btnValeAnterior.Size = new Size(100, 30);
            btnValeAnterior.TabIndex = 1;
            btnValeAnterior.Text = "◀ Anterior";
            btnValeAnterior.UseVisualStyleBackColor = false;
            // 
            // btnValePrimero
            // 
            btnValePrimero.BackColor = Color.White;
            btnValePrimero.Cursor = Cursors.Hand;
            btnValePrimero.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnValePrimero.FlatStyle = FlatStyle.Flat;
            btnValePrimero.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValePrimero.Location = new Point(0, 2);
            btnValePrimero.Name = "btnValePrimero";
            btnValePrimero.Size = new Size(50, 30);
            btnValePrimero.TabIndex = 0;
            btnValePrimero.Text = "|◀";
            btnValePrimero.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(185, 28, 28);
            lblTitulo.Location = new Point(14, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(270, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de Vales / Préstamos";
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.White;
            panelDatos.Controls.Add(lblBadgeEstado);
            panelDatos.Controls.Add(txtObservaciones);
            panelDatos.Controls.Add(lblObs);
            panelDatos.Controls.Add(txtCelular);
            panelDatos.Controls.Add(lblCelular);
            panelDatos.Controls.Add(txtEmail);
            panelDatos.Controls.Add(lblEmail);
            panelDatos.Controls.Add(txtCarrera);
            panelDatos.Controls.Add(lblCarrera);
            panelDatos.Controls.Add(dtpFechaEntrega);
            panelDatos.Controls.Add(lblFechaEntrega);
            panelDatos.Controls.Add(txtMateria);
            panelDatos.Controls.Add(lblMateria);
            panelDatos.Controls.Add(txtNombreSolicitante);
            panelDatos.Controls.Add(lblNombreSol);
            panelDatos.Controls.Add(btnBuscarExpediente);
            panelDatos.Controls.Add(txtExpediente);
            panelDatos.Controls.Add(lblExpediente);
            panelDatos.Controls.Add(txtFecha);
            panelDatos.Controls.Add(lblFecha);
            panelDatos.Controls.Add(txtValeId);
            panelDatos.Controls.Add(lblValeId);
            panelDatos.Dock = DockStyle.Top;
            panelDatos.Location = new Point(0, 56);
            panelDatos.Name = "panelDatos";
            panelDatos.Padding = new Padding(12);
            panelDatos.Size = new Size(1184, 118);
            panelDatos.TabIndex = 1;
            // 
            // lblBadgeEstado
            // 
            lblBadgeEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBadgeEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBadgeEstado.ForeColor = Color.FromArgb(185, 28, 28);
            lblBadgeEstado.Location = new Point(800, 85);
            lblBadgeEstado.Name = "lblBadgeEstado";
            lblBadgeEstado.Size = new Size(365, 22);
            lblBadgeEstado.TabIndex = 21;
            lblBadgeEstado.Text = "...";
            lblBadgeEstado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Font = new Font("Segoe UI", 9F);
            txtObservaciones.Location = new Point(480, 84);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Notas o detalles del préstamo...";
            txtObservaciones.Size = new Size(310, 23);
            txtObservaciones.TabIndex = 16;
            // 
            // lblObs
            // 
            lblObs.AutoSize = true;
            lblObs.Font = new Font("Segoe UI", 9F);
            lblObs.ForeColor = Color.FromArgb(55, 65, 81);
            lblObs.Location = new Point(440, 87);
            lblObs.Name = "lblObs";
            lblObs.Size = new Size(34, 15);
            lblObs.TabIndex = 15;
            lblObs.Text = "Obs:";
            // 
            // txtCelular
            // 
            txtCelular.BackColor = Color.FromArgb(249, 250, 251);
            txtCelular.Font = new Font("Segoe UI", 9F);
            txtCelular.Location = new Point(310, 84);
            txtCelular.Name = "txtCelular";
            txtCelular.ReadOnly = true;
            txtCelular.Size = new Size(115, 23);
            txtCelular.TabIndex = 25;
            // 
            // lblCelular
            // 
            lblCelular.AutoSize = true;
            lblCelular.Font = new Font("Segoe UI", 9F);
            lblCelular.ForeColor = Color.FromArgb(55, 65, 81);
            lblCelular.Location = new Point(255, 87);
            lblCelular.Name = "lblCelular";
            lblCelular.Size = new Size(51, 15);
            lblCelular.TabIndex = 24;
            lblCelular.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(249, 250, 251);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(65, 84);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 23;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(55, 65, 81);
            lblEmail.Location = new Point(14, 87);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 15);
            lblEmail.TabIndex = 22;
            lblEmail.Text = "Correo:";
            // 
            // txtCarrera
            // 
            txtCarrera.BackColor = Color.FromArgb(249, 250, 251);
            txtCarrera.Font = new Font("Segoe UI", 9F);
            txtCarrera.Location = new Point(965, 48);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.ReadOnly = true;
            txtCarrera.Size = new Size(200, 23);
            txtCarrera.TabIndex = 12;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Font = new Font("Segoe UI", 9F);
            lblCarrera.ForeColor = Color.FromArgb(55, 65, 81);
            lblCarrera.Location = new Point(915, 51);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(48, 15);
            lblCarrera.TabIndex = 11;
            lblCarrera.Text = "Carrera:";
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaEntrega.Font = new Font("Segoe UI", 9F);
            dtpFechaEntrega.Format = DateTimePickerFormat.Custom;
            dtpFechaEntrega.Location = new Point(745, 48);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(155, 23);
            dtpFechaEntrega.TabIndex = 5;
            // 
            // lblFechaEntrega
            // 
            lblFechaEntrega.AutoSize = true;
            lblFechaEntrega.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaEntrega.ForeColor = Color.FromArgb(55, 65, 81);
            lblFechaEntrega.Location = new Point(650, 51);
            lblFechaEntrega.Name = "lblFechaEntrega";
            lblFechaEntrega.Size = new Size(88, 15);
            lblFechaEntrega.TabIndex = 4;
            lblFechaEntrega.Text = "Fecha Entrega:";
            // 
            // txtMateria
            // 
            txtMateria.Font = new Font("Segoe UI", 9F);
            txtMateria.Location = new Point(480, 48);
            txtMateria.Name = "txtMateria";
            txtMateria.PlaceholderText = "Nombre de la materia / proyecto...";
            txtMateria.Size = new Size(155, 23);
            txtMateria.TabIndex = 14;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMateria.ForeColor = Color.FromArgb(185, 28, 28);
            lblMateria.Location = new Point(425, 51);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(53, 15);
            lblMateria.TabIndex = 13;
            lblMateria.Text = "Materia:";
            // 
            // txtNombreSolicitante
            // 
            txtNombreSolicitante.BackColor = Color.FromArgb(249, 250, 251);
            txtNombreSolicitante.Font = new Font("Segoe UI", 9F);
            txtNombreSolicitante.Location = new Point(205, 48);
            txtNombreSolicitante.Name = "txtNombreSolicitante";
            txtNombreSolicitante.ReadOnly = true;
            txtNombreSolicitante.Size = new Size(205, 23);
            txtNombreSolicitante.TabIndex = 10;
            // 
            // lblNombreSol
            // 
            lblNombreSol.AutoSize = true;
            lblNombreSol.Font = new Font("Segoe UI", 9F);
            lblNombreSol.ForeColor = Color.FromArgb(55, 65, 81);
            lblNombreSol.Location = new Point(135, 51);
            lblNombreSol.Name = "lblNombreSol";
            lblNombreSol.Size = new Size(65, 15);
            lblNombreSol.TabIndex = 9;
            lblNombreSol.Text = "Solicitante:";
            // 
            // btnBuscarExpediente
            // 
            btnBuscarExpediente.BackColor = Color.White;
            btnBuscarExpediente.Cursor = Cursors.Hand;
            btnBuscarExpediente.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnBuscarExpediente.FlatStyle = FlatStyle.Flat;
            btnBuscarExpediente.Font = new Font("Segoe UI", 8.5F);
            btnBuscarExpediente.Location = new Point(965, 12);
            btnBuscarExpediente.Name = "btnBuscarExpediente";
            btnBuscarExpediente.Size = new Size(95, 26);
            btnBuscarExpediente.TabIndex = 8;
            btnBuscarExpediente.Text = "🔍 Buscar Exp";
            btnBuscarExpediente.UseVisualStyleBackColor = false;
            // 
            // txtExpediente
            // 
            txtExpediente.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtExpediente.Location = new Point(830, 13);
            txtExpediente.Name = "txtExpediente";
            txtExpediente.PlaceholderText = "Expediente...";
            txtExpediente.Size = new Size(130, 24);
            txtExpediente.TabIndex = 7;
            // 
            // lblExpediente
            // 
            lblExpediente.AutoSize = true;
            lblExpediente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblExpediente.ForeColor = Color.FromArgb(55, 65, 81);
            lblExpediente.Location = new Point(750, 17);
            lblExpediente.Name = "lblExpediente";
            lblExpediente.Size = new Size(73, 15);
            lblExpediente.TabIndex = 6;
            lblExpediente.Text = "Expediente:";
            // 
            // txtFecha
            // 
            txtFecha.BackColor = Color.FromArgb(249, 250, 251);
            txtFecha.Font = new Font("Segoe UI", 9F);
            txtFecha.Location = new Point(205, 13);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(130, 23);
            txtFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F);
            lblFecha.ForeColor = Color.FromArgb(55, 65, 81);
            lblFecha.Location = new Point(135, 17);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // txtValeId
            // 
            txtValeId.BackColor = Color.FromArgb(249, 250, 251);
            txtValeId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtValeId.ForeColor = Color.FromArgb(185, 28, 28);
            txtValeId.Location = new Point(65, 13);
            txtValeId.Name = "txtValeId";
            txtValeId.ReadOnly = true;
            txtValeId.Size = new Size(60, 24);
            txtValeId.TabIndex = 1;
            // 
            // lblValeId
            // 
            lblValeId.AutoSize = true;
            lblValeId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblValeId.ForeColor = Color.FromArgb(55, 65, 81);
            lblValeId.Location = new Point(14, 17);
            lblValeId.Name = "lblValeId";
            lblValeId.Size = new Size(46, 15);
            lblValeId.TabIndex = 0;
            lblValeId.Text = "Folio #:";
            // 
            // pnlCapturaMaterial
            // 
            pnlCapturaMaterial.BackColor = Color.FromArgb(243, 244, 246);
            pnlCapturaMaterial.Controls.Add(btnEliminarItem);
            pnlCapturaMaterial.Controls.Add(btnAgregarItem);
            pnlCapturaMaterial.Controls.Add(txtItemObs);
            pnlCapturaMaterial.Controls.Add(lblItemObs);
            pnlCapturaMaterial.Controls.Add(numCantidad);
            pnlCapturaMaterial.Controls.Add(lblCantidad);
            pnlCapturaMaterial.Controls.Add(cmbMateriales);
            pnlCapturaMaterial.Controls.Add(lblO);
            pnlCapturaMaterial.Controls.Add(txtCodigoBarras);
            pnlCapturaMaterial.Controls.Add(lblCodigoBarras);
            pnlCapturaMaterial.Dock = DockStyle.Top;
            pnlCapturaMaterial.Location = new Point(0, 174);
            pnlCapturaMaterial.Name = "pnlCapturaMaterial";
            pnlCapturaMaterial.Size = new Size(1184, 52);
            pnlCapturaMaterial.TabIndex = 2;
            // 
            // btnEliminarItem
            // 
            btnEliminarItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarItem.BackColor = Color.White;
            btnEliminarItem.Cursor = Cursors.Hand;
            btnEliminarItem.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnEliminarItem.FlatStyle = FlatStyle.Flat;
            btnEliminarItem.Font = new Font("Segoe UI", 8.5F);
            btnEliminarItem.ForeColor = Color.FromArgb(185, 28, 28);
            btnEliminarItem.Location = new Point(1085, 10);
            btnEliminarItem.Name = "btnEliminarItem";
            btnEliminarItem.Size = new Size(88, 30);
            btnEliminarItem.TabIndex = 9;
            btnEliminarItem.Text = "🗑 Quitar Fila";
            btnEliminarItem.UseVisualStyleBackColor = false;
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarItem.BackColor = Color.FromArgb(185, 28, 28);
            btnAgregarItem.Cursor = Cursors.Hand;
            btnAgregarItem.FlatAppearance.BorderSize = 0;
            btnAgregarItem.FlatStyle = FlatStyle.Flat;
            btnAgregarItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregarItem.ForeColor = Color.White;
            btnAgregarItem.Location = new Point(990, 10);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new Size(88, 30);
            btnAgregarItem.TabIndex = 8;
            btnAgregarItem.Text = "➕ Agregar";
            btnAgregarItem.UseVisualStyleBackColor = false;
            // 
            // txtItemObs
            // 
            txtItemObs.Font = new Font("Segoe UI", 9F);
            txtItemObs.Location = new Point(780, 14);
            txtItemObs.Name = "txtItemObs";
            txtItemObs.PlaceholderText = "Notas entrega...";
            txtItemObs.Size = new Size(195, 23);
            txtItemObs.TabIndex = 7;
            // 
            // lblItemObs
            // 
            lblItemObs.AutoSize = true;
            lblItemObs.Font = new Font("Segoe UI", 8.5F);
            lblItemObs.ForeColor = Color.FromArgb(55, 65, 81);
            lblItemObs.Location = new Point(745, 17);
            lblItemObs.Name = "lblItemObs";
            lblItemObs.Size = new Size(31, 15);
            lblItemObs.TabIndex = 6;
            lblItemObs.Text = "Obs:";
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            numCantidad.Location = new Point(685, 14);
            numCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(50, 24);
            numCantidad.TabIndex = 5;
            numCantidad.TextAlign = HorizontalAlignment.Center;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(55, 65, 81);
            lblCantidad.Location = new Point(645, 17);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(38, 15);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cant:";
            // 
            // cmbMateriales
            // 
            cmbMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateriales.Font = new Font("Segoe UI", 9F);
            cmbMateriales.FormattingEnabled = true;
            cmbMateriales.Location = new Point(370, 14);
            cmbMateriales.Name = "cmbMateriales";
            cmbMateriales.Size = new Size(265, 23);
            cmbMateriales.TabIndex = 3;
            // 
            // lblO
            // 
            lblO.AutoSize = true;
            lblO.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblO.ForeColor = Color.FromArgb(107, 114, 128);
            lblO.Location = new Point(315, 17);
            lblO.Name = "lblO";
            lblO.Size = new Size(50, 15);
            lblO.TabIndex = 2;
            lblO.Text = "o elegir:";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.BackColor = Color.White;
            txtCodigoBarras.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtCodigoBarras.ForeColor = Color.FromArgb(17, 24, 39);
            txtCodigoBarras.Location = new Point(145, 13);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.PlaceholderText = "Escanear + Enter...";
            txtCodigoBarras.Size = new Size(160, 25);
            txtCodigoBarras.TabIndex = 1;
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCodigoBarras.ForeColor = Color.FromArgb(185, 28, 28);
            lblCodigoBarras.Location = new Point(14, 17);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(125, 15);
            lblCodigoBarras.TabIndex = 0;
            lblCodigoBarras.Text = "📷 Código de Barras:";
            // 
            // dgvMateriales
            // 
            dgvMateriales.AllowUserToAddRows = false;
            dgvMateriales.BackgroundColor = Color.White;
            dgvMateriales.BorderStyle = BorderStyle.None;
            dgvMateriales.Dock = DockStyle.Fill;
            dgvMateriales.Location = new Point(0, 226);
            dgvMateriales.Name = "dgvMateriales";
            dgvMateriales.Size = new Size(1184, 334);
            dgvMateriales.TabIndex = 3;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(lblInfoAdmin);
            panelFooter.Controls.Add(btnRegistrarDevolucion);
            panelFooter.Controls.Add(btnGuardar);
            panelFooter.Controls.Add(btnNuevo);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 560);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(12, 10, 12, 10);
            panelFooter.Size = new Size(1184, 55);
            panelFooter.TabIndex = 4;
            // 
            // lblInfoAdmin
            // 
            lblInfoAdmin.AutoSize = true;
            lblInfoAdmin.Font = new Font("Segoe UI", 9F);
            lblInfoAdmin.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfoAdmin.Location = new Point(14, 18);
            lblInfoAdmin.Name = "lblInfoAdmin";
            lblInfoAdmin.Size = new Size(16, 15);
            lblInfoAdmin.TabIndex = 4;
            lblInfoAdmin.Text = "...";
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrarDevolucion.BackColor = Color.White;
            btnRegistrarDevolucion.Cursor = Cursors.Hand;
            btnRegistrarDevolucion.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnRegistrarDevolucion.FlatStyle = FlatStyle.Flat;
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarDevolucion.ForeColor = Color.FromArgb(31, 41, 55);
            btnRegistrarDevolucion.Location = new Point(660, 10);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(185, 35);
            btnRegistrarDevolucion.TabIndex = 3;
            btnRegistrarDevolucion.Text = "📥 Registrar Devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(185, 28, 28);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(860, 10);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 35);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "💾 Guardar / Autorizar Vale";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = Color.White;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F);
            btnNuevo.ForeColor = Color.FromArgb(31, 41, 55);
            btnNuevo.Location = new Point(530, 10);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 35);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "➕ Nuevo Vale";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // ValesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1184, 615);
            Controls.Add(dgvMateriales);
            Controls.Add(pnlCapturaMaterial);
            Controls.Add(panelDatos);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            MinimumSize = new Size(1000, 550);
            Name = "ValesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Vales de Materiales - Laboratorio de Automatización";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            pnlNavegacion.ResumeLayout(false);
            pnlNavegacion.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            pnlCapturaMaterial.ResumeLayout(false);
            pnlCapturaMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Button btnCerrarSesion;
        private Button btnResumenDiario;
        private Panel pnlNavegacion;
        private Button btnValePrimero;
        private Button btnValeAnterior;
        private Label lblValeNum;
        private TextBox txtBuscarIdVale;
        private Button btnValeSiguiente;
        private Button btnValeUltimo;
        private Panel panelDatos;
        private Label lblValeId;
        private TextBox txtValeId;
        private Label lblFecha;
        private TextBox txtFecha;
        private Label lblFechaEntrega;
        private DateTimePicker dtpFechaEntrega;
        private Label lblExpediente;
        private TextBox txtExpediente;
        private Button btnBuscarExpediente;
        private Label lblNombreSol;
        private TextBox txtNombreSolicitante;
        private Label lblCarrera;
        private TextBox txtCarrera;
        private Label lblMateria;
        private TextBox txtMateria;
        private Label lblObs;
        private TextBox txtObservaciones;
        private Label lblBadgeEstado;
        private Panel pnlCapturaMaterial;
        private Label lblCodigoBarras;
        private TextBox txtCodigoBarras;
        private Label lblO;
        private ComboBox cmbMateriales;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblItemObs;
        private TextBox txtItemObs;
        private Button btnAgregarItem;
        private Button btnEliminarItem;
        private DataGridView dgvMateriales;
        private Panel panelFooter;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnRegistrarDevolucion;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCelular;
        private TextBox txtCelular;
        private Label lblInfoAdmin;
    }
}
