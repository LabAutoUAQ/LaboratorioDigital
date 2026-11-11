using System;

namespace LaboratorioDeAutomatizacion_Almacen.Models
{
    public class ParametrosSistema
    {
        public int Id { get; set; } = 1;
        public DateTime? Fecha { get; set; }
        public string Impresora { get; set; } = "TICKETS";
        public int Impresiones { get; set; } = 2;
        public DateTime? FechaUltima { get; set; }
        public decimal MultaPorTardanza { get; set; } = 0;
    }
}

