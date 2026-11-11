using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LaboratorioDeAutomatizacion_Almacen.Models;

namespace LaboratorioDeAutomatizacion_Almacen.Services
{
    public static class BusquedaFuzzyService
    {
        /// <summary>
        /// Normaliza texto removiendo acentos, signos de puntuación y convirtiendo a mayúsculas.
        /// </summary>
        public static string Normalizar(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            string normalizadoFormD = texto.Trim().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalizadoFormD)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                    {
                        sb.Append(char.ToUpperInvariant(c));
                    }
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Calcula la distancia de Levenshtein entre dos cadenas.
        /// </summary>
        public static int DistanciaLevenshtein(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return t?.Length ?? 0;
            if (string.IsNullOrEmpty(t)) return s.Length;

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }

        /// <summary>
        /// Calcula un índice de similitud entre 0.0 (nada parecido) y 1.0 (idéntico o contenido exacto).
        /// Contempla coincidencias exactas, prefijos, substrings y tolerancia a errores de escritura (typos).
        /// </summary>
        public static double CalcularSimilitud(string texto, string busqueda)
        {
            string tNorm = Normalizar(texto);
            string bNorm = Normalizar(busqueda);

            if (string.IsNullOrEmpty(bNorm)) return 1.0;
            if (string.IsNullOrEmpty(tNorm)) return 0.0;

            // 1. Coincidencia exacta
            if (tNorm.Equals(bNorm, StringComparison.OrdinalIgnoreCase)) return 1.0;

            // 2. Si contiene la búsqueda completa como substring
            if (tNorm.Contains(bNorm, StringComparison.OrdinalIgnoreCase))
            {
                // Mayor puntuación si empieza con la búsqueda
                if (tNorm.StartsWith(bNorm, StringComparison.OrdinalIgnoreCase)) return 0.95;
                return 0.85;
            }

            // 3. Comparación por palabras / tokens
            string[] palabrasTexto = tNorm.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] palabrasBusqueda = bNorm.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (palabrasBusqueda.Length == 0) return 1.0;

            double scoreTotal = 0.0;

            foreach (var pBusq in palabrasBusqueda)
            {
                double mejorMatchPalabra = 0.0;

                foreach (var pTexto in palabrasTexto)
                {
                    if (pTexto.Equals(pBusq, StringComparison.OrdinalIgnoreCase))
                    {
                        mejorMatchPalabra = Math.Max(mejorMatchPalabra, 1.0);
                        break;
                    }
                    if (pTexto.StartsWith(pBusq, StringComparison.OrdinalIgnoreCase))
                    {
                        mejorMatchPalabra = Math.Max(mejorMatchPalabra, 0.90);
                        continue;
                    }
                    if (pTexto.Contains(pBusq, StringComparison.OrdinalIgnoreCase))
                    {
                        mejorMatchPalabra = Math.Max(mejorMatchPalabra, 0.80);
                        continue;
                    }

                    // Levenshtein con tolerancia proporcional a la longitud
                    int dist = DistanciaLevenshtein(pTexto, pBusq);
                    int maxLen = Math.Max(pTexto.Length, pBusq.Length);
                    if (maxLen > 0)
                    {
                        double sim = 1.0 - ((double)dist / maxLen);
                        // Permitir typos de 1 caracter para palabras cortas y 2 para largas
                        if ((maxLen <= 4 && dist <= 1) || (maxLen > 4 && dist <= 2))
                        {
                            mejorMatchPalabra = Math.Max(mejorMatchPalabra, Math.Max(sim, 0.65));
                        }
                        else
                        {
                            mejorMatchPalabra = Math.Max(mejorMatchPalabra, sim * 0.5);
                        }
                    }
                }

                scoreTotal += mejorMatchPalabra;
            }

            return scoreTotal / palabrasBusqueda.Length;
        }

        /// <summary>
        /// Filtra y ordena artículos de inventario contemplando tolerancia a errores tipográficos.
        /// </summary>
        public static List<InventarioItem> FiltrarInventario(IEnumerable<InventarioItem> items, string busqueda, double umbralMinimo = 0.60)
        {
            if (string.IsNullOrWhiteSpace(busqueda)) return items.ToList();

            var resultados = new List<(InventarioItem Item, double Score)>();

            foreach (var item in items)
            {
                double scoreDesc = CalcularSimilitud(item.Descripcion, busqueda);
                double scoreCod = CalcularSimilitud(item.Codigo, busqueda);
                double scoreLoc = CalcularSimilitud(item.Localizacion, busqueda);
                double scoreObs = CalcularSimilitud(item.Observaciones, busqueda);

                double maxScore = Math.Max(Math.Max(scoreDesc, scoreCod), Math.Max(scoreLoc, scoreObs));

                if (maxScore >= umbralMinimo)
                {
                    resultados.Add((item, maxScore));
                }
            }

            return resultados
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Item.Descripcion)
                .Select(r => r.Item)
                .ToList();
        }

        /// <summary>
        /// Filtra y ordena usuarios contemplando tolerancia a errores tipográficos en nombre, expediente, etc.
        /// </summary>
        public static List<UsuarioLaboratorio> FiltrarUsuarios(IEnumerable<UsuarioLaboratorio> usuarios, string busqueda, double umbralMinimo = 0.60)
        {
            if (string.IsNullOrWhiteSpace(busqueda)) return usuarios.ToList();

            var resultados = new List<(UsuarioLaboratorio Usuario, double Score)>();

            foreach (var u in usuarios)
            {
                double scoreNom = CalcularSimilitud(u.Nombre, busqueda);
                double scoreExp = CalcularSimilitud(u.Expediente, busqueda);
                double scoreCarr = CalcularSimilitud(u.Carrera, busqueda);
                double scoreEmail = CalcularSimilitud(u.Email, busqueda);

                double maxScore = Math.Max(Math.Max(scoreNom, scoreExp), Math.Max(scoreCarr, scoreEmail));

                if (maxScore >= umbralMinimo)
                {
                    resultados.Add((u, maxScore));
                }
            }

            return resultados
                .OrderByDescending(r => r.Score)
                .ThenBy(r => r.Usuario.Nombre)
                .Select(r => r.Usuario)
                .ToList();
        }
    }
}

