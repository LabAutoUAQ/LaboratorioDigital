using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using LaboratorioDeAutomatizacion_Almacen.Models;

namespace LaboratorioDeAutomatizacion_Almacen.Data
{
    public class UsuarioRepository
    {
        public List<UsuarioLaboratorio> ObtenerTodos()
        {
            var lista = new List<UsuarioLaboratorio>();
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idusuario, fecha, usuario, expediente, clave, rol, estado, fechaultima, carrera, email, celular, privilegios FROM USUARIOS ORDER BY usuario";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearUsuario(reader));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error ObtenerTodos: {ex.Message}");
            }
            return lista;
        }

        public List<UsuarioLaboratorio> ObtenerAdministrativos()
        {
            var lista = new List<UsuarioLaboratorio>();
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idusuario, fecha, usuario, expediente, clave, rol, estado, fechaultima, carrera, email, celular, privilegios FROM USUARIOS WHERE rol < 2 AND estado = 1 ORDER BY usuario";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearUsuario(reader));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error ObtenerAdministrativos: {ex.Message}");
            }
            return lista;
        }

        public UsuarioLaboratorio? BuscarPorExpediente(string expediente)
        {
            if (!int.TryParse(expediente, out int expNum)) return null;

            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idusuario, fecha, usuario, expediente, clave, rol, estado, fechaultima, carrera, email, celular, privilegios FROM USUARIOS WHERE expediente = :exp";
                cmd.Parameters.Add(new OracleParameter("exp", expNum));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var u = MapearUsuario(reader);
                    u.TieneAdeudos = TieneAdeudos(u.Id);
                    return u;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorExpediente: {ex.Message}");
            }
            return null;
        }

        public UsuarioLaboratorio? BuscarPorNombre(string nombre)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idusuario, fecha, usuario, expediente, clave, rol, estado, fechaultima, carrera, email, celular, privilegios FROM USUARIOS WHERE UPPER(usuario) = UPPER(:nom)";
                cmd.Parameters.Add(new OracleParameter("nom", nombre.Trim()));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var u = MapearUsuario(reader);
                    u.TieneAdeudos = TieneAdeudos(u.Id);
                    return u;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorNombre: {ex.Message}");
            }
            return null;
        }

        public UsuarioLaboratorio? BuscarPorId(int id)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idusuario, fecha, usuario, expediente, clave, rol, estado, fechaultima, carrera, email, celular, privilegios FROM USUARIOS WHERE idusuario = :id";
                cmd.Parameters.Add(new OracleParameter("id", id));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return MapearUsuario(reader);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorId: {ex.Message}");
            }
            return null;
        }

        public bool TieneAdeudos(int idUsuario)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM VALES WHERE idusuario = :id AND fechaentregado IS NULL AND fechaparaentregar < SYSDATE";
                cmd.Parameters.Add(new OracleParameter("id", idUsuario));
                object? res = cmd.ExecuteScalar();
                if (res != null && Convert.ToInt32(res) > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error TieneAdeudos: {ex.Message}");
            }
            return false;
        }

        public bool ActualizarUltimaFecha(int idUsuario)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE USUARIOS SET fechaultima = SYSDATE WHERE idusuario = :id";
                cmd.Parameters.Add(new OracleParameter("id", idUsuario));
                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool CrearUsuario(UsuarioLaboratorio usuario, out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();

                int nuevoId = 1;
                using (var cmdId = conn.CreateCommand())
                {
                    cmdId.CommandText = "SELECT NVL(MAX(idusuario), 0) + 1 FROM USUARIOS";
                    object? res = cmdId.ExecuteScalar();
                    if (res != null) nuevoId = Convert.ToInt32(res);
                }

                usuario.Id = nuevoId;

                int expNum = 0;
                int.TryParse(usuario.Expediente, out expNum);

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO USUARIOS (
                        idusuario, fecha, usuario, expediente, clave, rol, 
                        estado, fechaultima, carrera, email, celular, privilegios
                    ) VALUES (
                        :id, SYSDATE, :nom, :exp, :clave, :rol, 
                        :est, SYSDATE, :carr, :email, :cel, :priv
                    )";

                cmd.Parameters.Add(new OracleParameter("id", usuario.Id));
                cmd.Parameters.Add(new OracleParameter("nom", usuario.Nombre.Trim()));
                cmd.Parameters.Add(new OracleParameter("exp", expNum));
                cmd.Parameters.Add(new OracleParameter("clave", usuario.Clave.Trim()));
                cmd.Parameters.Add(new OracleParameter("rol", (int)usuario.Rol));
                cmd.Parameters.Add(new OracleParameter("est", (int)usuario.Estado));
                cmd.Parameters.Add(new OracleParameter("carr", usuario.Carrera ?? ""));
                cmd.Parameters.Add(new OracleParameter("email", usuario.Email ?? ""));
                cmd.Parameters.Add(new OracleParameter("cel", usuario.Celular ?? ""));
                cmd.Parameters.Add(new OracleParameter("priv", usuario.Privilegios ?? ""));

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool ActualizarUsuario(UsuarioLaboratorio usuario, out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();

                int expNum = 0;
                int.TryParse(usuario.Expediente, out expNum);

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE USUARIOS 
                    SET usuario = :nom,
                        expediente = :exp,
                        clave = :clave,
                        rol = :rol,
                        estado = :est,
                        carrera = :carr,
                        email = :email,
                        celular = :cel,
                        privilegios = :priv,
                        fechaultima = SYSDATE
                    WHERE idusuario = :id";

                cmd.Parameters.Add(new OracleParameter("nom", usuario.Nombre.Trim()));
                cmd.Parameters.Add(new OracleParameter("exp", expNum));
                cmd.Parameters.Add(new OracleParameter("clave", usuario.Clave.Trim()));
                cmd.Parameters.Add(new OracleParameter("rol", (int)usuario.Rol));
                cmd.Parameters.Add(new OracleParameter("est", (int)usuario.Estado));
                cmd.Parameters.Add(new OracleParameter("carr", usuario.Carrera ?? ""));
                cmd.Parameters.Add(new OracleParameter("email", usuario.Email ?? ""));
                cmd.Parameters.Add(new OracleParameter("cel", usuario.Celular ?? ""));
                cmd.Parameters.Add(new OracleParameter("priv", usuario.Privilegios ?? ""));
                cmd.Parameters.Add(new OracleParameter("id", usuario.Id));

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool ActualizarRol(int idUsuario, RolUsuario nuevoRol, out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE USUARIOS SET rol = :rol, fechaultima = SYSDATE WHERE idusuario = :id";
                cmd.Parameters.Add(new OracleParameter("rol", (int)nuevoRol));
                cmd.Parameters.Add(new OracleParameter("id", idUsuario));
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool ActualizarClave(int idUsuario, string nuevaClave, out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE USUARIOS SET clave = :clave, fechaultima = SYSDATE WHERE idusuario = :id";
                cmd.Parameters.Add(new OracleParameter("clave", nuevaClave.Trim()));
                cmd.Parameters.Add(new OracleParameter("id", idUsuario));
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private UsuarioLaboratorio MapearUsuario(OracleDataReader reader)
        {
            int rolInt = reader.IsDBNull(5) ? 2 : Convert.ToInt32(reader.GetValue(5));
            var rol = (RolUsuario)rolInt;

            UsuarioLaboratorio usuario = rol switch
            {
                RolUsuario.Director => new Administrativo { Departamento = "Dirección" },
                RolUsuario.Almacenista => new Almacenista { Turno = "Matutino" },
                _ => new Prestatario()
            };

            usuario.Id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0));
            usuario.FechaRegistro = reader.IsDBNull(1) ? null : reader.GetDateTime(1);
            usuario.Nombre = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            usuario.Expediente = reader.IsDBNull(3) ? "0" : reader.GetValue(3).ToString() ?? "0";
            usuario.Clave = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            usuario.Rol = rol;
            usuario.Estado = (EstadoUsuario)(reader.IsDBNull(6) ? 1 : Convert.ToInt32(reader.GetValue(6)));
            usuario.FechaUltima = reader.IsDBNull(7) ? null : reader.GetDateTime(7);
            usuario.Carrera = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            usuario.Email = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
            usuario.Celular = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            usuario.Privilegios = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);

            return usuario;
        }
    }
}

