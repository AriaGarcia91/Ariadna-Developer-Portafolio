using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG_CreacionTablaAmortizacion.BussinesType
{
    public class SimuladorResponseModel
    {
        public class Root
        {
            [JsonProperty("traceid")]
            public string TraceId { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("tabla")]
            public List<Amortizacion> Tabla { get; set; }

            [JsonProperty("resultado")]
            public Resultado Resultado { get; set; }
        }

        public class Resultado
        {
            [JsonProperty("codigoQuiron")]
            public string CodigoQuiron { get; set; }

            [JsonProperty("codigo")]
            public string Codigo { get; set; }

            [JsonProperty("mensaje")]
            public string Mensaje { get; set; }

            [JsonProperty("ultimoItem")]
            public string UltimoItem { get; set; }

            [JsonProperty("queue")]
            public string Queue { get; set; }

            [JsonProperty("cntItem")]
            public string CntItem { get; set; }

            [JsonProperty("marcaSigte")]
            public string MarcaSigte { get; set; }

            [JsonProperty("acumPlazo")]
            public string AcumPlazo { get; set; }

            [JsonProperty("totCapital")]
            public string TotCapital { get; set; }

            [JsonProperty("totInteres")]
            public string TotInteres { get; set; }

            [JsonProperty("totComision")]
            public string TotComision { get; set; }

            [JsonProperty("totSeguro")]
            public string TotSeguro { get; set; }

            [JsonProperty("totDividendo")]
            public string TotDividendo { get; set; }

            [JsonProperty("totImpuesto")]
            public string TotImpuesto { get; set; }

            [JsonProperty("totSolca")]
            public string TotSolca { get; set; }

            [JsonProperty("totalCliq")]
            public string TotalCliq { get; set; }

            [JsonProperty("totValorNeto")]
            public string TotValorNeto { get; set; }

            [JsonProperty("tasaIntEfectiva")]
            public string TasaIntEfectiva { get; set; }

            [JsonProperty("tasaIntNominal")]
            public string TasaIntNominal { get; set; }

            [JsonProperty("seguroCesantia")]
            public string SeguroCesantia { get; set; }

            [JsonProperty("segCesantiaValor")]
            public string SegCesantiaValor { get; set; }

            [JsonProperty("desgravamenValor")]
            public string DesgravamenValor { get; set; }

            [JsonProperty("subsegmento")]
            public string Subsegmento { get; set; }

            [JsonProperty("margenReaj")]
            public string MargenReaj { get; set; }
        }

        public class Amortizacion
        {
            [JsonProperty("idControlTabla")]
            public string IdControlTabla { get; set; }

            [JsonProperty("tFecha1")]
            public string TFecha1 { get; set; }

            [JsonProperty("tPlazo")]
            public string TPlazo { get; set; }

            [JsonProperty("tCapital")]
            public string TCapital { get; set; }

            [JsonProperty("tInteres")]
            public string TInteres { get; set; }

            [JsonProperty("tComision")]
            public string TComision { get; set; }

            [JsonProperty("tSeguro")]
            public string TSeguro { get; set; }

            [JsonProperty("tDividendo")]
            public string TDividendo { get; set; }

            [JsonProperty("tCapReducido")]
            public string TCapReducido { get; set; }

            [JsonProperty("tPlzVista")]
            public string TPlzVista { get; set; }
        }


    }
}

