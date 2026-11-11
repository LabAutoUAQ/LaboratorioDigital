using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using LaboratorioDeAutomatizacion_Almacen.Models;

namespace LaboratorioDeAutomatizacion_Almacen.Data
{
    public class InventarioRepository
    {
        public List<InventarioItem> ObtenerTodos(bool soloConExistencia = false, string filtro = "")
        {
            var lista = new List<InventarioItem>();
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();

                string sql = "SELECT idinventario, idusuario, fecha, cantidad, unidad, descripcion, codigo, estatus, observaciones, resguardo, localizacion, idactualizo, fechaultima FROM INVENTARIO WHERE 1=1 ";

                if (soloConExistencia)
                {
                    sql += " AND cantidad > 0 ";
                }

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql += " AND (UPPER(codigo) LIKE :filtro OR UPPER(descripcion) LIKE :filtro OR UPPER(localizacion) LIKE :filtro) ";
                    cmd.Parameters.Add(new OracleParameter("filtro", $"%{filtro.Trim().ToUpper()}%"));
                }

                sql += " ORDER BY descripcion";
                cmd.CommandText = sql;

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearInventario(reader));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error ObtenerTodos Inventario: {ex.Message}");
            }
            return lista;
        }

        public InventarioItem? BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;

            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idinventario, idusuario, fecha, cantidad, unidad, descripcion, codigo, estatus, observaciones, resguardo, localizacion, idactualizo, fechaultima FROM INVENTARIO WHERE UPPER(codigo) = UPPER(:cod)";
                cmd.Parameters.Add(new OracleParameter("cod", codigo.Trim()));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return MapearInventario(reader);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorCodigo Inventario: {ex.Message}");
            }
            return null;
        }

        public InventarioItem? BuscarPorId(int id)
        {
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idinventario, idusuario, fecha, cantidad, unidad, descripcion, codigo, estatus, observaciones, resguardo, localizacion, idactualizo, fechaultima FROM INVENTARIO WHERE idinventario = :id";
                cmd.Parameters.Add(new OracleParameter("id", id));

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return MapearInventario(reader);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error BuscarPorId Inventario: {ex.Message}");
            }
            return null;
        }

        public bool AgregarMaterial(InventarioItem item, int idUsuarioCarga, out int nuevoId, out string error)
        {
            nuevoId = 0;
            error = string.Empty;

            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                // Siguiente ID de inventario
                using (var cmdId = conn.CreateCommand())
                {
                    cmdId.Transaction = trans;
                    cmdId.CommandText = "SELECT NVL(MAX(idinventario), 0) + 1 FROM INVENTARIO";
                    object? res = cmdId.ExecuteScalar();
                    nuevoId = res != null ? Convert.ToInt32(res) : 1;
                }

                item.Id = nuevoId;

                // 1. Insertar en INVENTARIO
                using (var cmdInv = conn.CreateCommand())
                {
                    cmdInv.Transaction = trans;
                    cmdInv.CommandText = @"
                        INSERT INTO INVENTARIO (
                            idinventario, idusuario, fecha, cantidad, unidad, descripcion, 
                            codigo, estatus, observaciones, resguardo, localizacion, idactualizo, fechaultima
                        ) VALUES (
                            :idinventario, :idusuario, SYSDATE, :cantidad, :unidad, :descripcion,
                            :codigo, :estatus, :observaciones, :resguardo, :localizacion, :idactualizo, SYSDATE
                        )";

                    cmdInv.Parameters.Add(new OracleParameter("idinventario", item.Id));
                    cmdInv.Parameters.Add(new OracleParameter("idusuario", idUsuarioCarga));
                    cmdInv.Parameters.Add(new OracleParameter("cantidad", item.Cantidad));
                    cmdInv.Parameters.Add(new OracleParameter("unidad", string.IsNullOrWhiteSpace(item.Unidad) ? "Pza" : item.Unidad.Trim()));
                    cmdInv.Parameters.Add(new OracleParameter("descripcion", item.Descripcion.Trim()));
                    cmdInv.Parameters.Add(new OracleParameter("codigo", item.Codigo.Trim()));
                    cmdInv.Parameters.Add(new OracleParameter("estatus", item.Estatus <= 0 ? 2 : item.Estatus));
                    cmdInv.Parameters.Add(new OracleParameter("observaciones", item.Observaciones ?? ""));
                    cmdInv.Parameters.Add(new OracleParameter("resguardo", string.IsNullOrWhiteSpace(item.Resguardo) ? "Alta Manual" : item.Resguardo));
                    cmdInv.Parameters.Add(new OracleParameter("localizacion", item.Localizacion ?? ""));
                    cmdInv.Parameters.Add(new OracleParameter("idactualizo", idUsuarioCarga));
                    cmdInv.ExecuteNonQuery();
                }

                // 2. Registrar en RESGUARMOV para historial de entrada inicial si cantidad > 0
                if (item.Cantidad > 0)
                {
                    int nextMovId = 1;
                    using (var cmdMovId = conn.CreateCommand())
                    {
                        cmdMovId.Transaction = trans;
                        cmdMovId.CommandText = "SELECT NVL(MAX(idmov), 0) + 1 FROM RESGUARMOV";
                        object? resM = cmdMovId.ExecuteScalar();
                        if (resM != null) nextMovId = Convert.ToInt32(resM);
                    }

                    using (var cmdMov = conn.CreateCommand())
                    {
                        cmdMov.Transaction = trans;
                        cmdMov.CommandText = @"
                            INSERT INTO RESGUARMOV (
                                idmov, idcompra, idusuario, fecha, idinventario, 
                                cantidad, unidad, descripcion, codigo, estatus, observaciones, localizacion
                            ) VALUES (
                                :idmov, 1, :idusuario, SYSDATE, :idinventario,
                                :cantidad, :unidad, :descripcion, :codigo, 2, 'Alta manual de material en almacén', :localizacion
                            )";
                        cmdMov.Parameters.Add(new OracleParameter("idmov", nextMovId));
                        cmdMov.Parameters.Add(new OracleParameter("idusuario", idUsuarioCarga));
                        cmdMov.Parameters.Add(new OracleParameter("idinventario", item.Id));
                        cmdMov.Parameters.Add(new OracleParameter("cantidad", item.Cantidad));
                        cmdMov.Parameters.Add(new OracleParameter("unidad", string.IsNullOrWhiteSpace(item.Unidad) ? "Pza" : item.Unidad.Trim()));
                        cmdMov.Parameters.Add(new OracleParameter("descripcion", item.Descripcion.Trim()));
                        cmdMov.Parameters.Add(new OracleParameter("codigo", item.Codigo.Trim()));
                        cmdMov.Parameters.Add(new OracleParameter("localizacion", item.Localizacion ?? ""));
                        cmdMov.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                error = ex.Message;
                return false;
            }
        }

        public bool ActualizarMaterial(InventarioItem item, int idUsuarioActualizo, out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    UPDATE INVENTARIO 
                    SET codigo = :codigo,
                        descripcion = :descripcion,
                        unidad = :unidad,
                        localizacion = :localizacion,
                        observaciones = :observaciones,
                        idactualizo = :idactualizo,
                        fechaultima = SYSDATE
                    WHERE idinventario = :id";

                cmd.Parameters.Add(new OracleParameter("codigo", item.Codigo.Trim()));
                cmd.Parameters.Add(new OracleParameter("descripcion", item.Descripcion.Trim()));
                cmd.Parameters.Add(new OracleParameter("unidad", string.IsNullOrWhiteSpace(item.Unidad) ? "Pza" : item.Unidad.Trim()));
                cmd.Parameters.Add(new OracleParameter("localizacion", item.Localizacion ?? ""));
                cmd.Parameters.Add(new OracleParameter("observaciones", item.Observaciones ?? ""));
                cmd.Parameters.Add(new OracleParameter("idactualizo", idUsuarioActualizo));
                cmd.Parameters.Add(new OracleParameter("id", item.Id));

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// SOLUCIÓN A REQUERIMIENTO: Modificación rápida de existencias con registro automático de movimiento.
        /// </summary>
        public bool ActualizarExistenciaConMovimiento(int idInventario, decimal nuevaCantidad, string motivo, int idUsuarioActualizo, out string error)
        {
            error = string.Empty;
            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                // 1. Obtener datos actuales del material
                decimal cantidadAnterior = 0;
                string descripcion = string.Empty;
                string codigo = string.Empty;
                string unidad = "Pza";
                string localizacion = string.Empty;

                using (var cmdSel = conn.CreateCommand())
                {
                    cmdSel.Transaction = trans;
                    cmdSel.CommandText = "SELECT cantidad, descripcion, codigo, unidad, localizacion FROM INVENTARIO WHERE idinventario = :id FOR UPDATE";
                    cmdSel.Parameters.Add(new OracleParameter("id", idInventario));
                    using var reader = cmdSel.ExecuteReader();
                    if (reader.Read())
                    {
                        cantidadAnterior = reader.IsDBNull(0) ? 0 : Convert.ToDecimal(reader.GetValue(0));
                        descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        codigo = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        unidad = reader.IsDBNull(3) ? "Pza" : reader.GetString(3);
                        localizacion = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    }
                    else
                    {
                        trans.Rollback();
                        error = "No se encontró el artículo de inventario especificado.";
                        return false;
                    }
                }

                // 2. Actualizar INVENTARIO
                using (var cmdUpd = conn.CreateCommand())
                {
                    cmdUpd.Transaction = trans;
                    cmdUpd.CommandText = @"
                        UPDATE INVENTARIO 
                        SET cantidad = :cant,
                            idactualizo = :idact,
                            fechaultima = SYSDATE 
                        WHERE idinventario = :id";
                    cmdUpd.Parameters.Add(new OracleParameter("cant", nuevaCantidad));
                    cmdUpd.Parameters.Add(new OracleParameter("idact", idUsuarioActualizo));
                    cmdUpd.Parameters.Add(new OracleParameter("id", idInventario));
                    cmdUpd.ExecuteNonQuery();
                }

                // 3. Registrar automáticamente en RESGUARMOV para trazabilidad
                decimal diferencia = nuevaCantidad - cantidadAnterior;
                if (diferencia != 0)
                {
                    int nextMovId = 1;
                    using (var cmdMovId = conn.CreateCommand())
                    {
                        cmdMovId.Transaction = trans;
                        cmdMovId.CommandText = "SELECT NVL(MAX(idmov), 0) + 1 FROM RESGUARMOV";
                        object? resM = cmdMovId.ExecuteScalar();
                        if (resM != null) nextMovId = Convert.ToInt32(resM);
                    }

                    string textoMov = string.IsNullOrWhiteSpace(motivo)
                        ? $"Ajuste rápido de existencia: {cantidadAnterior} -> {nuevaCantidad} (dif: {diferencia:+0.##;-0.##})"
                        : $"Ajuste existencia ({motivo}): {cantidadAnterior} -> {nuevaCantidad} (dif: {diferencia:+0.##;-0.##})";

                    using (var cmdMov = conn.CreateCommand())
                    {
                        cmdMov.Transaction = trans;
                        cmdMov.CommandText = @"
                            INSERT INTO RESGUARMOV (
                                idmov, idcompra, idusuario, fecha, idinventario, 
                                cantidad, unidad, descripcion, codigo, estatus, observaciones, localizacion
                            ) VALUES (
                                :idmov, 1, :idusuario, SYSDATE, :idinventario,
                                :cantidad, :unidad, :descripcion, :codigo, 2, :observaciones, :localizacion
                            )";
                        cmdMov.Parameters.Add(new OracleParameter("idmov", nextMovId));
                        cmdMov.Parameters.Add(new OracleParameter("idusuario", idUsuarioActualizo));
                        cmdMov.Parameters.Add(new OracleParameter("idinventario", idInventario));
                        cmdMov.Parameters.Add(new OracleParameter("cantidad", Math.Abs(diferencia)));
                        cmdMov.Parameters.Add(new OracleParameter("unidad", unidad));
                        cmdMov.Parameters.Add(new OracleParameter("descripcion", descripcion));
                        cmdMov.Parameters.Add(new OracleParameter("codigo", codigo));
                        cmdMov.Parameters.Add(new OracleParameter("observaciones", textoMov));
                        cmdMov.Parameters.Add(new OracleParameter("localizacion", localizacion));
                        cmdMov.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                error = ex.Message;
                return false;
            }
        }

        public bool VaciarInventario(out string error)
        {
            error = string.Empty;
            try
            {
                using var conn = ConexionBD.CrearConexion();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM INVENTARIO";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// SOLUCIÓN A OBSERVACIÓN NO. 2:
        /// Importación de CSV manteniendo la existencia real indicada en el archivo
        /// y generando el registro de entrada inicial en RESGUARDOS/RESGUARMOV para coherencia total.
        /// </summary>
        public bool ImportarDesdeCsv(string rutaCsv, bool vaciarAntes, int idUsuarioCarga, out int totalImportados, out string error)
        {
            totalImportados = 0;
            error = string.Empty;

            if (!File.Exists(rutaCsv))
            {
                error = "El archivo CSV especificado no existe.";
                return false;
            }

            using var conn = ConexionBD.CrearConexion();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                if (vaciarAntes)
                {
                    using var cmdDel = conn.CreateCommand();
                    cmdDel.Transaction = trans;
                    cmdDel.CommandText = "DELETE FROM INVENTARIO";
                    cmdDel.ExecuteNonQuery();
                }

                // Obtener o crear resguardo de Inventario Inicial para que las entradas cuadren
                int idCompraInicial = 1;
                using (var cmdRes = conn.CreateCommand())
                {
                    cmdRes.Transaction = trans;
                    cmdRes.CommandText = "SELECT NVL(MAX(idcompra), 0) + 1 FROM RESGUARDOS";
                    object? res = cmdRes.ExecuteScalar();
                    if (res != null) idCompraInicial = Convert.ToInt32(res);

                    cmdRes.CommandText = @"
                        INSERT INTO RESGUARDOS (idcompra, idusuario, fecha, referencia, idproveedor, contabilizada)
                        VALUES (:idcompra, :idusuario, SYSDATE, 'Carga Masiva CSV - Inventario Inicial', 1, 1)";
                    cmdRes.Parameters.Add(new OracleParameter("idcompra", idCompraInicial));
                    cmdRes.Parameters.Add(new OracleParameter("idusuario", idUsuarioCarga));
                    cmdRes.ExecuteNonQuery();
                }

                // Siguiente id de inventario y siguiente id de resguarmov
                int nextInvId = 1;
                using (var cmdId = conn.CreateCommand())
                {
                    cmdId.Transaction = trans;
                    cmdId.CommandText = "SELECT NVL(MAX(idinventario), 0) + 1 FROM INVENTARIO";
                    object? res = cmdId.ExecuteScalar();
                    if (res != null) nextInvId = Convert.ToInt32(res);
                }

                int nextMovId = 1;
                using (var cmdMovId = conn.CreateCommand())
                {
                    cmdMovId.Transaction = trans;
                    cmdMovId.CommandText = "SELECT NVL(MAX(idmov), 0) + 1 FROM RESGUARMOV";
                    object? res = cmdMovId.ExecuteScalar();
                    if (res != null) nextMovId = Convert.ToInt32(res);
                }

                using var reader = new StreamReader(rutaCsv);
                string? linea = reader.ReadLine(); // Encabezado

                while ((linea = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] partes = linea.Split(',');
                    if (partes.Length < 3) continue;

                    decimal.TryParse(partes[0].Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal cantidad);
                    string descripcion = partes[1].Trim().Replace("'", "");
                    string codigo = partes[2].Trim().Replace("'", "");
                    string localizacion = partes.Length >= 4 ? partes[3].Trim().Replace("'", "") : "";
                    string unidad = partes.Length >= 5 ? partes[4].Trim().Replace("'", "") : "PIEZA";

                    int currentId = nextInvId++;

                    // 1. Insertar en INVENTARIO con la cantidad/existencia indicada
                    using (var cmdInv = conn.CreateCommand())
                    {
                        cmdInv.Transaction = trans;
                        cmdInv.CommandText = @"
                            INSERT INTO INVENTARIO (
                                idinventario, idusuario, fecha, cantidad, unidad, descripcion, 
                                codigo, estatus, observaciones, resguardo, localizacion, idactualizo, fechaultima
                            ) VALUES (
                                :idinventario, :idusuario, SYSDATE, :cantidad, :unidad, :descripcion,
                                :codigo, 2, '', 'Inventario Inicial', :localizacion, :idactualizo, SYSDATE
                            )";
                        cmdInv.Parameters.Add(new OracleParameter("idinventario", currentId));
                        cmdInv.Parameters.Add(new OracleParameter("idusuario", idUsuarioCarga));
                        cmdInv.Parameters.Add(new OracleParameter("cantidad", cantidad));
                        cmdInv.Parameters.Add(new OracleParameter("unidad", unidad));
                        cmdInv.Parameters.Add(new OracleParameter("descripcion", descripcion));
                        cmdInv.Parameters.Add(new OracleParameter("codigo", codigo));
                        cmdInv.Parameters.Add(new OracleParameter("localizacion", localizacion));
                        cmdInv.Parameters.Add(new OracleParameter("idactualizo", idUsuarioCarga));
                        cmdInv.ExecuteNonQuery();
                    }

                    // 2. Registrar en RESGUARMOV para que la fórmula clásica (Entradas - Salidas) también sea válida
                    using (var cmdMov = conn.CreateCommand())
                    {
                        cmdMov.Transaction = trans;
                        cmdMov.CommandText = @"
                            INSERT INTO RESGUARMOV (
                                idmov, idcompra, idusuario, fecha, idinventario, 
                                cantidad, unidad, descripcion, codigo, estatus, observaciones, localizacion
                            ) VALUES (
                                :idmov, :idcompra, :idusuario, SYSDATE, :idinventario,
                                :cantidad, :unidad, :descripcion, :codigo, 2, 'Carga CSV', :localizacion
                            )";
                        cmdMov.Parameters.Add(new OracleParameter("idmov", nextMovId++));
                        cmdMov.Parameters.Add(new OracleParameter("idcompra", idCompraInicial));
                        cmdMov.Parameters.Add(new OracleParameter("idusuario", idUsuarioCarga));
                        cmdMov.Parameters.Add(new OracleParameter("idinventario", currentId));
                        cmdMov.Parameters.Add(new OracleParameter("cantidad", cantidad));
                        cmdMov.Parameters.Add(new OracleParameter("unidad", unidad));
                        cmdMov.Parameters.Add(new OracleParameter("descripcion", descripcion));
                        cmdMov.Parameters.Add(new OracleParameter("codigo", codigo));
                        cmdMov.Parameters.Add(new OracleParameter("localizacion", localizacion));
                        cmdMov.ExecuteNonQuery();
                    }

                    totalImportados++;
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                error = ex.Message;
                return false;
            }
        }

        public bool GuardarImagenParaCodigo(string codigo, string rutaArchivoOrigen, out string rutaGuardada, out string error)
        {
            rutaGuardada = string.Empty;
            error = string.Empty;
            try
            {
                if (!File.Exists(rutaArchivoOrigen))
                {
                    error = "El archivo de imagen origen no existe.";
                    return false;
                }

                string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "Inventario");
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string ext = Path.GetExtension(rutaArchivoOrigen);
                string archivoDestino = Path.Combine(carpetaDestino, $"{codigo}{ext}");

                File.Copy(rutaArchivoOrigen, archivoDestino, overwrite: true);
                rutaGuardada = archivoDestino;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private InventarioItem MapearInventario(OracleDataReader reader)
        {
            var item = new InventarioItem
            {
                Id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0)),
                IdUsuario = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetValue(1)),
                Fecha = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                Cantidad = reader.IsDBNull(3) ? 0 : Convert.ToDecimal(reader.GetValue(3)),
                Unidad = reader.IsDBNull(4) ? "Pza" : reader.GetString(4),
                Descripcion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                Codigo = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                Estatus = reader.IsDBNull(7) ? 2 : Convert.ToInt32(reader.GetValue(7)),
                Observaciones = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                Resguardo = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                Localizacion = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                IdActualizo = reader.IsDBNull(11) ? 0 : Convert.ToInt32(reader.GetValue(11)),
                FechaUltima = reader.IsDBNull(12) ? null : reader.GetDateTime(12)
            };

            item.ImagenPath = item.ObtenerRutaImagen();
            return item;
        }
    }
}
