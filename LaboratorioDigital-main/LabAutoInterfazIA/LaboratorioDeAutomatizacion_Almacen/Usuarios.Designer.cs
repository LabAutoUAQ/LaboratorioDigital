namespace LaboratorioDeAutomatizacion_Almacen
{
    partial class Usuarios
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
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            splitContainer = new SplitContainer();
            dgvUsuarios = new DataGridView();
            panelFiltros = new Panel();
            lblTotalUsuarios = new Label();
            cmbFiltroEstado = new ComboBox();
            cmbFiltroRol = new ComboBox();
            txtBuscarUsuario = new TextBox();
            lblBuscar = new Label();
            pnlDetalle = new Panel();
            lblAvisoDirector = new Label();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnVerClave = new Button();
            txtCelular = new TextBox();
            lblCelular = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtCarrera = new TextBox();
            lblCarrera = new Label();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtClave = new TextBox();
            lblClave = new Label();
            txtExpediente = new TextBox();
            lblExpediente = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblTituloDetalle = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelFiltros.SuspendLayout();
            pnlDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1184, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitulo.Location = new Point(20, 35);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(297, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Consulta, registro y administración de roles y contraseñas";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(185, 28, 28);
            lblTitulo.Location = new Point(18, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(198, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catálogo de Usuarios";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel2;
            splitContainer.Location = new Point(0, 60);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvUsuarios);
            splitContainer.Panel1.Controls.Add(panelFiltros);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.BackColor = Color.White;
            splitContainer.Panel2.Controls.Add(pnlDetalle);
            splitContainer.Size = new Size(1184, 621);
            splitContainer.SplitterDistance = 800;
            splitContainer.TabIndex = 1;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 52);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(800, 569);
            dgvUsuarios.TabIndex = 1;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.FromArgb(243, 244, 246);
            panelFiltros.Controls.Add(lblTotalUsuarios);
            panelFiltros.Controls.Add(cmbFiltroEstado);
            panelFiltros.Controls.Add(cmbFiltroRol);
            panelFiltros.Controls.Add(txtBuscarUsuario);
            panelFiltros.Controls.Add(lblBuscar);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 0);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(800, 52);
            panelFiltros.TabIndex = 0;
            // 
            // lblTotalUsuarios
            // 
            lblTotalUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalUsuarios.AutoSize = true;
            lblTotalUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalUsuarios.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotalUsuarios.Location = new Point(660, 18);
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.Size = new Size(115, 15);
            lblTotalUsuarios.TabIndex = 4;
            lblTotalUsuarios.Text = "Total: 0 usuarios";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Font = new Font("Segoe UI", 9F);
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(480, 14);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(140, 23);
            cmbFiltroEstado.TabIndex = 3;
            // 
            // cmbFiltroRol
            // 
            cmbFiltroRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroRol.Font = new Font("Segoe UI", 9F);
            cmbFiltroRol.FormattingEnabled = true;
            cmbFiltroRol.Location = new Point(320, 14);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(150, 23);
            cmbFiltroRol.TabIndex = 2;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Font = new Font("Segoe UI", 9.5F);
            txtBuscarUsuario.Location = new Point(78, 14);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Nombre, expediente, correo...";
            txtBuscarUsuario.Size = new Size(230, 24);
            txtBuscarUsuario.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(31, 41, 55);
            lblBuscar.Location = new Point(16, 18);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(54, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // pnlDetalle
            // 
            pnlDetalle.AutoScroll = true;
            pnlDetalle.Controls.Add(lblAvisoDirector);
            pnlDetalle.Controls.Add(btnGuardar);
            pnlDetalle.Controls.Add(btnNuevo);
            pnlDetalle.Controls.Add(btnVerClave);
            pnlDetalle.Controls.Add(txtCelular);
            pnlDetalle.Controls.Add(lblCelular);
            pnlDetalle.Controls.Add(txtEmail);
            pnlDetalle.Controls.Add(lblEmail);
            pnlDetalle.Controls.Add(txtCarrera);
            pnlDetalle.Controls.Add(lblCarrera);
            pnlDetalle.Controls.Add(cmbEstado);
            pnlDetalle.Controls.Add(lblEstado);
            pnlDetalle.Controls.Add(cmbRol);
            pnlDetalle.Controls.Add(lblRol);
            pnlDetalle.Controls.Add(txtClave);
            pnlDetalle.Controls.Add(lblClave);
            pnlDetalle.Controls.Add(txtExpediente);
            pnlDetalle.Controls.Add(lblExpediente);
            pnlDetalle.Controls.Add(txtNombre);
            pnlDetalle.Controls.Add(lblNombre);
            pnlDetalle.Controls.Add(lblTituloDetalle);
            pnlDetalle.Dock = DockStyle.Fill;
            pnlDetalle.Location = new Point(0, 0);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Padding = new Padding(20);
            pnlDetalle.Size = new Size(380, 621);
            pnlDetalle.TabIndex = 0;
            // 
            // lblAvisoDirector
            // 
            lblAvisoDirector.AutoSize = true;
            lblAvisoDirector.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblAvisoDirector.ForeColor = Color.FromArgb(185, 28, 28);
            lblAvisoDirector.Location = new Point(20, 48);
            lblAvisoDirector.Name = "lblAvisoDirector";
            lblAvisoDirector.Size = new Size(270, 15);
            lblAvisoDirector.TabIndex = 20;
            lblAvisoDirector.Text = "Permiso Director: edición de rol y contraseñas activa";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(185, 28, 28);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(190, 520);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(155, 36);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "💾 Guardar en BD";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.White;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.5F);
            btnNuevo.ForeColor = Color.FromArgb(31, 41, 55);
            btnNuevo.Location = new Point(20, 520);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(155, 36);
            btnNuevo.TabIndex = 18;
            btnNuevo.Text = "➕ Limpiar / Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnVerClave
            // 
            btnVerClave.BackColor = Color.FromArgb(243, 244, 246);
            btnVerClave.Cursor = Cursors.Hand;
            btnVerClave.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnVerClave.FlatStyle = FlatStyle.Flat;
            btnVerClave.Font = new Font("Segoe UI", 8F);
            btnVerClave.Location = new Point(290, 192);
            btnVerClave.Name = "btnVerClave";
            btnVerClave.Size = new Size(55, 24);
            btnVerClave.TabIndex = 17;
            btnVerClave.Text = "👁 Ver";
            btnVerClave.UseVisualStyleBackColor = false;
            // 
            // txtCelular
            // 
            txtCelular.Font = new Font("Segoe UI", 9.5F);
            txtCelular.Location = new Point(20, 458);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(325, 24);
            txtCelular.TabIndex = 16;
            // 
            // lblCelular
            // 
            lblCelular.AutoSize = true;
            lblCelular.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCelular.ForeColor = Color.FromArgb(55, 65, 81);
            lblCelular.Location = new Point(20, 440);
            lblCelular.Name = "lblCelular";
            lblCelular.Size = new Size(102, 15);
            lblCelular.TabIndex = 15;
            lblCelular.Text = "Teléfono / Celular:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(20, 403);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(325, 24);
            txtEmail.TabIndex = 14;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblEmail.ForeColor = Color.FromArgb(55, 65, 81);
            lblEmail.Location = new Point(20, 385);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(111, 15);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtCarrera
            // 
            txtCarrera.Font = new Font("Segoe UI", 9.5F);
            txtCarrera.Location = new Point(20, 348);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.Size = new Size(325, 24);
            txtCarrera.TabIndex = 12;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCarrera.ForeColor = Color.FromArgb(55, 65, 81);
            lblCarrera.Location = new Point(20, 330);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(48, 15);
            lblCarrera.TabIndex = 11;
            lblCarrera.Text = "Carrera:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 9.5F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(20, 296);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(325, 24);
            cmbEstado.TabIndex = 10;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblEstado.ForeColor = Color.FromArgb(55, 65, 81);
            lblEstado.Location = new Point(20, 278);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "Estado:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 9.5F);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(20, 244);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(325, 24);
            cmbRol.TabIndex = 8;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblRol.ForeColor = Color.FromArgb(55, 65, 81);
            lblRol.Location = new Point(20, 226);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(88, 15);
            lblRol.TabIndex = 7;
            lblRol.Text = "Rol del Usuario:";
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 9.5F);
            txtClave.Location = new Point(20, 192);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.Size = new Size(265, 24);
            txtClave.TabIndex = 6;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblClave.ForeColor = Color.FromArgb(55, 65, 81);
            lblClave.Location = new Point(20, 174);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(70, 15);
            lblClave.TabIndex = 5;
            lblClave.Text = "Contraseña:";
            // 
            // txtExpediente
            // 
            txtExpediente.Font = new Font("Segoe UI", 9.5F);
            txtExpediente.Location = new Point(20, 140);
            txtExpediente.Name = "txtExpediente";
            txtExpediente.Size = new Size(325, 24);
            txtExpediente.TabIndex = 4;
            // 
            // lblExpediente
            // 
            lblExpediente.AutoSize = true;
            lblExpediente.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblExpediente.ForeColor = Color.FromArgb(55, 65, 81);
            lblExpediente.Location = new Point(20, 122);
            lblExpediente.Name = "lblExpediente";
            lblExpediente.Size = new Size(130, 15);
            lblExpediente.TabIndex = 3;
            lblExpediente.Text = "Expediente / Matrícula:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.Location = new Point(20, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(325, 24);
            txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblNombre.ForeColor = Color.FromArgb(55, 65, 81);
            lblNombre.Location = new Point(20, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(110, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre Completo:";
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.AutoSize = true;
            lblTituloDetalle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTituloDetalle.ForeColor = Color.FromArgb(185, 28, 28);
            lblTituloDetalle.Location = new Point(20, 20);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(157, 21);
            lblTituloDetalle.TabIndex = 0;
            lblTituloDetalle.Text = "Detalles de Usuario";
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(1184, 681);
            Controls.Add(splitContainer);
            Controls.Add(panelHeader);
            MinimumSize = new Size(950, 600);
            Name = "Usuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios del Laboratorio";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            pnlDetalle.ResumeLayout(false);
            pnlDetalle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private SplitContainer splitContainer;
        private DataGridView dgvUsuarios;
        private Panel panelFiltros;
        private TextBox txtBuscarUsuario;
        private Label lblBuscar;
        private ComboBox cmbFiltroEstado;
        private ComboBox cmbFiltroRol;
        private Label lblTotalUsuarios;
        private Panel pnlDetalle;
        private Label lblTituloDetalle;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblExpediente;
        private TextBox txtExpediente;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblRol;
        private ComboBox cmbRol;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblCarrera;
        private TextBox txtCarrera;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCelular;
        private TextBox txtCelular;
        private Button btnVerClave;
        private Button btnGuardar;
        private Button btnNuevo;
        private Label lblAvisoDirector;
    }
}
