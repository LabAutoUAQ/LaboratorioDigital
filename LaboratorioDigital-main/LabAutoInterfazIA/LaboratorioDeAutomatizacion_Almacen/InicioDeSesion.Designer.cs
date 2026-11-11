namespace LaboratorioDeAutomatizacion_Almacen
{
    partial class InicioDeSesion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Lab_Tag = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            btnIngresar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // Lab_Tag
            // 
            Lab_Tag.AutoSize = true;
            Lab_Tag.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            Lab_Tag.ForeColor = Color.FromArgb(185, 28, 28);
            Lab_Tag.Location = new Point(14, 16);
            Lab_Tag.Name = "Lab_Tag";
            Lab_Tag.Size = new Size(397, 25);
            Lab_Tag.TabIndex = 0;
            Lab_Tag.Text = "Almacén del Laboratorio de Automatización";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 9.5F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(105, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(290, 25);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(55, 65, 81);
            label2.Location = new Point(24, 64);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.5F);
            textBox1.Location = new Point(105, 96);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 24);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            label3.ForeColor = Color.FromArgb(55, 65, 81);
            label3.Location = new Point(24, 100);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "Expediente:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9.5F);
            textBox2.Location = new Point(105, 132);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '●';
            textBox2.Size = new Size(290, 24);
            textBox2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            label1.ForeColor = Color.FromArgb(55, 65, 81);
            label1.Location = new Point(24, 136);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 6;
            label1.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(185, 28, 28);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(105, 175);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(140, 34);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9.5F);
            btnLimpiar.ForeColor = Color.FromArgb(31, 41, 55);
            btnLimpiar.Location = new Point(255, 175);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 34);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // InicioDeSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(430, 235);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(Lab_Tag);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "InicioDeSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acceso al Sistema";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lab_Tag;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label1;
        private Button btnIngresar;
        private Button btnLimpiar;
    }
}
