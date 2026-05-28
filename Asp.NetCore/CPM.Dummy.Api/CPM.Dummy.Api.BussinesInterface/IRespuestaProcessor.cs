namespace CPM.Dummy.BussinesInterface
{
    public interface IRespuestaProcessor
    {
        string ObtenerMensajeJson(string api, string firma);
        string ObtenerDocumentoPdf(string api, string firma);
    }
}
