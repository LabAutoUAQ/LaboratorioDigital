using System;
using System.Collections.Generic;

namespace LaboratorioDeAutomatizacion_Almacen.Models
{
    public class Vale
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Materia { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public int IdAutorizo { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public int Impreso { get; set; } = 0;
        public int IdRecibio { get; set; }
        public DateTime? FechaParaEntregar { get; set; }
        public DateTime? FechaEntregado { get; set; }
        public decimal MultaPorTardanza { get; set; } = 0;

        // Datos del solicitante / prestatario
        public string NombreUsuario { get; set; } = string.Empty;
        public string ExpedienteUsuario { get; set; } = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public string CelularUsuario { get; set; } = string.Empty;

        // Datos del personal administrativo
        public string NombreAutorizo { get; set; } = string.Empty;
        public string NombreRecibio { get; set; } = string.Empty;

        // Partidas del vale
        public List<ValeMovimiento> Movimientos { get; set; } = new();

        // Estados lógicos
        public bool EstaAutorizado => IdAutorizo > 0;
        public bool EstaRecibido => IdRecibio > 0;
        public bool RequiereReautorizacion { get; set; }

        public decimal CalcularMulta(decimal tarifaPorDia)
        {
            if (FechaParaEntregar == null) return 0;
            DateTime fechaFin = FechaEntregado ?? DateTime.Now;
            if (fechaFin > FechaParaEntregar.Value)
            {
                int diasRetraso = (int)Math.Ceiling((fechaFin - FechaParaEntregar.Value).TotalDays);
                return diasRetraso > 0 ? diasRetraso * tarifaPorDia : 0;
            }
            return 0;
        }
    }
}

