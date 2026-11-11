using System;
using System.IO;

namespace LaboratorioDeAutomatizacion_Almacen.Models
{
    public class InventarioItem
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Cantidad { get; set; } = 1;
        public string Unidad { get; set; } = "Pza";
        public string Descripcion { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Estatus { get; set; } = 2; // 2: Disponible / Activo
        public string Observaciones { get; set; } = string.Empty;
        public string Resguardo { get; set; } = string.Empty;
        public string Localizacion { get; set; } = string.Empty;
        public int IdActualizo { get; set; }
        public DateTime? FechaUltima { get; set; }
        public string ImagenPath { get; set; } = string.Empty;

        public string ObtenerRutaImagen()
        {
            if (!string.IsNullOrEmpty(ImagenPath) && File.Exists(ImagenPath))
            {
                return ImagenPath;
            }

            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Inventario");
            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            string[] extensiones = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
            foreach (var ext in extensiones)
            {
                string rutaCodigo = Path.Combine(baseDir, $"{Codigo}{ext}");
                if (File.Exists(rutaCodigo)) return rutaCodigo;

                string rutaId = Path.Combine(baseDir, $"{Id}{ext}");
                if (File.Exists(rutaId)) return rutaId;
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Descripcion} (Existencia: {Cantidad})";
        }
    }
}
