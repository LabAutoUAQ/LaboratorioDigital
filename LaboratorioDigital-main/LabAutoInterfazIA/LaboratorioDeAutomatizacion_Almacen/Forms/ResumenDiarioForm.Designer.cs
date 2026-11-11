namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    partial class ResumenDiarioForm
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
            panelSuperior = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblFecha = new System.Windows.Forms.Label();
            dtpFecha = new System.Windows.Forms.DateTimePicker();
            btnRefrescar = new System.Windows.Forms.Button();
            btnImprimir = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            txtPreview = new System.Windows.Forms.TextBox();
            panelInferior = new System.Windows.Forms.Panel();
            lblTotales = new System.Windows.Forms.Label();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = System.Drawing.Color.White;
            panelSuperior.Controls.Add(btnCerrar);
            panelSuperior.Controls.Add(btnImprimir);
            panelSuperior.Controls.Add(btnRefrescar);
            panelSuperior.Controls.Add(dtpFecha);
            panelSuperior.Controls.Add(lblFecha);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            panelSuperior.Location = new System.Drawing.Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new System.Drawing.Size(784, 80);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            lblTitulo.Location = new System.Drawing.Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(370, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resumen Diario de Materiales Solicitados";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFecha.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblFecha.Location = new System.Drawing.Point(18, 48);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new System.Drawing.Size(107, 15);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Seleccionar Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFecha.Location = new System.Drawing.Point(135, 44);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new System.Drawing.Size(130, 23);
            dtpFecha.TabIndex = 2;
            dtpFecha.ValueChanged += new System.EventHandler(dtpFecha_ValueChanged);
            // 
            // btnRefrescar
            // 
            btnRefrescar.BackColor = System.Drawing.Color.White;
            btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnRefrescar.Location = new System.Drawing.Point(280, 42);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(85, 27);
            btnRefrescar.TabIndex = 3;
            btnRefrescar.Text = "Actualizar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnImprimir.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnImprimir.ForeColor = System.Drawing.Color.White;
            btnImprimir.Location = new System.Drawing.Point(505, 40);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new System.Drawing.Size(160, 32);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "🖨 Imprimir Listado";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += new System.EventHandler(btnImprimir_Click);
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnCerrar.BackColor = System.Drawing.Color.White;
            btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCerrar.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            btnCerrar.Location = new System.Drawing.Point(675, 40);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(90, 32);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += new System.EventHandler(btnCerrar_Click);
            // 
            // txtPreview
            // 
            txtPreview.BackColor = System.Drawing.Color.White;
            txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            txtPreview.Font = new System.Drawing.Font("Consolas", 10F);
            txtPreview.Location = new System.Drawing.Point(0, 80);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtPreview.Size = new System.Drawing.Size(784, 440);
            txtPreview.TabIndex = 1;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            panelInferior.Controls.Add(lblTotales);
            panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelInferior.Location = new System.Drawing.Point(0, 520);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new System.Drawing.Size(784, 40);
            panelInferior.TabIndex = 2;
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotales.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblTotales.Location = new System.Drawing.Point(16, 12);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new System.Drawing.Size(19, 15);
            lblTotales.TabIndex = 0;
            lblTotales.Text = "...";
            // 
            // ResumenDiarioForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            Controls.Add(txtPreview);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new System.Drawing.Size(650, 450);
            Name = "ResumenDiarioForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Listado / Resumen Diario de Materiales";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblTotales;
    }
}

