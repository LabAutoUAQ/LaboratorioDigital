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
            Lab_Tag.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Lab_Tag.ForeColor = Color.MidnightBlue;
            Lab_Tag.Location = new Point(12, 12);
            Lab_Tag.Name = "Lab_Tag";
            Lab_Tag.Size = new Size(397, 25);
            Lab_Tag.TabIndex = 0;
            Lab_Tag.Text = "Almacén del Laboratorio de Automatización";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(105, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 23);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 55);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 23);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 90);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "Expediente:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(105, 122);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '●';
            textBox2.Size = new Size(260, 23);
            textBox2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 125);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 6;
            label1.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.SteelBlue;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIngresar.Location = new Point(105, 160);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(130, 32);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(245, 160);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 32);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // InicioDeSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 215);
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
