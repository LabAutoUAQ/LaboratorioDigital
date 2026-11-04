using System;

namespace LaboratorioDeAutomatizacion_Almacen.Models
{
    public class ValeMovimiento
    {
        public int IdMov { get; set; }
        public int ValeId { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdInventario { get; set; }
        public decimal Cantidad { get; set; } = 1;
        public string Unidad { get; set; } = "Pza";
        public decimal Recibido { get; set; } = 0;
        public string Observaciones { get; set; } = string.Empty;

        // Propiedades auxiliares de despliegue y control de existencia
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal StockDisponible { get; set; } = 0;

        public bool ExcedeStock => Cantidad > StockDisponible;
        public string EstadoStock => ExcedeStock ? $"⚠ Excede stock (Disp: {StockDisponible})" : "✔ En stock";

        public bool EntregadoCompleto => Recibido >= Cantidad;
    }
}
