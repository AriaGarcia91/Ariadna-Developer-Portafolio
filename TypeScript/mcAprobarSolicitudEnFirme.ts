namespace SolicitudAprobadoEnFirme{
    export async function AprobarSolicitudEnFirme(executionContext: Xrm.Events.EventContext):Promise<void>{
        try {
              const formContext = executionContext.getFormContext();
              const dictamenExperto = formContext.getAttribute("rs_dictamenexperto")?.getValue();
              const dictamenesMotor = formContext.getAttribute("rs_dictamenesmotor")?.getValue();
              const productoLookup =formContext.getAttribute("rs_productoid")?.getValue();
              const nombreProducto = productoLookup?.[0]?.name ?? "";
              if (!productoLookup?.length) return;
              if (dictamenExperto !== 1 || dictamenesMotor !== 1 ||!nombreProducto.toUpperCase().includes("MULTICREDITO"))
              return;
              const host = (await recuperarHost()).toString();
              const Url = `${host.replace(/\/$/, '')}/endpoint`;
              var requestBody = await FormarPeticion(formContext);
              const respuesta = await enviarSolicitudAprobacion(Url, requestBody);
              if(respuesta && respuesta.data){
                await CrearOrdenOperacion(respuesta);
                console.log("Orden de operación creada con éxito.");
                console.log(respuesta.data);
              }

        } catch (error) {
            console.warn("La respuesta no contiene datos válidos para crear una orden de operación.");
            alert(`Ocurrió un error en AprobarSolicitudEnFirme:${error}`);
        }

    }


    async function recuperarHost():Promise<String>{
         const envVarResponse = await Xrm.WebApi.retrieveMultipleRecords(
                "environmentvariabledefinition",
                "?$select=defaultvalue&$filter=schemaname eq 'rs_apimanagersettingsdev'&$top=50"
            );

            if (!envVarResponse.entities?.length) {
                throw new Error("Variable 'rs_apimanagersettingsdev' no encontrada");
            }
            let envSettings: {
                host: string;
                clientid: string;
                clientsecret: string;
                scope: string;
            };
            try {
                const cleanedJson = envVarResponse.entities[0].defaultvalue
                    .replace(/\\"/g, '"')
                    .replace(/^"+|"+$/g, '')
                    .trim();

                envSettings = JSON.parse(cleanedJson);
                
                if (!envSettings.host || !envSettings.clientid || !envSettings.clientsecret || !envSettings.scope) {
                    throw new Error("Configuración incompleta");
                }
                return envSettings.host;
            } catch (e) {
                throw new Error(`Error parseando configuración: ${e instanceof Error ? e.message : 'JSON inválido'}`);
            }
    }

    async function recuperarToken():Promise<any>{
        try {
            const entidad = "environmentvariabledefinition";        
            const query = "?$select=description&$filter=schemaname eq 'rs_authorizationbearer'&$top=50";        
            const responseToken = await Xrm.WebApi.retrieveMultipleRecords(entidad, query);        
            const token = responseToken.entities[0].description;
            return token;
        } catch (error) {  
            alert(`Ocurrió un error en recuperarToken: ${error}`);
        }
    } 
      async function enviarSolicitudAprobacion(url: string, payload: any): Promise<ServicioAprobacionResponse> {
        const token = await recuperarToken();
        const response = await fetch(url, {
            method: "POST",
            headers: {
            "Content-Type": "application/json",
            "Authorization": `${token}` 
            },
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error en API: ${response.status} - ${errorText}`);
        }

        const result = await response.json();
        return result as ServicioAprobacionResponse;
        }

    async function FormarPeticion(formContext: Xrm.FormContext):Promise<RequestBody>{
        try {
            let contacto;
            let razonSocial;
            let tipoIdentificacion;
            let identificacion;
            let cuenta;
            const expedienteNeo = formContext.getAttribute("name")?.getValue() ?? "";
            const solicitudSccs = "";
            const productoLookup = formContext.getAttribute("rs_productoid")?.getValue();
            const periodicidadLookup = formContext.getAttribute("rs_periodicidad")?.getValue();
            const periodicidad = periodicidadLookup?.length > 0 
            ? periodicidadLookup[0].name.charAt(0) 
            : "";
            const idProducto = productoLookup && productoLookup.length > 0 ? productoLookup[0].id :"";
            const nombreProducto = productoLookup && productoLookup.length > 0 ? productoLookup[0].name:"";
            const tipoProducto = idProducto ? await obtenerCodigoProducto(idProducto) : "";
            const clienteLookup = formContext.getAttribute("rs_clienteid")?.getValue(); 
            const clienteId =  clienteLookup[0].id.replace(/[{}]/g, "");
            if(clienteLookup != null && clienteLookup[0].entityType === "contact"){
                contacto = await ObtenerDatosContacto(clienteId);
                razonSocial = clienteLookup[0].name;
                identificacion = contacto?.rs_identificacion;
            }
            else if(clienteLookup != null && clienteLookup[0].entityType === "account"){
                cuenta = await ObtenerDatosCuenta(clienteId);
                razonSocial = cuenta?.rs_nombrecomercial;
                identificacion = cuenta?.rs_identificacion;
            }
            const userId = Xrm.Utility.getGlobalContext().userSettings.userId.replace(/[{}]/g, "");
            const usuarioLogeado = await obtenerEmpleadoUsuario(userId);
            const idSimulador = formContext.getAttribute("rs_registrosimuladorid")?.getValue() ? formContext.getAttribute("rs_registrosimuladorid")!.getValue()[0].id.replace(/[{}]/g, ""):null;
            const seguroDesgravamen = await ObtenerValorSeguroDesgravamen(idSimulador);
            //const clientePotencialLookup = formContext.getAttribute("")?.getValue();
            const montoAfinanciar = formContext.getAttribute("budgetamount")?.getValue() ?? "";
            const atributoPlazo = formContext.getAttribute("rs_plazo") as any;
            const plazo = atributoPlazo?.getText() || "";
            const diaPagoValor = formContext.getAttribute("rs_diafijopago")?.getValue();
            const diaPago = diaPagoValor !== null && diaPagoValor !== undefined ? diaPagoValor.toString() : "";
            const tipoGarantiaValor = formContext.getAttribute("rs_tipogarantia")?.getValue();
            const tipoGarantia = await ObtenerCodigoTipoGarantia(tipoGarantiaValor);
            const tipoTablaValor = formContext.getAttribute("rs_tipotabla")?.getValue();
            const tipoTabla = tipoTablaValor === 0 ? "F" : tipoTablaValor === 1 ? "A" : "F";
            if(contacto != null && contacto.rs_tipoidentificacion != null){
              tipoIdentificacion = mapearTipoIdentificacion(contacto.rs_tipoidentificacion);
            }
            else if(cuenta != null && cuenta.rs_identificacion != null){
                tipoIdentificacion = "R";
            }

            const request = crearRequestBody();
            
            /*const request = crearRequestBody({
            ExpedienteNeo: expedienteNeo,
            SolicitudSccs: solicitudSccs,
            TipoProducto: tipoProducto,
            Descripcion1: nombreProducto,
            Descripcion2: "",
            ValorBien: "",
            CuotaInicial: "",
            MontoAfinanciar: (await montoAfinanciar).toString(),
            PlazoAnio: "",
            PlazoDias : plazo,
            Periodicidad : periodicidad,
            DiaPago: diaPago,
            AnioBien: "",
            TipoBien: "",
            TipoGarantia:"SG",
            OrigenCampana:"",
            DestinoFinanciero:"OT",
            DestinoEconomico: "",
            EstadoFinanciero: "N",
            FlujoCaja: "N",
            ImpuestoRenta: "N",
            FinanciarSeguro: "",
            ValorSeguro: "",
            GastosInscripcion: "",
            DispositivoSeguridad: "",
            ValorDispositivo: "",
            ValorMatricula: "",
            Fiducia: "",
            ValorFiducia:"",
            ReconocimientoFirma: "S",
            FinanciaAccesorios: "",
            ValorAccesorios: "0",
            PerGraciaCapital: "0",
            PerGraciaInteres: "0",
            FinanciaImpuestos: "N",
            FinanciaComision: "",
            Comision: "0",
            TablaAmortizacion: "N",
            ModeloSeguro: "",
            Region: "C",
            CuotaBalon: "0",
            PorcentajeBalon: "0",
            CodDispositivo: "",
            AsistenciaVeh: "",
            CantonProyecto: "",
            MarcaVerifDireccion: "",
            AperturaCuenta: "N",
            NombreLibreta: "",
            Cuenta: "",
            DiasLaborable: "N",
            PagosAdic: "",
            SeguroMicro: "",
            FechaDesembolso: "",
            TipoTabla: tipoTabla,
            TipoAseguradora: "40",
            Desgravamen: (await seguroDesgravamen).toString(),
            DestinoPrestamo: "",
            TarjetaDebito: "",
            NombreTarjeta: "",
            CobroCesantia: "",
            ActivCiiu: "",
            SegEstrategicoBg: "",
            PerfilCliente: "",
            SecuenciaRiesgo: "",
            AgenciaMicro: "",
            TipoCliente: "rs_tipocliente",  // Tipo de cliente
            TipoId: tipoIdentificacion,  
            CedRuc: identificacion,  
            NombreRazonSocial: razonSocial,
            EstadoCivil: contacto?.familystatuscode,
            Sexo: contacto?.gendercode,
            LugarNacimiento: contacto?.rs_cantonnacimientoidName,  // Cantón de nacimiento
            FechaNacimiento: contacto?.birthdate,  // Fecha de nacimiento
            Nacionalidad: contacto?.nacionalidad,  // Nacionalidad
            Dependientes: "",
            DirDomicilio: "",
            CiudadDomicilio: "",
            TlfDomicilio1: "",
            TlfDomicilio2: "",
            NumeroCelular: contacto?.mobilephone,  // Celular principal
            EmailDomicilio: "",
            Correspondencia: "",
            SeparacionBienes: "",
            Casilla: "",
            ActividadR184: "",
            PersonaR184: "",
            Profesion: contacto?.profesion,
            TipoVivienda: "",
            TiempoResidencia: "",
            ValorAlquiler: "",
            NombrePropietario: "",
            TipoRuc: "",
            RucNegocio: "",
            NombreEmpresa: "",
            CargoActual: "",
            ActProfesion: "",
            Antiguedad: "",
            DirEmpresa: "",
            CiudadEmpresa: "",
            TlfEmpresa1: "",
            TlfEmpresa2: "",
            EmailEmpresa: "",
            HoraAtencionI: "",
            HoraAtencionF: "",
            TipoLocal: "",
            NombrePropLocal: "",
            DirPropLocal: "",
            TlfPropietario: "",
            SueldoMensual: "",
            OtrosIngreso: "",
            OrigenIngreso: "",
            IngresosNoJust: "",
            GastoFamiliar: "",
            ArriendoCredito: "",
            OtrosGastos: "",
            TotalVentas: "",
            FechaVentas: "",
            Propiedades: "",
            Vehiculos: "",
            Otros: "",
            Pasivos: "",
            TasaAutorizador: "",
            TasaNueva: "",
            SignoVarTasa: "",
            VariacionTasa: "",
            MontoAutorizador: "",
            MontoSolicitado: (await montoAfinanciar).toString(),
            SignoVarMonto: "",
            VariacionMonto: "",
            ResultadoDictamen: "",
            OpIdGestor: usuarioLogeado,
            SolicitudBcsm: "",
            CodigoOrigenBcsm: "",
            AceptaCampania: "",
            AniosExpNegLocal: "",
            ActividadRegNew: "",
            TipoBanca: "",
            Segmento: "",
            TipoCuenta: "",
            CcCanal: "",
            CcOrigenCta: "",
            CcCodTrato: "",
            CcNombreCheq: "",
            CcTipoCheq: "",
            CcCantidCheq: "",
            CcEntregEc: "",
            CcDireccEc: "",
            CcMarcaTarjDeb: "",
            CcNombrTarjDeb: "",
            MarcaBancontrol: "",
            MarcaAvisoSeg: "",
            SolicitudPadre: "",
            ProductoPadre: "",
            PorcEntradaBien: "",
            PorcNuevoCredito: "",
            MarcaRetanqueo: "",
            MarcaFirma: "",
            OtrosDispositivos: "",
            FinanciaGastosLegales: "",
            PorcBallon: "",
            ValorBallon: "",
            FPagoSeguro: "",    
            });*/
            return request;
        } catch (error) {
             alert(`Ocurrió un error en FormarPeticion: ${error}`);
            throw error;
        }
    }

    async function obtenerEmpleadoUsuario(userId: string): Promise<string> {
        const usuario = await Xrm.WebApi.retrieveRecord("systemuser", userId, "?$select=employeeid");
        return usuario.employeeid;
    }
    async function obtenerCodigoProducto(productoId: string): Promise<string> {
        const producto = await Xrm.WebApi.retrieveRecord("product", productoId, "?$select=rs_codigoproducto");
        return producto.rs_codigoproducto;
    }
    
    async function ObtenerCodigoTipoGarantia(valor: number): Promise<string> {
        switch (valor) {
        case 100000000:
            return "SG"; // Sin Garantía
        case 100000001:
            return "GR"; // Garantía Real
        case 100000002:
            return "OG"; // Otra Garantía
        default:
            return ""; // Valor no mapeado
        }
    }
    async function ObtenerValorSeguroDesgravamen(idSimulador: string): Promise<string> {
    try {
        if (!idSimulador) {
            throw new Error("ID del simulador no proporcionado.");
        }

        const simulador = await Xrm.WebApi.retrieveRecord("rs_simulador", idSimulador, "?$select=rs_segurodesgravamen");
        const seguro = simulador?.rs_segurodesgravamen;

        const valorSeguro = seguro === true ? "S" : "N";
        return valorSeguro;

    } catch (error) {
        alert(`Ocurrió un error en ObtenerValorSeguroDesgravamen: ${error}`);
        return "N";
    }
  }

async function ObtenerDatosContacto(idContacto: string): Promise<Contacto | null> {
    try {
        const contacto = await Xrm.WebApi.retrieveRecord("contact", idContacto, "?$select=familystatuscode,gendercode,birthdate,_rs_nacionalidadid_value,mobilephone,rs_cantonnacimientoid,_rs_profesionid_value,rs_tipoidentificacion,rs_identificacion");
        let estadoCivil = mapearEstadoCivil(contacto.gendercode);
        //const nacionalidadCodigo = await obtenerSiglasNacionalidad(contacto.rs_nacionalidadid);
        const profesionCodigo = await obtenerCodigoProfesion(contacto._rs_profesionid_value);
        const contactoInfo: Contacto = {
        familystatuscode: estadoCivil || '',
        gendercode: contacto.gendercode === 1 ? "F" : contacto.gendercode === 2 ? "M" : '',
        rs_cantonnacimientoid: contacto.rs_cantonnacimientoid || '',
        rs_cantonnacimientoidName: contacto["rs_cantonnacimientoid@OData.Community.Display.V1.FormattedValue"] || '',
        birthdate: contacto.birthdate ? new Date(contacto.birthdate).toISOString().split("T")[0] : '',
        //nacionalidad: nacionalidadCodigo || '',
        nacionalidad: "ECS",
        mobilephone: contacto.mobilephone || '',
        profesion: profesionCodigo || '',
        rs_tipoidentificacion: contacto.rs_tipoidentificacion,
        rs_identificacion: contacto.rs_identificacion,
    };

    return contactoInfo;
    } catch (error) {
        alert(`Ocurrió un error en ObtenerDatosContacto: ${error}`);
        return null;
    }
}

    async function obtenerSiglasNacionalidad(nacionalidadId: string): Promise<string>{
       const nacionalidad = await Xrm.WebApi.retrieveRecord("rs_nacionalidad",nacionalidadId,"?$select=rs_codigobanco");
       return nacionalidad.rs_codigobanco;
    }
    async function obtenerCodigoProfesion(profesionId: string):Promise<string>{
        const profesion = await Xrm.WebApi.retrieveRecord("rs_profesion",profesionId,"?$select=rs_id");
        return profesion.rs_id;
    }



async function  ObtenerDatosCuenta(idCuenta: string): Promise<Cuenta | null> {
    try {
        const cuenta = await Xrm.WebApi.retrieveRecord("account",idCuenta,"$select=rs_identificacion,rs_nombrecomercial");
        const cuentaInfo: Cuenta ={
            rs_identificacion: cuenta.rs_identificacion,
            rs_nombrecomercial: cuenta.rs_nombrecomercial,
        }
        return cuentaInfo;
    } catch (error) {
        alert(`Ocurrió un error en ObtenerDatosCuenta ${error}`);
        return null;
    }
}

  function mapearTipoIdentificacion(valor: number): string {
        switch (valor) {
        case 1: return "C"; // Cédula
        case 2: return "P"; // Pasaporte
        default: return ""; // No mapeado
    }
}

function mapearEstadoCivil(valor: number): string{
    switch (valor) {
        case 1: return "S"; // Soltero
        case 2: return "C"; // Casado
        case 3: return "D";// Divorciado
        case 4: return "V"; //Viud@
        case 5: return "UL";//Unión Libre
        default: return ""; // No mapeado
    }
}
  
async function CrearOrdenOperacion(resultado:ServicioAprobacionResponse):Promise<void>{
    try {
        const ordenOperacion = {
            "rs_numorden":resultado.data.solicitudSccs,
            "rs_dividendo":resultado.data.valorDividendo ? parseFloat(resultado.data.valorDividendo) : 0,
            "rs_tasaInteres":resultado.data.interesNominal? parseFloat(resultado.data.interesNominal) : 0,
            "rs_tasaefectiva":resultado.data.interesEfectiva? parseFloat(resultado.data.interesEfectiva):0,
            "rs_estadosolicitud": resultado.data.statusSolicitud,
            "rs_marcacesantia": resultado.data.marcaSegCesantia,
            "rs_valorcesantia": resultado.data.valorSegCesantia? parseFloat(resultado.data.valorSegCesantia):0,
            "rs_desgravamen": resultado.data.segDesgravamen,
            "rs_tasafijareajustable": resultado.data.tasaFijaReajustable? parseFloat(resultado.data.tasaFijaReajustable):0,
            "rs_tiporeajuste": resultado.data.tipoReajuste,
            "rs_signoreajuste": resultado.data.signoReajuste,
            "rs_margenreajuste": resultado.data.margenReajuste,
            "rs_valorseguro": resultado.data.valorSeguro? parseFloat(resultado.data.valorSeguro):0
        }

        const response = await Xrm.WebApi.createRecord("rs_ordenoperacion",ordenOperacion);
        Xrm.Navigation.openAlertDialog({text:"Orden de Operación creada exitosamente"});
    } catch (error:any) {
        console.log(`Ocurrió un error al crear orden de operación ${error}`);
        Xrm.Navigation.openErrorDialog({ 
          message: `Error al crear la operación: ${error.message || error.toString()}` 
        });
    }

}
    //Se puede usar como dummy
            function crearRequestBody(data: Partial<RequestBody> = {}): RequestBody {
            return {
            ExpedienteNeo: "0000001734",
            SolicitudSccs: "0",
            TipoProducto: "MC",
            Descripcion1: "MULTICREDITO",
            Descripcion2: "",
            ValorBien: "0",
            CuotaInicial: "0",
            MontoAfinanciar: "500000",
            PlazoAnio: "2",
            PlazoDias: "0",
            Periodicidad: "M",
            DiaPago: "1",
            AnioBien: "0",
            TipoBien: "",
            TipoGarantia: "SG",
            OrigenCampana: "",
            DestinoFinanciero: "OT",
            DestinoEconomico: "N000000",
            EstadoFinanciero: "N",
            FlujoCaja: "N",
            ImpuestoRenta: "N",
            FinanciarSeguro: "",
            ValorSeguro: "0",
            GastosInscripcion: "0",
            DispositivoSeguridad: "",
            ValorDispositivo: "0",
            ValorMatricula: "0",
            Fiducia: "",
            ValorFiducia: "0",
            ReconocimientoFirma: "S",
            FinanciaAccesorios: "",
            ValorAccesorios: "0",
            PerGraciaCapital: "0",
            PerGraciaInteres: "0",
            FinanciaImpuestos: "N",
            FinanciaComision: "",
            Comision: "0",
            TablaAmortizacion: "N",
            ModeloSeguro: "1",
            Region: "C",
            CuotaBalon: "0",
            PorcentajeBalon: "0",
            CodDispositivo: "",
            AsistenciaVeh: "",
            CantonProyecto: "",
            MarcaVerifDireccion: "N",
            AperturaCuenta: "N",
            NombreLibreta: "",
            Cuenta: "29584995",
            DiasLaborable: "N",
            PagosAdic: "",
            SeguroMicro: "",
            FechaDesembolso: "0",
            TipoTabla: "F",
            TipoAseguradora: "40",
            Desgravamen: "N",
            DestinoPrestamo: "",
            TarjetaDebito: "N",
            NombreTarjeta: "",
            CobroCesantia: "",
            ActivCiiu: "",
            SegEstrategicoBg: "",
            PerfilCliente: "",
            SecuenciaRiesgo: "0",
            AgenciaMicro: "0",
            TipoCliente: "DE",
            TipoId: "C",
            CedRuc: "0950716068",
            NombreRazonSocial: "FIALLOS ZUNIGA BRYAN DAVID",
            EstadoCivil: "S",
            Sexo: "M",
            LugarNacimiento: "DAULE",
            FechaNacimiento: "26/07/1994",
            Nacionalidad: "ECS",
            Dependientes: "0",
            DirDomicilio: "AURORA",
            CiudadDomicilio: "GYE",
            TlfDomicilio1: "42334679",
            TlfDomicilio2: "0",
            NumeroCelular: "991730175",
            EmailDomicilio: "PRUEBAS3CA@NEO.COM",
            Correspondencia: "D",
            SeparacionBienes: "",
            Casilla: "000000",
            ActividadR184: "S05",
            PersonaR184: "N",
            Profesion: "47",
            TipoVivienda: "P",
            TiempoResidencia: "1",
            ValorAlquiler: "0",
            NombrePropietario: "",
            TipoRuc: "",
            RucNegocio: "",
            NombreEmpresa: "",
            CargoActual: "",
            ActProfesion: "COMERCIANTES,FUNC.CIAS.DE SEGU",
            Antiguedad: "11",
            DirEmpresa: "ASDFASDF",
            CiudadEmpresa: "GYE",
            TlfEmpresa1: "42334679",
            TlfEmpresa2: "0",
            EmailEmpresa: "",
            HoraAtencionI: "0",
            HoraAtencionF: "0",
            TipoLocal: "",
            NombrePropLocal: "",
            DirPropLocal: "",
            TlfPropietario: "",
            SueldoMensual: "20000",
            OtrosIngreso: "0",
            OrigenIngreso: "EMPLEADO PUBLICO",
            IngresosNoJust: "0",
            GastoFamiliar: "150",
            ArriendoCredito: "100",
            OtrosGastos: "100",
            TotalVentas: "0",
            FechaVentas: "",
            Propiedades: "",
            Vehiculos: "",
            Otros: "",
            Pasivos: "",
            TasaAutorizador: "1220",
            TasaNueva: "1520",
            SignoVarTasa: "+",
            VariacionTasa: "0",
            MontoAutorizador: "3000000",
            MontoSolicitado: "500000",
            SignoVarMonto: "-",
            VariacionMonto: "2500000",
            ResultadoDictamen: "AN",
            OpIdGestor: "JY1",
            SolicitudBcsm: "0",
            CodigoOrigenBcsm: "",
            AceptaCampania: "",
            AniosExpNegLocal: "0",
            ActividadRegNew: "S05",
            TipoBanca: "P",
            Segmento: "DI",
            TipoCuenta: "",
            CcCanal: "",
            CcOrigenCta: "",
            CcCodTrato: "",
            CcNombreCheq: "",
            CcTipoCheq: "",
            CcCantidCheq: "0",
            CcEntregEc: "",
            CcDireccEc: "",
            CcMarcaTarjDeb: "",
            CcNombrTarjDeb: "",
            MarcaBancontrol: "",
            MarcaAvisoSeg: "",
            SolicitudPadre: "0",
            ProductoPadre: "",
            PorcEntradaBien: "0",
            PorcNuevoCredito: "0",
            MarcaRetanqueo: "",
            MarcaFirma: "",
            OtrosDispositivos: "0",
            FinanciaGastosLegales: "",
            PorcBallon: "0",
            ValorBallon: "0",
            FPagoSeguro: "",
            ...data // Sobrescribe cualquier valor que venga desde el parámetro
            };
        }


            export interface RequestBody {
            ExpedienteNeo: string;
            SolicitudSccs: string;
            TipoProducto: string;
            Descripcion1: string;
            Descripcion2: string;
            ValorBien: string;
            CuotaInicial: string;
            MontoAfinanciar: string;
            PlazoAnio: string;
            PlazoDias: string;
            Periodicidad: string;
            DiaPago: string;
            AnioBien: string;
            TipoBien: string;
            TipoGarantia: string;
            OrigenCampana: string;
            DestinoFinanciero: string;
            DestinoEconomico: string;
            EstadoFinanciero: string;
            FlujoCaja: string;
            ImpuestoRenta: string;
            FinanciarSeguro: string;
            ValorSeguro: string;
            GastosInscripcion: string;
            DispositivoSeguridad: string;
            ValorDispositivo: string;
            ValorMatricula: string;
            Fiducia: string;
            ValorFiducia: string;
            ReconocimientoFirma: string;
            FinanciaAccesorios: string;
            ValorAccesorios: string;
            PerGraciaCapital: string;
            PerGraciaInteres: string;
            FinanciaImpuestos: string;
            FinanciaComision: string;
            Comision: string;
            TablaAmortizacion: string;
            ModeloSeguro: string;
            Region: string;
            CuotaBalon: string;
            PorcentajeBalon: string;
            CodDispositivo: string;
            AsistenciaVeh: string;
            CantonProyecto: string;
            MarcaVerifDireccion: string;
            AperturaCuenta: string;
            NombreLibreta: string;
            Cuenta: string;
            DiasLaborable: string;
            PagosAdic: string;
            SeguroMicro: string;
            FechaDesembolso: string;
            TipoTabla: string;
            TipoAseguradora: string;
            Desgravamen: string;
            DestinoPrestamo: string;
            TarjetaDebito: string;
            NombreTarjeta: string;
            CobroCesantia: string;
            ActivCiiu: string;
            SegEstrategicoBg: string;
            PerfilCliente: string;
            SecuenciaRiesgo: string;
            AgenciaMicro: string;
            TipoCliente: string;
            TipoId: string;
            CedRuc: string;
            NombreRazonSocial: string;
            EstadoCivil: string;
            Sexo: string;
            LugarNacimiento: string;
            FechaNacimiento: string;
            Nacionalidad: string;
            Dependientes: string;
            DirDomicilio: string;
            CiudadDomicilio: string;
            TlfDomicilio1: string;
            TlfDomicilio2: string;
            NumeroCelular: string;
            EmailDomicilio: string;
            Correspondencia: string;
            SeparacionBienes: string;
            Casilla: string;
            ActividadR184: string;
            PersonaR184: string;
            Profesion: string;
            TipoVivienda: string;
            TiempoResidencia: string;
            ValorAlquiler: string;
            NombrePropietario: string;
            TipoRuc: string;
            RucNegocio: string;
            NombreEmpresa: string;
            CargoActual: string;
            ActProfesion: string;
            Antiguedad: string;
            DirEmpresa: string;
            CiudadEmpresa: string;
            TlfEmpresa1: string;
            TlfEmpresa2: string;
            EmailEmpresa: string;
            HoraAtencionI: string;
            HoraAtencionF: string;
            TipoLocal: string;
            NombrePropLocal: string;
            DirPropLocal: string;
            TlfPropietario: string;
            SueldoMensual: string;
            OtrosIngreso: string;
            OrigenIngreso: string;
            IngresosNoJust: string;
            GastoFamiliar: string;
            ArriendoCredito: string;
            OtrosGastos: string;
            TotalVentas: string;
            FechaVentas: string;
            Propiedades: string;
            Vehiculos: string;
            Otros: string;
            Pasivos: string;
            TasaAutorizador: string;
            TasaNueva: string;
            SignoVarTasa: string;
            VariacionTasa: string;
            MontoAutorizador: string;
            MontoSolicitado: string;
            SignoVarMonto: string;
            VariacionMonto: string;
            ResultadoDictamen: string;
            OpIdGestor: string;
            SolicitudBcsm: string;
            CodigoOrigenBcsm: string;
            AceptaCampania: string;
            AniosExpNegLocal: string;
            ActividadRegNew: string;
            TipoBanca: string;
            Segmento: string;
            TipoCuenta: string;
            CcCanal: string;
            CcOrigenCta: string;
            CcCodTrato: string;
            CcNombreCheq: string;
            CcTipoCheq: string;
            CcCantidCheq: string;
            CcEntregEc: string;
            CcDireccEc: string;
            CcMarcaTarjDeb: string;
            CcNombrTarjDeb: string;
            MarcaBancontrol: string;
            MarcaAvisoSeg: string;
            SolicitudPadre: string;
            ProductoPadre: string;
            PorcEntradaBien: string;
            PorcNuevoCredito: string;
            MarcaRetanqueo: string;
            MarcaFirma: string;
            OtrosDispositivos: string;
            FinanciaGastosLegales: string;
            PorcBallon: string;
            ValorBallon: string;
            FPagoSeguro: string;
        }
        export interface ServicioAprobacionResponse {
        traceid: string;
        data: {
            mensaje: string | null;
            solicitudSccs: string | null;
            valorDividendo: string | null;
            interesNominal: string | null;
            interesEfectiva: string | null;
            statusSolicitud: string | null;
            marcaSegCesantia: string | null;
            valorSegCesantia: string | null;
            segDesgravamen: string | null;
            tasaFijaReajustable: string | null;
            tipoReajuste: string | null;
            signoReajuste: string | null;
            margenReajuste: string | null;
            valorSeguro: string | null;
        };
        }

        export interface Contacto{
        familystatuscode: string;
        gendercode: string;
        rs_cantonnacimientoid: string;
        rs_cantonnacimientoidName: string;
        birthdate: string;  // Podría ser Date, pero depende del formato que recibas
        nacionalidad: string;
        mobilephone: string;
        profesion: string;
        rs_tipoidentificacion: number;
        rs_identificacion: string;
        }

        export interface Cuenta{
            rs_nombrecomercial: string;
            rs_identificacion: string;
        }

}

(window as any).SolicitudAprobadoEnFirme = SolicitudAprobadoEnFirme;
