using ClosedXML.Excel;
using CPM.ReporteAuditoria.BusinessInterface;
using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.OperationalManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace CPM.ReporteAuditoria.BusinessLayer
{
    public class ExportarExcelProcessor : IExportarExcel
    {
        private readonly ILogger _logger;

        public ExportarExcelProcessor(ILogger logger)
        {
            _logger = logger;
        }
        public byte[] FormarExcel(List<Audit> auditorias)
        {
			try
			{
                _logger.Info($"Generando excel...");
                using (var workbook = new XLWorkbook())
                {
                    var hoja = workbook.Worksheets.Add("Auditoría");
                    string[] headers = { "Tipo de Registro", "Nombre", "Modificado por Usuario", "Nombre Completo", "Operación", "Evento", "Fecha Modificación", "Hora" };
                    for (int col = 0; col < headers.Length; col++)
                    {
                        var cell = hoja.Cell(1, col + 1);
                        cell.Value = headers[col];
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        hoja.Column(col + 4).AdjustToContents();
                    }

                    int row = 2;
                    foreach (var item in auditorias)
                    {
                        hoja.Cell(row, 1).Value = item.TipoRegistro;
                        hoja.Cell(row, 1).Style.Alignment.SetIndent(1);
                        hoja.Cell(row, 2).Value = item.Nombre;
                        hoja.Cell(row, 2).Style.Alignment.SetIndent(1);
                        hoja.Cell(row, 3).Value = item.UsuarioDominio;
                        hoja.Cell(row, 4).Value = item.TipoOperacion == 4 ? "SYSTEM" : item.UsuarioNombre;         
                        hoja.Cell(row, 5).Value = item.Operacion;
                        hoja.Cell(row, 6).Value = item.Evento;
                        var cellFecha = hoja.Cell(row, 7);
                        var cellHora = hoja.Cell(row, 8);
                        _logger.Info($"FechaCreacion recibida: {item.FechaCreacion}");

                        if (item.FechaCreacion.HasValue)
                        {
                            cellFecha.Value = item.FechaCreacion.Value.Date;
                            cellFecha.Style.DateFormat.Format = "dd/MM/yyyy";
                            cellHora.Value = item.FechaCreacion.Value.TimeOfDay;
                            cellHora.Style.DateFormat.Format = "HH:mm";
                        }

                        row++;
                    }

                    hoja.Columns().AdjustToContents();

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
			catch (Exception ex)
			{
                _logger.Error($"Ocurrió un error al generar el excel: {ex.Message}");
               throw;
			}
        }
    }
}
