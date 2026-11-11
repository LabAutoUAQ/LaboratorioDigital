using System;
using System.Collections.Generic;

namespace LaboratorioDeAutomatizacion_Almacen.Models
{
    public class ResumenMaterialItem
    {
        public int ValeId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Expediente { get; set; } = string.Empty;
        public string Solicitante { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public string CodigoMaterial { get; set; } = string.Empty;
        public string DescripcionMaterial { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; } = "Pza";
        public string Observaciones { get; set; } = string.Empty;
    }

    public class ResumenExpedienteGrupo
    {
        public string Expediente { get; set; } = string.Empty;
        public string Solicitante { get; set; } = string.Empty;
        public List<string> Materiales { get; set; } = new();
    }
}

