namespace LaboratorioDeAutomatizacion_Almacen
{
    partial class Almacen_del_Laboratorio_de_Automatizacion
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
            menuStrip1 = new MenuStrip();
            almacénToolStripMenuItem = new ToolStripMenuItem();
            valesToolStripMenuItem = new ToolStripMenuItem();
            capturaValesToolStripMenuItem = new ToolStripMenuItem();
            resumenDiarioToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            miClaveToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            parámetrosDelSistemaToolStripMenuItem = new ToolStripMenuItem();
            instruccionesSQLToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { almacénToolStripMenuItem, valesToolStripMenuItem, herramientasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(950, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // almacénToolStripMenuItem
            // 
            almacénToolStripMenuItem.Name = "almacénToolStripMenuItem";
            almacénToolStripMenuItem.Size = new Size(66, 20);
            almacénToolStripMenuItem.Text = "Almacén";
            almacénToolStripMenuItem.Click += almacénToolStripMenuItem_Click;
            // 
            // valesToolStripMenuItem
            // 
            valesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { capturaValesToolStripMenuItem, resumenDiarioToolStripMenuItem });
            valesToolStripMenuItem.Name = "valesToolStripMenuItem";
            valesToolStripMenuItem.Size = new Size(45, 20);
            valesToolStripMenuItem.Text = "Vales";
            // 
            // capturaValesToolStripMenuItem
            // 
            capturaValesToolStripMenuItem.Name = "capturaValesToolStripMenuItem";
            capturaValesToolStripMenuItem.Size = new Size(240, 22);
            capturaValesToolStripMenuItem.Text = "Gestión de Vales / Préstamos";
            capturaValesToolStripMenuItem.Click += capturaValesToolStripMenuItem_Click;
            // 
            // resumenDiarioToolStripMenuItem
            // 
            resumenDiarioToolStripMenuItem.Name = "resumenDiarioToolStripMenuItem";
            resumenDiarioToolStripMenuItem.Size = new Size(240, 22);
            resumenDiarioToolStripMenuItem.Text = "Resumen Diario de Materiales...";
            resumenDiarioToolStripMenuItem.Click += resumenDiarioToolStripMenuItem_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miClaveToolStripMenuItem, usuariosToolStripMenuItem, parámetrosDelSistemaToolStripMenuItem, instruccionesSQLToolStripMenuItem, acercaDeToolStripMenuItem, cerrarSesionToolStripMenuItem, salirToolStripMenuItem });
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(90, 20);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // miClaveToolStripMenuItem
            // 
            miClaveToolStripMenuItem.Name = "miClaveToolStripMenuItem";
            miClaveToolStripMenuItem.Size = new Size(225, 22);
            miClaveToolStripMenuItem.Text = "Mi Clave";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(225, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // parámetrosDelSistemaToolStripMenuItem
            // 
            parámetrosDelSistemaToolStripMenuItem.Name = "parámetrosDelSistemaToolStripMenuItem";
            parámetrosDelSistemaToolStripMenuItem.Size = new Size(225, 22);
            parámetrosDelSistemaToolStripMenuItem.Text = "Parámetros del Sistema";
            // 
            // instruccionesSQLToolStripMenuItem
            // 
            instruccionesSQLToolStripMenuItem.Name = "instruccionesSQLToolStripMenuItem";
            instruccionesSQLToolStripMenuItem.Size = new Size(225, 22);
            instruccionesSQLToolStripMenuItem.Text = "Instrucciones SQL";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(225, 22);
            acercaDeToolStripMenuItem.Text = "Acerca de...";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(225, 22);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesión / Cambiar Usuario";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.ForeColor = Color.Red;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(225, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // Almacen_del_Laboratorio_de_Automatizacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 550);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Almacen_del_Laboratorio_de_Automatizacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Almacén del Laboratorio de Automatización - UAQ Ingeniería";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem almacénToolStripMenuItem;
        private ToolStripMenuItem valesToolStripMenuItem;
        private ToolStripMenuItem capturaValesToolStripMenuItem;
        private ToolStripMenuItem resumenDiarioToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem miClaveToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem parámetrosDelSistemaToolStripMenuItem;
        private ToolStripMenuItem instruccionesSQLToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}
