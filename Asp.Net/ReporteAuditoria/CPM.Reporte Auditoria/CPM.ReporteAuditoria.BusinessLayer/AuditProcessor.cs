using CPM.ReporteAuditoria.BusinessInterface;
using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer;
using CPM.ReporteAuditoria.OperationalManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPM.ReporteAuditoria.BusinessLayer
{
    public class AuditProcessor:IAuditProcessor
    {
        private readonly IAuditRepository _auditRepository;
        private readonly ILogger _logger;

        public AuditProcessor(IAuditRepository auditRepository,ILogger logger)
        {
            _auditRepository = auditRepository;
            _logger = logger;
        }


        public BitacoraPaginado RecuperarAuditorias(Guid usuarioId, int tipoOperacion,int tipoEvento, int paginaActual, int numeroElementos,Eventos eventos,string fechaCreacion)
        {

            if (usuarioId == null || usuarioId == Guid.Empty)
                return null;
            BitacoraPaginado bitacora = new BitacoraPaginado();
            bitacora = _auditRepository.RecuperarAuditorias(usuarioId, tipoOperacion,tipoEvento, fechaCreacion,paginaActual,numeroElementos,eventos);
            
            return bitacora;

        }

        public string RecuperarTodasLasAuditorias(List<Guid> usuariosId, int tipoOperacion, int tipoEvento, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                _logger.Info("Consultando Auditorias processor...");
                string auditorias = _auditRepository.RecuperarTodasLasAuditorias(usuariosId, tipoOperacion, tipoEvento,fechaInicio,fechaFin);
                return auditorias;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new Exception($"Ocurrió un error al consultar las auditorias {ex.Message}");
            }
        }

        public List<Audit> FormarListadoAuditorias(string auditoriasJson)
        {
            try
            {
                _logger.Info($"Desearilizando JSON y formando el listado de auditorias");
                List<Audit> auditoriasCrudas = JsonConvert.DeserializeObject<List<Audit>>(auditoriasJson);
                //Validar el evento si es 4 agregar el nombre de usuario correspondiente al registro modifcado solo en caso de accesps
                return auditoriasCrudas.Select(a => new Audit
                {
                    UsuarioNombre = a.UsuarioNombre ?? "Desconocido",
                    UsuarioDominio = a.UsuarioDominio ?? "Desconocido",
                    Nombre = a.Nombre ?? "Sin nombre",
                    TipoRegistro = a.TipoRegistro,
                    ObjectId = a.ObjectId.ToString(),
                    Operacion = Operaciones.Diccionario.TryGetValue(a.TipoOperacion, out var op) ? op : "Desconocido",
                    Evento = Eventos.DiccionarioEstatico.TryGetValue(a.TipoEvento, out var ev) ? ev : "Desconocido",
                    TipoOperacion = a.TipoOperacion,
                    TipoEvento = a.TipoEvento,
                    FechaCreacion = a.FechaCreacion
                   }).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error($"Ocurrió un error al deserializar json auditorias y formar el listado: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public BitacoraDetalleAudit RecuperarDetalleAuditoria(string entityName, string registroId, int paginaActual, int numeroElementos)
        {
            BitacoraDetalleAudit detalles = new BitacoraDetalleAudit();
            detalles = _auditRepository.ShowRetrieveRecordChangeHistory(entityName, registroId, paginaActual, numeroElementos);
            return detalles;
        }

        public void RefrescarEventosAudit()
        {
            throw new NotImplementedException();
        }

    }
}
