namespace CPM.Dummy.DataInterface
{
    public interface ICRMRepository
    {
        string ConsultaRespuestaApi(string api, string firma);
        string ConsultaFetchRespuestaApi(string api, string firma);
        string ConsultaFetchRespuestaApiDocumento(string api, string firma);
        string ConsultaRespuestaApiDocumento(string api, string firma);
    }
}
