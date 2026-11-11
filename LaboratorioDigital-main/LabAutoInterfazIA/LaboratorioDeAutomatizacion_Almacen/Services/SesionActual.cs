using System;

namespace LaboratorioDeAutomatizacion_Almacen.Services
{
    public static class SesionActual
    {
        public static UsuarioLaboratorio? UsuarioLogueado { get; set; }

        public static bool HaySesion => UsuarioLogueado != null;
        public static bool EsAdministrativo => UsuarioLogueado?.EsAdministrativo ?? false;
        public static bool EsDirector => UsuarioLogueado?.EsDirector ?? false;

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
    }
}

