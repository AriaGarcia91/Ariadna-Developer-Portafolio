namespace multiCreditoServiciosActivos{

    export async function McAprobarSolicitudCondicionado(executionContext: Xrm.Events.EventContext):Promise<void>{
        try {

             const formContext = executionContext.getFormContext();
             const dictamenAnalista = formContext.getAttribute("rs_dictamenanalista")?.getValue();
             const cupoCompleto = formContext.getAttribute("rs_cupocompleto")?.getValue();
             const dictamenesMotor = formContext.getAttribute("rs_dictamenesmotor")?.getValue();
             const productoLookup = formContext.getAttribute("rs_productoid")?.getValue();
             const nombreProducto = productoLookup?.[0]?.name ?? "";
             const numeroSolicitud = formContext.getAttribute("name")?.getValue();
             const clienteLookup = formContext.getAttribute("rs_clienteid")?.getValue();
             const userId = Xrm.Utility.getGlobalContext().userSettings.userId.replace(/[{}]/g, "");
             const fechaActual = obtenerFechaActualSinHora();
             let clienteId;
             let identificacion;
             let tipoIdentificacion;
            
            if (!productoLookup?.length || !clienteLookup?.length) return;
            if (dictamenAnalista !== 3 || cupoCompleto != true || dictamenesMotor !== 2 ||!nombreProducto.toUpperCase().includes("MULTICREDITO"))
            return;
            if (!productoLookup?.length || !clienteLookup?.length) return;

             const productoId = productoLookup[0].id.replace(/[{}]/g, "");
             const codigoProducto = await obtenerCodigoProducto(productoId);
             const usuarioLogeado = await obtenerEmpleadoUsuario(userId);
             clienteId = clienteLookup?.[0]?.id.replace(/[{}]/g, "");
             const tipoEntidad = clienteLookup?.[0]?.entityType;

            if (clienteId && tipoEntidad) {
              if (tipoEntidad === "contact") {
                const cliente = await ConsultarDatosCliente("contact", clienteId);
                const contacto = cliente as multiCreditoServiciosActivos.ContactoCliente;
                identificacion = contacto.rs_identificacion;
                tipoIdentificacion = mapearTipoIdentificacion(contacto.rs_tipoidentificacion);
            }else if (tipoEntidad === "account") {
                const cliente = await ConsultarDatosCliente("account", clienteId);
                const cuenta = cliente as multiCreditoServiciosActivos.CuentaCliente;
                identificacion = cuenta.accountnumber;
                tipoIdentificacion = "R";
                }
            }
            const host = (await recuperarHost()).toString();
            const Url = `${host.replace(/\/$/, '')}/endpoint`;
             
             const requestBody ={
                numeroSolicitud: numeroSolicitud, 
                producto: codigoProducto,             
                tipoIdentificacion: tipoIdentificacion,  
                Identificacion: identificacion, 
                usuarioAccion: usuarioLogeado,     
                fecha: new Date(fechaActual.getFullYear(), fechaActual.getMonth(), fechaActual.getDate()), 
                numExpediente: "21266004",   
                tipoComentario: "",        
                comentarioExcepcion: "",
                MarcaPreAprobado: "P"
             }

            const respuesta = await enviarSolicitudAprobacion(Url, requestBody);
            if (respuesta && respuesta.data && respuesta.data.resultado) {
            await CrearOrdenOperacion(respuesta.data.resultado);
            console.log("Orden de operación creada con éxito.");
            } else {
            console.warn("La respuesta no contiene datos válidos para crear una orden de operación.");
            }
            
        } catch (error) {
            alert(`Ocurrió un error en McAprobarSolicitudCondicionado: ${error}`);
        }
    }

    export async function recuperarHost():Promise<string>{
 
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

    export async function recuperarToken():Promise<any>{
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

    async function obtenerCodigoProducto(productoId: string): Promise<string> {
        const producto = await Xrm.WebApi.retrieveRecord("product", productoId, "?$select=rs_codigoproducto");
        return producto.rs_codigoproducto;
    }

    async function obtenerEmpleadoUsuario(userId: string): Promise<string> {
        const usuario = await Xrm.WebApi.retrieveRecord("systemuser", userId, "?$select=employeeid");
        return usuario.employeeid;
    }

    function obtenerFechaActualSinHora(): Date {
        const hoy = new Date();
        return new Date(hoy.getFullYear(), hoy.getMonth(), hoy.getDate());
    }
    
    function mapearTipoIdentificacion(valor: number): string {
        switch (valor) {
        case 1: return "C"; // Cédula
        case 2: return "P"; // Pasaporte
        default: return ""; // No mapeado
    }
    }

    async function ConsultarDatosCliente(entidad: "contact", id: string): Promise<ContactoCliente>;
    async function ConsultarDatosCliente(entidad: "account", id: string): Promise<CuentaCliente>;
    async function ConsultarDatosCliente(entidad: string, id: string): Promise<any> {
    try {
    if (entidad === "contact") {
        const result = await Xrm.WebApi.retrieveRecord(entidad, id, "?$select=rs_tipoidentificacion,rs_identificacion");
        return result as ContactoCliente;
    } else if (entidad === "account") {
        const result = await Xrm.WebApi.retrieveRecord(entidad, id, "?$select=accountnumber");
        return result as CuentaCliente;
    }
    } catch (error: any) {
    console.error("Error al consultar datos del cliente:", error.message);
    throw error;
  }
}

async function enviarSolicitudAprobacion(url: string, payload: any): Promise<ApiResponse> {
  const token = await recuperarToken();
  const response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}` 
    },
    body: JSON.stringify(payload)
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(`Error en API: ${response.status} - ${errorText}`);
  }

  const result = await response.json();
  return result as ApiResponse;
}

async function CrearOrdenOperacion(resultado:Resultado):Promise<void>{
    try {

        const ordenOperacion = {
            "rs_numeroexpediente":resultado.expediente,
            "rs_estadosolicitud":resultado.estadoSolicitud,
            "rs_plazo":resultado.plazoOrden,
            "rs_monto":parseFloat(resultado.montoOrden),
            "rs_numorden":resultado.ordenOperacion,
            "rs_tasainteres":parseFloat(resultado.tasaInteres),
            "rs_tasaefectiva":parseFloat(resultado.tasaEfectiva),
            "rs_tipocuenta": resultado.tipoCuenta,
            "rs_numerocuenta":resultado.numCuenta,
            "rs_estatus":resultado.estatusOrden,
            "rs_valordividendo":parseFloat(resultado.valorDividendo)
        }

        const response = await Xrm.WebApi.createRecord("rs_ordenoperacion",ordenOperacion);
        Xrm.Navigation.openAlertDialog({text:"Orden de Operación creada exitosamente"});

    } catch (error:any) {
          Xrm.Navigation.openErrorDialog({ 
          message: `Error al crear la operación: ${error.message || error.toString()}` 
        });
    }
}

    export interface ContactoCliente {
    rs_tipoidentificacion: number;
    rs_identificacion: string;
    }

    export interface CuentaCliente {
    accountnumber: string;
    }

    //Estructura para respuesta de Api y manejar mejor el mapeo de campos
    export interface Participante {
    idControlParticipantes: string;
    tipoId: string;
    id: string;
    tipoParticipante: string;
    estadoClteFil: string;
    codigoClte: string;
    oficialClte: string;
    regionOficial: string;
    }

    export interface Autorizador {
    idControlTipoParticipanteDetalle: string;
    opIdAut: string;
    accionAut: string;
    }

    export interface Resultado {
    codigoQuiron: string;
    codigo: string;
    mensaje: string;
    expediente: string;
    solicitud: string;
    estadoSolicitud: string;
    plazoOrden: string;
    montoOrden: string;
    ordenOperacion: string;
    tipoTasa: string;
    tasaInteres: string;
    tasaEfectiva: string;
    opIdRuteo: string;
    opIdAprobacion: string;
    region: string;
    descripcionRg: string;
    plaza: string;
    descripcionPz: string;
    tipoCuenta: string;
    numCuenta: string;
    estatusOrden: string;
    valorDividendo: string;
    opIdIngSolicitud: string;
    opIdVerfDir: string | null;
    fechaVerfDir: string | null;
    horaVerfDir: string | null;
    terminalVerfDir: string | null;
    }

    export interface ApiData {
    participante: Participante;
    autorizadores: Autorizador[];
    resultado: Resultado;
    }

    export interface ApiResponse {
    traceid: string;
    data: ApiData;
    }

}

(window as any).multiCreditoServiciosActivos = multiCreditoServiciosActivos;