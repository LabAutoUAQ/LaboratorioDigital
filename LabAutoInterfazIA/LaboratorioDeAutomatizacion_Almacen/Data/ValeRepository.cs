using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using LaboratorioDeAutomatizacion_Almacen.Models;

namespace LaboratorioDeAutomatizacion_Almacen.Data
{
    public class ValeRepository
    {
        public int ObtenerSiguienteIdVale()
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT NVL(MAX(vale), 0) + 1 FROM VALES";
                object? res = cmd.ExecuteScalar();
                return res != null ? Convert.ToInt32(res) : 1;
            }
            catch
            {
                return 1;
            }
        }

        public int ObtenerSiguienteIdMov()
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT NVL(MAX(idmov), 0) + 1 FROM VALEMOV";
                object? res = cmd.ExecuteScalar();
                return res != null ? Convert.ToInt32(res) : 1;
            }
            catch
            {
                return 1;
            }
        }

        public Vale? BuscarPorId(int valeId)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT v.vale, v.idusuario, v.fecha, v.materia, v.carrera, v.idautorizo, 
                           v.observaciones, v.impreso, v.idrecibio, v.fechaparaentregar, 
                           v.fechaentregado, v.multaportardanza,
                           u.usuario, u.expediente, u.email, u.celular,
                           ua.usuario AS autorizo_nombre,
                           ur.usuario AS recibio_nombre
                    FROM VALES v
                    LEFT JOIN USUARIOS u ON v.idusuario = u.idusuario
                    LEFT JOIN USUARIOS ua ON v.idautorizo = ua.idusuario
                    LEFT JOIN USUARIOS ur ON v.idrecibio = ur.idusuario
                    WHERE v.vale = :id";
                cmd.Parameters.Add(new OracleParameter("id", valeId));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var vale = new Vale
                    {
                        Id = Convert.ToInt32(reader["vale"]),
                        IdUsuario = Convert.ToInt32(reader["idusuario"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        Materia = reader.IsDBNull(reader.GetOrdinal("materia")) ? "" : reader["materia"].ToString() ?? "",
                        Carrera = reader.IsDBNull(reader.GetOrdinal("carrera")) ? "" : reader["carrera"].ToString() ?? "",
                        IdAutorizo = reader.IsDBNull(reader.GetOrdinal("idautorizo")) ? 0 : Convert.ToInt32(reader["idautorizo"]),
                        Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones")) ? "" : reader["observaciones"].ToString() ?? "",
                        Impreso = reader.IsDBNull(reader.GetOrdinal("impreso")) ? 0 : Convert.ToInt32(reader["impreso"]),
                        IdRecibio = reader.IsDBNull(reader.GetOrdinal("idrecibio")) ? 0 : Convert.ToInt32(reader["idrecibio"]),
                        FechaParaEntregar = reader.IsDBNull(reader.GetOrdinal("fechaparaentregar")) ? null : Convert.ToDateTime(reader["fechaparaentregar"]),
                        FechaEntregado = reader.IsDBNull(reader.GetOrdinal("fechaentregado")) ? null : Convert.ToDateTime(reader["fechaentregado"]),
                        MultaPorTardanza = reader.IsDBNull(reader.GetOrdinal("multaportardanza")) ? 0 : Convert.ToDecimal(reader["multaportardanza"]),
                        NombreUsuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader["usuario"].ToString() ?? "",
                        ExpedienteUsuario = reader.IsDBNull(reader.GetOrdinal("expediente")) ? "" : reader["expediente"].ToString() ?? "",
                        EmailUsuario = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader["email"].ToString() ?? "",
                        CelularUsuario = reader.IsDBNull(reader.GetOrdinal("celular")) ? "" : reader["celular"].ToString() ?? "",
                        NombreAutorizo = reader.IsDBNull(reader.GetOrdinal("autorizo_nombre")) ? "" : reader["autorizo_nombre"].ToString() ?? "",
                        NombreRecibio = reader.IsDBNull(reader.GetOrdinal("recibio_nombre")) ? "" : reader["recibio_nombre"].ToString() ?? ""
                    };

                    vale.Movimientos = ObtenerMovimientos(vale.Id, conn);
                    return vale;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorId Vale: {ex.Message}");
            }
            return null;
        }

        public List<ValeMovimiento> ObtenerMovimientos(int valeId, OracleConnection? connExistente = null)
        {
            var lista = new List<ValeMovimiento>();
            bool cerrar = false;
            OracleConnection conn = connExistente ?? ConexionBD.CrearConexion();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                cerrar = true;
            }

            try
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT vm.idmov, vm.vale, vm.idusuario, vm.fecha, vm.idinventario, 
                           vm.cantidad, vm.unidad, vm.recibido, vm.observaciones,
                           i.codigo, i.descripcion, NVL(i.cantidad, 0) AS stock_disponible
                    FROM VALEMOV vm
                    LEFT JOIN INVENTARIO i ON vm.idinventario = i.idinventario
                    WHERE vm.vale = :id
                    ORDER BY vm.idmov";
                cmd.Parameters.Add(new OracleParameter("id", valeId));

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ValeMovimiento
                    {
                        IdMov = Convert.ToInt32(reader["idmov"]),
                        ValeId = Convert.ToInt32(reader["vale"]),
                        IdUsuario = Convert.ToInt32(reader["idusuario"]),
                        Fecha = reader.IsDBNull(reader.GetOrdinal("fecha")) ? null : Convert.ToDateTime(reader["fecha"]),
                        IdInventario = Convert.ToInt32(reader["idinventario"]),
                        Cantidad = Convert.ToDecimal(reader["cantidad"]),
                        Unidad = reader.IsDBNull(reader.GetOrdinal("unidad")) ? "Pza" : reader["unidad"].ToString() ?? "Pza",
                        Recibido = reader.IsDBNull(reader.GetOrdinal("recibido")) ? 0 : Convert.ToDecimal(reader["recibido"]),
                        Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones")) ? "" : reader["observaciones"].ToString() ?? "",
                        Codigo = reader.IsDBNull(reader.GetOrdinal("codigo")) ? "" : reader["codigo"].ToString() ?? "",
                        Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader["descripcion"].ToString() ?? "",
                        StockDisponible = reader.IsDBNull(reader.GetOrdinal("stock_disponible")) ? 0 : Convert.ToDecimal(reader["stock_disponible"])
                    });
                }
            }
            finally
            {
                if (cerrar) conn.Close();
            }
            return lista;
        }

        public bool CrearNuevoVale(Vale vale, out string mensajeError)
        {
            mensajeError = string.Empty;
            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                vale.Id = ObtenerSiguienteIdVale();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = @"
                        INSERT INTO VALES (vale, idusuario, fecha, materia, carrera, idautorizo, observaciones, impreso, idrecibio, fechaparaentregar, multaportardanza)
                        VALUES (:vale, :idusuario, SYSDATE, :materia, :carrera, :idautorizo, :observaciones, 0, 0, :fechaparaentregar, 0)";
                    cmd.Parameters.Add(new OracleParameter("vale", vale.Id));
                    cmd.Parameters.Add(new OracleParameter("idusuario", vale.IdUsuario));
                    cmd.Parameters.Add(new OracleParameter("materia", vale.Materia ?? ""));
                    cmd.Parameters.Add(new OracleParameter("carrera", vale.Carrera ?? ""));
                    cmd.Parameters.Add(new OracleParameter("idautorizo", vale.IdAutorizo));
                    cmd.Parameters.Add(new OracleParameter("observaciones", vale.Observaciones ?? ""));
                    cmd.Parameters.Add(new OracleParameter("fechaparaentregar", vale.FechaParaEntregar ?? DateTime.Now.AddDays(1)));
                    cmd.ExecuteNonQuery();
                }

                int movId = ObtenerSiguienteIdMov();
                foreach (var m in vale.Movimientos)
                {
                    using var cmdMov = conn.CreateCommand();
                    cmdMov.Transaction = trans;
                    cmdMov.CommandText = @"
                        INSERT INTO VALEMOV (idmov, vale, idusuario, fecha, idinventario, cantidad, unidad, recibido, observaciones)
                        VALUES (:idmov, :vale, :idusuario, SYSDATE, :idinventario, :cantidad, :unidad, 0, :observaciones)";
                    cmdMov.Parameters.Add(new OracleParameter("idmov", movId++));
                    cmdMov.Parameters.Add(new OracleParameter("vale", vale.Id));
                    cmdMov.Parameters.Add(new OracleParameter("idusuario", vale.IdUsuario));
                    cmdMov.Parameters.Add(new OracleParameter("idinventario", m.IdInventario));
                    cmdMov.Parameters.Add(new OracleParameter("cantidad", m.Cantidad));
                    cmdMov.Parameters.Add(new OracleParameter("unidad", m.Unidad ?? "Pza"));
                    cmdMov.Parameters.Add(new OracleParameter("observaciones", m.Observaciones ?? ""));
                    cmdMov.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                mensajeError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// REQUERIMIENTO 2: Habilitar la modificación de vales existentes, requiriendo autorización nuevamente.
        /// </summary>
        public bool ModificarValeConReautorizacion(Vale vale, int idSupervisorAutorizo, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (idSupervisorAutorizo <= 0)
            {
                mensajeError = "Se requiere la autorización de un administrativo para guardar los cambios.";
                return false;
            }

            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                // 1. Actualizar cabecera del Vale con nueva autorización
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = @"
                        UPDATE VALES 
                        SET materia = :materia,
                            carrera = :carrera,
                            observaciones = :observaciones,
                            fechaparaentregar = :fechaparaentregar,
                            idautorizo = :idautorizo
                        WHERE vale = :id";
                    cmd.Parameters.Add(new OracleParameter("materia", vale.Materia ?? ""));
                    cmd.Parameters.Add(new OracleParameter("carrera", vale.Carrera ?? ""));
                    cmd.Parameters.Add(new OracleParameter("observaciones", vale.Observaciones ?? ""));
                    cmd.Parameters.Add(new OracleParameter("fechaparaentregar", vale.FechaParaEntregar ?? DateTime.Now.AddDays(1)));
                    cmd.Parameters.Add(new OracleParameter("idautorizo", idSupervisorAutorizo));
                    cmd.Parameters.Add(new OracleParameter("id", vale.Id));
                    cmd.ExecuteNonQuery();
                }

                // 2. Reemplazar partidas de VALEMOV para reflejar adiciones/eliminaciones/cambios
                using (var cmdDel = conn.CreateCommand())
                {
                    cmdDel.Transaction = trans;
                    cmdDel.CommandText = "DELETE FROM VALEMOV WHERE vale = :id";
                    cmdDel.Parameters.Add(new OracleParameter("id", vale.Id));
                    cmdDel.ExecuteNonQuery();
                }

                int movId = ObtenerSiguienteIdMov();
                foreach (var m in vale.Movimientos)
                {
                    using var cmdMov = conn.CreateCommand();
                    cmdMov.Transaction = trans;
                    cmdMov.CommandText = @"
                        INSERT INTO VALEMOV (idmov, vale, idusuario, fecha, idinventario, cantidad, unidad, recibido, observaciones)
                        VALUES (:idmov, :vale, :idusuario, SYSDATE, :idinventario, :cantidad, :unidad, :recibido, :observaciones)";
                    cmdMov.Parameters.Add(new OracleParameter("idmov", movId++));
                    cmdMov.Parameters.Add(new OracleParameter("vale", vale.Id));
                    cmdMov.Parameters.Add(new OracleParameter("idusuario", vale.IdUsuario));
                    cmdMov.Parameters.Add(new OracleParameter("idinventario", m.IdInventario));
                    cmdMov.Parameters.Add(new OracleParameter("cantidad", m.Cantidad));
                    cmdMov.Parameters.Add(new OracleParameter("unidad", m.Unidad ?? "Pza"));
                    cmdMov.Parameters.Add(new OracleParameter("recibido", m.Recibido));
                    cmdMov.Parameters.Add(new OracleParameter("observaciones", m.Observaciones ?? ""));
                    cmdMov.ExecuteNonQuery();
                }

                trans.Commit();
                vale.IdAutorizo = idSupervisorAutorizo;
                vale.RequiereReautorizacion = false;
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                mensajeError = ex.Message;
                return false;
            }
        }

        public bool RegistrarRecepcion(int valeId, int idSupervisorRecibio, List<ValeMovimiento> movimientos, out string mensajeError)
        {
            mensajeError = string.Empty;
            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                foreach (var m in movimientos)
                {
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = trans;
                    cmd.CommandText = "UPDATE VALEMOV SET recibido = :recibido, observaciones = :obs WHERE idmov = :idmov";
                    cmd.Parameters.Add(new OracleParameter("recibido", m.Recibido));
                    cmd.Parameters.Add(new OracleParameter("obs", m.Observaciones ?? ""));
                    cmd.Parameters.Add(new OracleParameter("idmov", m.IdMov));
                    cmd.ExecuteNonQuery();
                }

                using (var cmdVale = conn.CreateCommand())
                {
                    cmdVale.Transaction = trans;
                    cmdVale.CommandText = "UPDATE VALES SET idrecibio = :idrecibio, fechaentregado = SYSDATE WHERE vale = :id";
                    cmdVale.Parameters.Add(new OracleParameter("idrecibio", idSupervisorRecibio));
                    cmdVale.Parameters.Add(new OracleParameter("id", valeId));
                    cmdVale.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                mensajeError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// REQUERIMIENTO 1: Obtener listado conforme pasa el día de lo que se va pidiendo de manera resumida.
        /// Formato: Fecha : DD/MM/AAAA (expediente) 123456 - Multimetro / Fuente...
        /// </summary>
        public List<ResumenMaterialItem> ObtenerResumenMaterialesPorFecha(DateTime fecha)
        {
            var lista = new List<ResumenMaterialItem>();
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();

                string fechaStr = fecha.ToString("yyyy-MM-dd");
                cmd.CommandText = @"
                    SELECT v.vale, v.fecha, u.expediente, u.usuario, v.carrera,
                           NVL(i.codigo, 'S/C') AS codigo,
                           NVL(i.descripcion, vm.observaciones) AS descripcion,
                           vm.cantidad, vm.unidad, vm.observaciones
                    FROM VALES v
                    INNER JOIN USUARIOS u ON v.idusuario = u.idusuario
                    INNER JOIN VALEMOV vm ON v.vale = vm.vale
                    LEFT JOIN INVENTARIO i ON vm.idinventario = i.idinventario
                    WHERE TRUNC(v.fecha) = TO_DATE(:fec, 'YYYY-MM-DD')
                    ORDER BY v.fecha ASC, v.vale ASC, vm.idmov ASC";
                cmd.Parameters.Add(new OracleParameter("fec", fechaStr));

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ResumenMaterialItem
                    {
                        ValeId = Convert.ToInt32(reader["vale"]),
                        FechaHora = Convert.ToDateTime(reader["fecha"]),
                        Expediente = reader.IsDBNull(reader.GetOrdinal("expediente")) ? "0" : reader["expediente"].ToString() ?? "0",
                        Solicitante = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader["usuario"].ToString() ?? "",
                        Carrera = reader.IsDBNull(reader.GetOrdinal("carrera")) ? "" : reader["carrera"].ToString() ?? "",
                        CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("codigo")) ? "" : reader["codigo"].ToString() ?? "",
                        DescripcionMaterial = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader["descripcion"].ToString() ?? "",
                        Cantidad = Convert.ToDecimal(reader["cantidad"]),
                        Unidad = reader.IsDBNull(reader.GetOrdinal("unidad")) ? "Pza" : reader["unidad"].ToString() ?? "Pza",
                        Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones")) ? "" : reader["observaciones"].ToString() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error ObtenerResumenMaterialesPorFecha: {ex.Message}");
            }
            return lista;
        }

        public List<Vale> ObtenerValesSinEntregar()
        {
            var lista = new List<Vale>();
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT v.vale, v.idusuario, v.fecha, v.materia, v.carrera, v.idautorizo, 
                           v.observaciones, v.impreso, v.idrecibio, v.fechaparaentregar, 
                           v.fechaentregado, v.multaportardanza,
                           u.usuario, u.expediente
                    FROM VALES v
                    LEFT JOIN USUARIOS u ON v.idusuario = u.idusuario
                    WHERE v.idrecibio = 0 OR v.fechaentregado IS NULL
                    ORDER BY v.vale DESC";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Vale
                    {
                        Id = Convert.ToInt32(reader["vale"]),
                        IdUsuario = Convert.ToInt32(reader["idusuario"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        Materia = reader.IsDBNull(reader.GetOrdinal("materia")) ? "" : reader["materia"].ToString() ?? "",
                        Carrera = reader.IsDBNull(reader.GetOrdinal("carrera")) ? "" : reader["carrera"].ToString() ?? "",
                        IdAutorizo = reader.IsDBNull(reader.GetOrdinal("idautorizo")) ? 0 : Convert.ToInt32(reader["idautorizo"]),
                        Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones")) ? "" : reader["observaciones"].ToString() ?? "",
                        Impreso = reader.IsDBNull(reader.GetOrdinal("impreso")) ? 0 : Convert.ToInt32(reader["impreso"]),
                        IdRecibio = reader.IsDBNull(reader.GetOrdinal("idrecibio")) ? 0 : Convert.ToInt32(reader["idrecibio"]),
                        FechaParaEntregar = reader.IsDBNull(reader.GetOrdinal("fechaparaentregar")) ? null : Convert.ToDateTime(reader["fechaparaentregar"]),
                        NombreUsuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader["usuario"].ToString() ?? "",
                        ExpedienteUsuario = reader.IsDBNull(reader.GetOrdinal("expediente")) ? "" : reader["expediente"].ToString() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error ObtenerValesSinEntregar: {ex.Message}");
            }
            return lista;
        }
    }
}

