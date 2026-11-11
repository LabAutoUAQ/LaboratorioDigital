using System;
using System.Drawing;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Services;

namespace LaboratorioDeAutomatizacion_Almacen.Forms
{
    public partial class ResumenDiarioForm : Form
    {
        private readonly ImpresionService _impresionService;

        public ResumenDiarioForm()
        {
            InitializeComponent();
            _impresionService = new ImpresionService();
            dtpFecha.Value = DateTime.Today;
            ActualizarResumen();
        }

        public void EstablecerFecha(DateTime fecha)
        {
            dtpFecha.Value = fecha;
            ActualizarResumen();
        }

        private void ActualizarResumen()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string texto = _impresionService.GenerarTextoResumen(dtpFecha.Value, out var items);
                txtPreview.Text = texto;
                lblTotales.Text = $"Total de artículos registrados en la fecha: {items.Count}";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            _impresionService.MostrarVistaPreviaOImprimir(dtpFecha.Value, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ActualizarResumen();
        }
    }
}

