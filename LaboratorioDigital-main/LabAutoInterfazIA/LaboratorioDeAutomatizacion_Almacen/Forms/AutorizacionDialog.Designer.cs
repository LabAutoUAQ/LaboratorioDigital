namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    partial class AutorizacionDialog
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
            lblTitulo = new System.Windows.Forms.Label();
            lblMensaje = new System.Windows.Forms.Label();
            lblSupervisor = new System.Windows.Forms.Label();
            cmbSupervisor = new System.Windows.Forms.ComboBox();
            lblClave = new System.Windows.Forms.Label();
            txtClave = new System.Windows.Forms.TextBox();
            btnAceptar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            lblTitulo.Location = new System.Drawing.Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(261, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Autorización de Personal Docente";
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblMensaje.Location = new System.Drawing.Point(22, 45);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(390, 35);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Para autorizar la modificación del vale, ingrese las credenciales de un administrativo:";
            // 
            // lblSupervisor
            // 
            lblSupervisor.AutoSize = true;
            lblSupervisor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblSupervisor.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblSupervisor.Location = new System.Drawing.Point(22, 90);
            lblSupervisor.Name = "lblSupervisor";
            lblSupervisor.Size = new System.Drawing.Size(89, 15);
            lblSupervisor.TabIndex = 2;
            lblSupervisor.Text = "Administrativo:";
            // 
            // cmbSupervisor
            // 
            cmbSupervisor.DisplayMember = "Nombre";
            cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSupervisor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cmbSupervisor.FormattingEnabled = true;
            cmbSupervisor.Location = new System.Drawing.Point(120, 87);
            cmbSupervisor.Name = "cmbSupervisor";
            cmbSupervisor.Size = new System.Drawing.Size(280, 24);
            cmbSupervisor.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblClave.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblClave.Location = new System.Drawing.Point(22, 128);
            lblClave.Name = "lblClave";
            lblClave.Size = new System.Drawing.Size(70, 15);
            lblClave.TabIndex = 4;
            lblClave.Text = "Contraseña:";
            // 
            // txtClave
            // 
            txtClave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtClave.Location = new System.Drawing.Point(120, 125);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.Size = new System.Drawing.Size(280, 24);
            txtClave.TabIndex = 5;
            txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(txtClave_KeyDown);
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnAceptar.ForeColor = System.Drawing.Color.White;
            btnAceptar.Location = new System.Drawing.Point(180, 175);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new System.Drawing.Size(110, 34);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Autorizar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += new System.EventHandler(btnAceptar_Click);
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = System.Drawing.Color.White;
            btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCancelar.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            btnCancelar.Location = new System.Drawing.Point(295, 175);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(105, 34);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
            // 
            // AutorizacionDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            ClientSize = new System.Drawing.Size(430, 230);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(cmbSupervisor);
            Controls.Add(lblSupervisor);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AutorizacionDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Autorización Requerida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

