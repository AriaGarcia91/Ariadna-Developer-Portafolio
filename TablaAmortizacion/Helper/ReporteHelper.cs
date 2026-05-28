using BG_CreacionTablaAmortizacion.BussinesType;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BG_CreacionTablaAmortizacion.Helper
{
    public static class ReporteHelper
    {
        public static string GenerarTablaAmortizacionBase64(
            byte[] plantillaPdfOriginal,
            List<SimuladorResponseModel.Amortizacion> amortizaciones,
            OportunidadModel oportunidad,
            ITracingService tracing)
        {
            try
            {
                using (var resultadoStream = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(new MemoryStream(plantillaPdfOriginal));
                    PdfWriter writer = new PdfWriter(resultadoStream);
                    PdfDocument pdfDoc = new PdfDocument(reader, writer);

                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                    // Configuración mejorada para alineación
                    float margenIzquierdo = 40f;
                    float anchoTabla = 520f;
                    int paginaActual = 1;
                    int filaActual = 0;
                    int totalFilas = amortizaciones.Count;

                    // Ajustar altura por fila
                    float alturaPorFila = 16f;

                    // Eliminar segunda página si tiene menos de 30 registros
                    if (amortizaciones.Count <= 30 && pdfDoc.GetNumberOfPages() >= 2)
                    {
                        pdfDoc.RemovePage(2);
                    }

                    decimal totalCapital = 0;
                    decimal totalInteres = 0;
                    decimal totalDividendo = 0;
                    decimal totalSeguro = 0;
                    decimal totalDivTotal = 0;


                    while (filaActual < totalFilas)
                    {
                        // Determinar posición según la página
                        float posicionY;
                        float alturaDisponible;
                        int filasPorPagina;

                        if (paginaActual == 1)
                        {
                            posicionY = 30f; // Más abajo para primera página 200
                            alturaDisponible = 480f; // Altura para primera página 310
                            filasPorPagina = (int)(alturaDisponible / alturaPorFila);
                        }
                        else
                        {
                            posicionY = 50f; // Más arriba para páginas siguientes
                            alturaDisponible = 680f; // Más espacio
                            filasPorPagina = (int)(alturaDisponible / alturaPorFila);
                            //pdfDoc.AddNewPage();
                         
                        }

                        int filasEnEstaPagina = Math.Min(filasPorPagina, totalFilas - filaActual);

                        // Crear tabla con anchos específicos para mejor alineación
                        float[] columnWidths = { 35f, 65f, 35f, 70f, 70f, 70f, 65f, 70f, 80f };
                        Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();
                        table.SetFont(font).SetFontSize(8);

                        // Agregar encabezados
                        //AddTableHeaders(table);

                        // Agregar filas con formato consistente
                        for (int i = 0; i < filasEnEstaPagina; i++)
                        {
                            var a = amortizaciones[filaActual + i];
                            AddTableRow(table, a, i + filaActual + 1);

                            decimal capital = TryParseDecimal(a.TCapital);
                            decimal interes = TryParseDecimal(a.TInteres);
                            decimal dividendo = TryParseDecimal(a.TDividendo);
                            decimal seguro = TryParseDecimal(a.TSeguro);

                            totalCapital += capital;
                            totalInteres += interes;
                            totalDividendo += dividendo;
                            totalSeguro += seguro;
                            totalDivTotal += dividendo + seguro;

                        }
                        
                        table.AddCell(CreateCell("", TextAlignment.CENTER));
                        table.AddCell(CreateCell("", TextAlignment.CENTER));
                        table.AddCell(CreateCell("", TextAlignment.CENTER));
                        table.AddCell(CreateCell(FormatNumericValue(totalCapital), TextAlignment.RIGHT));
                        table.AddCell(CreateCell(FormatNumericValue(totalInteres), TextAlignment.RIGHT));
                        table.AddCell(CreateCell(FormatNumericValue(totalDividendo), TextAlignment.RIGHT));
                        table.AddCell(CreateCell(FormatNumericValue(totalSeguro), TextAlignment.RIGHT));
                        table.AddCell(CreateCell(FormatNumericValue(totalDivTotal), TextAlignment.RIGHT));
                        table.AddCell(CreateCell("", TextAlignment.RIGHT)); // Cap. Reducido

                        // Dibujar tabla
                        var area = new iText.Kernel.Geom.Rectangle(
                            margenIzquierdo,
                            posicionY,
                            anchoTabla,
                            alturaDisponible);

                        var page = pdfDoc.GetPage(paginaActual);
                        var pdfCanvas = new PdfCanvas(page);
                        var canvas = new Canvas(pdfCanvas, area);

                        canvas.Add(table);
                        canvas.Close();

                        filaActual += filasEnEstaPagina;
                        paginaActual++;
                    }

                    pdfDoc.Close();
                    return Convert.ToBase64String(resultadoStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                tracing.Trace("Error generando PDF: " + ex.ToString());
                throw new InvalidPluginExecutionException("Error generando el PDF", ex);
            }
        }

        #region Métodos de Tabla Mejorados

        private static void AddTableHeaders(Table table)
        {
            table.AddHeaderCell(CreateHeaderCell("N°", TextAlignment.CENTER));
            table.AddHeaderCell(CreateHeaderCell("Fecha", TextAlignment.CENTER));
            table.AddHeaderCell(CreateHeaderCell("Plazo", TextAlignment.CENTER));
            table.AddHeaderCell(CreateHeaderCell("Capital", TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Interés", TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Dividendo", TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Seguro", TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Total", TextAlignment.RIGHT));
            table.AddHeaderCell(CreateHeaderCell("Cap. Reducido", TextAlignment.RIGHT));
        }

        private static void AddTableRow(Table table, SimuladorResponseModel.Amortizacion amortizacion, int numeroFila)
        {
            decimal dividendo = TryParseDecimal(amortizacion.TDividendo);
            decimal seguro = TryParseDecimal(amortizacion.TSeguro);
            decimal divTotal = dividendo + seguro;

            // Usar métodos mejorados de formateo           
            table.AddCell(CreateCell(numeroFila.ToString(), TextAlignment.CENTER));
            table.AddCell(CreateCell(FormatDate(amortizacion.TFecha1), TextAlignment.CENTER));
            table.AddCell(CreateCell(amortizacion.TPlazo, TextAlignment.CENTER));
            table.AddCell(CreateCell(FormatNumericValue(amortizacion.TCapital, 2), TextAlignment.RIGHT));
            table.AddCell(CreateCell(FormatNumericValue(amortizacion.TInteres, 2), TextAlignment.RIGHT));
            table.AddCell(CreateCell(FormatNumericValue(amortizacion.TDividendo, 2), TextAlignment.RIGHT));
            table.AddCell(CreateCell(FormatNumericValue(amortizacion.TSeguro, 2), TextAlignment.RIGHT));
            table.AddCell(CreateCell(FormatNumericValue(divTotal, 2), TextAlignment.RIGHT));
            table.AddCell(CreateCell(FormatNumericValue(amortizacion.TCapReducido, 2), TextAlignment.RIGHT));
        }

        private static Cell CreateHeaderCell(string text, TextAlignment alignment)
        {
            PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            return new Cell()
                .Add(new Paragraph(text))
                .SetFont(fontBold)
                .SetFontSize(8)
                .SetTextAlignment(alignment)
                .SetBorderBottom(new SolidBorder(1))
                .SetBorderTop(new SolidBorder(1))
                .SetPadding(3)
                .SetMarginBottom(1);
        }

        private static Cell CreateCell(string text, TextAlignment alignment)
        {
            return new Cell()
                .Add(new Paragraph(text ?? ""))
                .SetFontSize(8)
                .SetTextAlignment(alignment)
                .SetBorder(Border.NO_BORDER)
                .SetPadding(2)
                .SetMarginBottom(1);
        }

        #endregion

        #region Métodos de Formateo Mejorados

        private static string FormatDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return "";

            // Intentar formatear la fecha si viene en formato numérico (ej: "0801/2026")
            if (dateString.Length >= 6 && dateString.Contains("/"))
            {
                try
                {
                    // Formato esperado: "0801/2026" (ddMM/yyyy)
                    string[] parts = dateString.Split('/');
                    if (parts.Length == 2 && parts[0].Length == 4 && parts[1].Length == 4)
                    {
                        string day = parts[0].Substring(0, 2);
                        string month = parts[0].Substring(2, 2);
                        string year = parts[1];

                        return $"{day}/{month}/{year}";
                    }
                }
                catch
                {
                    // Si falla, devolver el original
                }
            }

            return dateString;
        }

        private static string FormatNumericValue(string value, int decimalPlaces = 2)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new string(' ', 8 - decimalPlaces) + "0." + new string('0', decimalPlaces);

            // Limpiar el valor
            value = value.Trim();

            // Remover caracteres no numéricos excepto punto, coma y signo negativo
            string cleaned = new string(value.Where(c => char.IsDigit(c) || c == '.' || c == ',' || c == '-').ToArray());

            if (decimal.TryParse(cleaned.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
            {
                // Formatear con separador de miles y decimales
                string format = $"#,##0.{new string('0', decimalPlaces)}";
                return decimalValue.ToString(format, CultureInfo.InvariantCulture);
            }

            return value.PadLeft(10); // Devolver alineado si no es numérico
        }

        private static string FormatNumericValue(decimal value, int decimalPlaces = 2)
        {
            string format = $"#,##0.{new string('0', decimalPlaces)}";
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        private static string FormatNumericValue(decimal? value, int decimalPlaces = 2)
        {
            if (!value.HasValue)
                return new string(' ', 8 - decimalPlaces) + "0." + new string('0', decimalPlaces);

            string format = $"#,##0.{new string('0', decimalPlaces)}";
            return value.Value.ToString(format, CultureInfo.InvariantCulture);
        }

        private static decimal TryParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0m;

            value = value.Trim();

            // Intentar diferentes estrategias de parseo
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            if (decimal.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;

            // Intentar extraer solo los números
            string numbersOnly = new string(value.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            if (decimal.TryParse(numbersOnly.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return result;

            return 0m;
        }

        #endregion

        public static byte[] MapearValoresEnPlantilla(
            byte[] plantillaPdf,
            SimuladorResponseModel.Resultado resultado,
            OportunidadModel oportunidad,
            ITracingService tracing)
        {
            using (MemoryStream outputStream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(new MemoryStream(plantillaPdf));
                PdfWriter writer = new PdfWriter(outputStream);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                IDictionary<string, PdfFormField> fields = form.GetFormFields();

                // Mapear valores con formato mejorado
                SetSafeField(fields, "cliente", oportunidad?.NombreCliente);
                SetSafeField(fields, "capital", FormatNumericValue(resultado?.TotCapital, 2));
                SetSafeField(fields, "solca", FormatNumericValue(resultado?.TotSolca, 2));
                SetSafeField(fields, "impuesto", FormatNumericValue(resultado?.TotImpuesto, 2));
                SetSafeField(fields, "com_administrativa", "");
                SetSafeField(fields, "rec_firma", "");

                //SetSafeField(fields, "periodo", resultado?.CntItem?.ToString());
                SetSafeField(fields, "periodo", oportunidad.Plazo);
                //SetSafeField(fields, "cuotas", resultado?.MargenReaj?.ToString());
                SetSafeField(fields, "cuotas", oportunidad.Periodicidad);
                //SetSafeField(fields, "tasa_interes", FormatNumericValue(resultado?.TotInteres, 2));
                SetSafeField(fields, "tasa_interes", FormatNumericValue(resultado?.TasaIntNominal, 2));
                SetSafeField(fields, "tasa_comision",  "0"/*FormatNumericValue(resultado?.TotComision, 2)*/);
                SetSafeField(fields, "desgravamen", FormatNumericValue(resultado?.DesgravamenValor, 2));
                //SetSafeField(fields, "fiducia_mensual", "");
                //SetSafeField(fields, "p_gracia_cap", "");
                //SetSafeField(fields, "p_gracia_int", "");
                SetSafeField(fields, "cesantía", "S");

                tracing.Trace($"Tipo Tabla {oportunidad?.TipoTabla}");
                tracing.Trace($"Neto {resultado?.TotValorNeto}");
                tracing.Trace($"Fecha {DateTime.Now.ToString("dd/MM/yyyy")}");

                SetSafeField(fields, "fecha", DateTime.Now.ToString("dd/MM/yyyy"));
                SetSafeField(fields, "modelo_tabla", oportunidad?.TipoTabla);
                SetSafeField(fields, "fiducia_mensual", "0");
                SetSafeField(fields, "p_gracia_cap", "0");
                SetSafeField(fields, "p_gracia_int", "0");
                SetSafeField(fields, "aseguradora", "CHUBB SEGUROS");
                SetSafeField(fields, "com_administrativa", "0");
                SetSafeField(fields, "rec_firma", "0");
                SetSafeField(fields, "neto", FormatNumericValue(resultado?.TotValorNeto, 2));

                foreach (var field in fields)
                {
                    tracing.Trace($"Campo PDF encontrado: {field.Key}");
                }


                form.FlattenFields();
                pdfDoc.Close();

                return outputStream.ToArray();
            }
        }

        private static void SetSafeField(IDictionary<string, PdfFormField> fields, string fieldName, string value)
        {
            if (fields.ContainsKey(fieldName))
            {
                fields[fieldName].SetValue(value ?? "");
            }
        }
    }
}