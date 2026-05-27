using CPM.ReporteAuditoria.BusinessInterface;
using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using CPM.ReporteAuditoria.Models;
using CPM.ReporteAuditoria.OperationalManagement;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.Linq;
using System.Globalization;


namespace CPM.ReporteAuditoria.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAuditProcessor _auditProcessor;
        private readonly IUsuarioProcessor _usuarioProcessor;
        private readonly IBusinessUnitProcessor _oficinasProcessor;
        private readonly IExportarExcel _exportarExcelProcessor;

        public AuditoriaController(ILogger logger, IAuditProcessor auditProcessor, IUsuarioProcessor usuarioProcessor, IBusinessUnitProcessor businessUnitProcessor, IExportarExcel exportarExcelProcessor)
        {
            _logger = logger;
            _auditProcessor = auditProcessor;
            _usuarioProcessor = usuarioProcessor;
            _oficinasProcessor = businessUnitProcessor;
            _exportarExcelProcessor = exportarExcelProcessor;
        }
        // GET: Auditoria
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public ActionResult ReporteAuditorias()
        {
            _logger.Info("Inicio de vista CPM.ReporteAuditoria");
            ViewReporteAuditoriaModel modelo = new ViewReporteAuditoriaModel()
            {
                TipoOficinas = Oficinas.Diccionario,
                Operaciones = Operaciones.Diccionario,
                Eventos = Eventos.DiccionarioEstatico.Where(evento => evento.Key != 65 && evento.Key != 64).ToDictionary(evento => evento.Key, evento => evento.Value)
                

            };
            return View(modelo);
        }

        [HttpGet]
        public JsonResult RecuperarOficinas(int tipoOficina)
        {
            try
            {
                List<Sucursal> oficinas = _oficinasProcessor.RecuperarOficinas(tipoOficina);
                return Json(oficinas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new Exception($"Ocurrió un error al recuperar oficinas {ex.Message}");
            }
        }

        [HttpGet]
        public JsonResult RecuperarUsuarios(string oficinaId, int tipoOficina)
        {
            try
            {
                List<Usuario> usuarios = _usuarioProcessor.RecuperarUsuariosPorOficina(new Guid(oficinaId),tipoOficina);
                return Json(usuarios, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new Exception($"Ocurrió un error al recuperar usuarios {ex.Message}");
            }
        }

        [HttpGet]
        public JsonResult RecuperarUsuariosPorODG(string oficinaId)
        {
            try
            {
                List<Usuario> usuarios = _usuarioProcessor.RecuperarUsuariosPorODG(new Guid(oficinaId));
                return Json(usuarios, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new Exception($"Ocurrió un error al recuperar usuarios por ODG {ex.Message}");
            }
        }
        
        [HttpGet]
        public JsonResult RecuperarAuditoriasJson(List<Guid> usuariosId, string tipoOperacion, int tipoEvento, DateTime? fechaInicio, DateTime? fechaFin)
        {
            string auditorias = _auditProcessor.RecuperarTodasLasAuditorias(usuariosId, Convert.ToInt32(tipoOperacion), tipoEvento, fechaInicio, fechaFin);
            return Json(auditorias, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ExportarExcel(string usuariosSeleccionados, int tipoOperacion, int tipoEvento, string fechaInicio, string fechaFin)
        {
            try
            {
                _logger.Info($"Entrando a controlador ExportarExcel:  {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
                List<Guid> usuariosId = new List<Guid>();

                if (!string.IsNullOrEmpty(usuariosSeleccionados))
                {
                    usuariosId = usuariosSeleccionados
                        .Split(',')
                        .Where(id => Guid.TryParse(id, out _))
                        .Select(Guid.Parse)
                        .ToList();
                }
                DateTime? fechaInicioDt = null;
                DateTime? fechaFinDt = null;

                if (!string.IsNullOrWhiteSpace(fechaInicio) &&
                    DateTime.TryParse(fechaInicio, new CultureInfo("es-MX"), DateTimeStyles.None, out var fi))
                {
                    fechaInicioDt = fi;
                }

                if (!string.IsNullOrWhiteSpace(fechaFin) &&
                    DateTime.TryParse(fechaFin, new CultureInfo("es-MX"), DateTimeStyles.None, out var ff))
                {
                    fechaFinDt = ff;
                }
                // Formar listado de auditorías
                string auditoriasJson = _auditProcessor.RecuperarTodasLasAuditorias(usuariosId, tipoOperacion, tipoEvento, fechaInicioDt, fechaFinDt);
                List<Audit> auditorias  =_auditProcessor.FormarListadoAuditorias(auditoriasJson);
                
                //Formar Excel
                if (auditorias == null || auditorias.Count == 0)
                {
                    _logger.Info($"No se encontraron auditorías");
                    return new HttpStatusCodeResult(HttpStatusCode.NoContent, "No se encontraron registros.");
                }
                
                byte[] excelBytes = _exportarExcelProcessor.FormarExcel(auditorias);

                string fileName = $"Auditoria_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                _logger.Info($"Archivo en excel creado correctamente: {fileName} /Fecha:{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
                return File(
                    excelBytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName
                );

            }
            catch (Exception ex)
            {
                _logger.Error($"Ocurrió un error al exportar excel ${ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}