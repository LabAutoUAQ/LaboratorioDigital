using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace LaboratorioDeAutomatizacion_Almacen.Data
{
    public static class ConexionBD
    {
        public static readonly string Usuario = "FACINGENIERIAUSR";
        public static readonly string Clave = "K84uvrlnBTM18";
        public static readonly int Puerto = 1521;
        public static readonly string Sid = "XE";

        public static readonly string[] Servidores = new[]
        {
            "SERVIDOR",
            "DESARROLLO",
            "DIBUJOS",
            "localhost",
            "127.0.0.1"
        };

        private static string? _servidorActivo;
        private static string? _connectionString;

        public static string ServidorActivo => _servidorActivo ?? Servidores[0];

        public static string ObtenerCadenaConexion(string host)
        {
            return $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={Puerto}))(CONNECT_DATA=(SERVICE_NAME={Sid})));User Id={Usuario};Password={Clave};Connection Timeout=5;";
        }

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ObtenerCadenaConexion(ServidorActivo);
                }
                return _connectionString;
            }
            set => _connectionString = value;
        }

        public static OracleConnection CrearConexion()
        {
            return new OracleConnection(ConnectionString);
        }

        /// <summary>
        /// Busca el servidor activo probando la lista configurada.
        /// </summary>
        public static bool ProbarServidores(out string servidorConectado, out string mensajeError)
        {
            servidorConectado = string.Empty;
            mensajeError = string.Empty;

            foreach (var host in Servidores)
            {
                try
                {
                    string cad = ObtenerCadenaConexion(host);
                    using var conn = new OracleConnection(cad);
                    conn.Open();

                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT 1 FROM DUAL";
                    cmd.ExecuteScalar();

                    _servidorActivo = host;
                    _connectionString = cad;
                    servidorConectado = host;
                    return true;
                }
                catch (Exception ex)
                {
                    mensajeError = ex.Message;
                }
            }

            return false;
        }

        public static bool ProbarConexionActual(out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                using var conn = CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT 1 FROM DUAL";
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}

