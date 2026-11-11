using System;

namespace LaboratorioDeAutomatizacion_Almacen
{
    public enum RolUsuario
    {
        Director = 0,
        Almacenista = 1,
        Docente = 2,
        Alumno = 3,
        Trabajador = 4
    }

    public enum EstadoUsuario
    {
        Baja = 0,
        Alta = 1,
        Suspendido = 2,
        Vacaciones = 3
    }

    public abstract class UsuarioLaboratorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Expediente { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; } = RolUsuario.Docente;
        public EstadoUsuario Estado { get; set; } = EstadoUsuario.Alta;
        public string Carrera { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Privilegios { get; set; } = string.Empty;
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUltima { get; set; }
        public bool TieneAdeudos { get; set; }

        public bool EsAdministrativo => Rol == RolUsuario.Director || Rol == RolUsuario.Almacenista;
        public bool EsDirector => Rol == RolUsuario.Director;

        public bool ValidarClave(string claveIngresada)
        {
            if (string.IsNullOrEmpty(claveIngresada)) return false;
            return string.Equals(Clave?.Trim(), claveIngresada.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public bool PuedeAbrir(string modulo)
        {
            if (EsDirector) return true;
            return !string.IsNullOrEmpty(Privilegios) && Privilegios.Contains(modulo);
        }

        public static string ObtenerNombreRol(RolUsuario rol) => rol switch
        {
            RolUsuario.Director => "Director",
            RolUsuario.Almacenista => "Almacenista",
            RolUsuario.Docente => "Docente",
            RolUsuario.Alumno => "Alumno(a)",
            RolUsuario.Trabajador => "Trabajador(a)",
            _ => "Desconocido"
        };

        public static string ObtenerNombreEstado(EstadoUsuario estado) => estado switch
        {
            EstadoUsuario.Baja => "Baja",
            EstadoUsuario.Alta => "Alta",
            EstadoUsuario.Suspendido => "Suspendido",
            EstadoUsuario.Vacaciones => "Vacaciones",
            _ => "Desconocido"
        };
    }

    public class Administrativo : UsuarioLaboratorio
    {
        public string Departamento { get; set; } = string.Empty;

        public Administrativo()
        {
            Rol = RolUsuario.Director;
        }
    }

    public class Almacenista : UsuarioLaboratorio
    {
        public string Turno { get; set; } = string.Empty;

        public Almacenista()
        {
            Rol = RolUsuario.Almacenista;
        }
    }

    public class Prestatario : UsuarioLaboratorio
    {
        public int Semestre { get; set; }

        public Prestatario()
        {
            Rol = RolUsuario.Alumno;
        }
    }
}
