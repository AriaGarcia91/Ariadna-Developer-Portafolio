using CPM.Dummy.BussinesInterface;
using CPM.Dummy.DataInterface;
using CPM.Dummy.OperationalManager;


namespace CPM.Dummy.BussinesLayer
{
    public class RespuestaProcessor : IRespuestaProcessor
    {
        private readonly ICRMRepository _repository;
        private readonly ILogger _logger;


        public RespuestaProcessor(ICRMRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public string ObtenerMensajeJson(string api, string firma)
        {
            var mensajeJson = _repository.ConsultaRespuestaApi(api, firma);

            return mensajeJson;
        }

        public string ObtenerDocumentoPdf(string api, string firma)
        {
            var documentoPdf64 = _repository.ConsultaRespuestaApiDocumento(api,firma);
            return documentoPdf64;
        } 
    }
}
