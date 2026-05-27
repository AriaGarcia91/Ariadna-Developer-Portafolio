using System;
using System.Runtime.Serialization;

namespace CPM.ReporteAuditoria.BusinessType.Exceptions
{
    public class CrmExcepcion:Exception
    {
        private static string CRMExceptionMessage = "Ocurrió un error interno en la aplicación.";
        public string Errors { get; set; }

        public CrmExcepcion(string errors) :
        base(CRMExceptionMessage)
        { Errors = errors; }

        public CrmExcepcion(Exception inner)
            : base(CRMExceptionMessage, inner) { }

        public CrmExcepcion(string message, Exception inner)
            : base(CRMExceptionMessage, inner) { }


        protected CrmExcepcion(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}
