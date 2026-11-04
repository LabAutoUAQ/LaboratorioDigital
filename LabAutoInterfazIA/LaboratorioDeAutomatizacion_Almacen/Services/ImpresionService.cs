using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LaboratorioDeAutomatizacion_Almacen.Data;
using LaboratorioDeAutomatizacion_Almacen.Models;

namespace LaboratorioDeAutomatizacion_Almacen.Services
{
    public class ImpresionService
    {
        private readonly ValeRepository _valeRepository;

        public ImpresionService()
        {
            _valeRepository = new ValeRepository();
        }

        public string GenerarTextoResumen(DateTime fecha, out List<ResumenMaterialItem> items)
        {
            items = _valeRepository.ObtenerResumenMaterialesPorFecha(fecha);
            var sb = new StringBuilder();

            string fechaEncabezado = fecha.ToString("dd/MM/yyyy");
            sb.AppendLine("========================================================================");
            sb.AppendLine("ALMACÉN DEL LABORATORIO DE AUTOMATIZACIÓN - UAQ INGENIERÍA");
            sb.AppendLine("RESUMEN DIARIO DE MATERIALES");
            sb.AppendLine($"Fecha : {fechaEncabezado}");
            sb.AppendLine("========================================================================");
            sb.AppendLine();

            if (items.Count == 0)
            {
                sb.AppendLine("No se registraron vales de materiales en esta fecha.");
                return sb.ToString();
            }

            // Agrupar por Vale y Expediente
            var gruposPorVale = items
                .GroupBy(i => new { i.ValeId, i.Expediente, i.Solicitante })
                .ToList();

            foreach (var grupo in gruposPorVale)
            {
                string prefijo = $"(expediente) {grupo.Key.Expediente}";
                string indent = new string(' ', prefijo.Length + 3);

                bool esPrimero = true;
                foreach (var art in grupo)
                {
                    string infoArticulo = $"{art.DescripcionMaterial}";
                    if (art.Cantidad > 1)
                    {
                        infoArticulo += $" ({art.Cantidad} {art.Unidad})";
                    }

                    if (esPrimero)
                    {
                        sb.AppendLine($"{prefijo} - {infoArticulo}");
                        esPrimero = false;
                    }
                    else
                    {
                        sb.AppendLine($"{indent}{infoArticulo}");
                    }
                }
                sb.AppendLine();
            }

            sb.AppendLine("------------------------------------------------------------------------");
            sb.AppendLine($"Total de vales registrados: {gruposPorVale.Count} | Total de artículos pedidos: {items.Count}");
            sb.AppendLine("========================================================================");

            return sb.ToString();
        }

        public void MostrarVistaPreviaOImprimir(DateTime fecha, IWin32Window parent)
        {
            string textoAImprimir = GenerarTextoResumen(fecha, out _);

            using var printDoc = new PrintDocument();
            printDoc.DocumentName = $"Resumen_Materiales_{fecha:yyyyMMdd}";

            string[] lineas = textoAImprimir.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            int lineaActual = 0;

            printDoc.PrintPage += (sender, e) =>
            {
                if (e.Graphics == null) return;

                using var font = new Font("Courier New", 10, FontStyle.Regular);
                using var brush = new SolidBrush(Color.Black);

                float lineHeight = font.GetHeight(e.Graphics);
                float yPos = e.MarginBounds.Top;
                float xPos = e.MarginBounds.Left;

                while (lineaActual < lineas.Length)
                {
                    if (yPos + lineHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    e.Graphics.DrawString(lineas[lineaActual], font, brush, xPos, yPos);
                    yPos += lineHeight;
                    lineaActual++;
                }

                e.HasMorePages = false;
            };

            using var preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.Width = 850;
            preview.Height = 700;
            preview.StartPosition = FormStartPosition.CenterParent;
            preview.ShowDialog(parent);
        }
    }
}

