using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_CreacionDeOportunidad.BussinesType
{
    public class OportunidadModel
    {
        public string Identificacion { get; set; }
        public string TratamientoDatos { get; set; }
        public string CorreoElectronico { get; set; }
        public int TipoCredito { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal IngresoMensual { get; set; }
        public int Periodicidad { get; set; }
        public int Plazo { get; set; }
        public int TipoGarantia { get; set; }
        public int DestinoCredito { get; set; }
        public decimal ConsolidacionDeDeuda { get; set; }
        public int TipoOperacion { get; set; }
        //public int TipoDeCredito { get; set; }
        //rs_tipotarjetadebito no rs_marcatarjeta
        public int TipoDeTarjeta { get; set; }
        public string Institucion { get; set; }
        public decimal MontoTotalDeLaDeuda { get; set; }
        public decimal MontoAConsolidar { get; set; }
        public bool Retanqueo { get; set; }
        public int NumeroDeOperacion { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal SaldoDeLaDeuda { get; set; }
        public string Concesionario { get; set; }
        public string Vendedor { get; set; }
        //Falta definir
        public string TipoProducto { get; set; }
        public string Masa { get; set; }
        //rs_marcatarjeta
        public string Marca { get; set; }
        public int Bin { get; set; }
        public string Afinidad { get; set; }
        public string NombreTarjeta { get; set; }
        public decimal CupoTarjeta { get; set; }
        public bool CupoSugerido { get; set; }
        public decimal CupoSugeridoAnalisisCredito { get; set; }
        public decimal CupoSolicitado { get; set; }
        public int FormaEnvioEC { get; set; }
        public bool PaqueteAvisoSeguro { get; set; }
        public decimal ValorPaqueteAvisoSeguro { get; set; }
        public string Correspondencia { get; set; }
        public int EntregaDeTarjetaEn { get; set; }
        public bool DeseaAvisoSeguro { get; set; }
        public int NumeroDePagos { get; set; }
        public int DiaFijoDePago { get; set; }
        public bool SeguroMicrocredito { get; set; }
        public int TipoDeTabla { get; set; }
        public string Empresas { get; set; }
        
        //Entidades relacionadas
        public ProductoConMasaModel Producto { get; set; }
        public Guid PeriodicidadId { get; set; }
        public Guid TipoTarjetaId { get; set; }
        public Guid InstitucionId { get; set; }
        public Guid ConcesionarioId { get; set; }
        public Guid VendedorId { get; set; }
        public Guid MarcaId { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid CanalId { get; set; }
        //Conjunto de Opciones
        public int ValorPlazo { get; set; }
    }
}
