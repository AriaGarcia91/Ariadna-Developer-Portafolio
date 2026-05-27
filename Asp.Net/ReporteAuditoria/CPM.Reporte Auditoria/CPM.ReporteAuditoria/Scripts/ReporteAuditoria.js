
//Ocultamos Elementos al Cargado
window.onload = function () {
    $("#lblOficinas").hide();
    $("#lblUsuario").hide();
    $("#lblOperacion").hide();
    $("#lblFechaInicio").hide();
    $("#lblFechaFin").hide();
    $("#lblTipoOperacion").hide();
    $("#lblTipoEvento").hide();
    $("#lblFechaFinAlerta").hide();
    $("#fechaInicio").prop("disabled", true);
    $("#oficinasSelect").prop("disabled", true);
    $("#usuariosSelect").prop("disabled", true);
    $("#fechaFin").prop("disabled", true);
    $("#tipoOperacion").prop("disabled", true);
    $("#tipoEvento").prop("disabled", true);

    // Obtén la fecha actual en formato YYYY-MM-DD
    var today = new Date().toISOString().split('T')[0];
    // Establece el atributo max del campo de fecha
    document.getElementById('fechaInicio').setAttribute('max', today);
    document.getElementById('fechaFin').setAttribute('max', today);
}




//Recuperar Oficinas en base a Tipo Oficina
var tipoOficinaSeleccionada;
function RecuperarOficinas(tipoOficina) {
    $('#oficinasSelect').prop('disabled', true);
    OcultarAlertaDinamica();
    try {
        tipoOficinaSeleccionada = parseInt(tipoOficina);
        $.ajax({
            type: 'GET',
            url: urlRecuperarOficinas,
            contentType: 'application/json;charset=utf-8',
            cache: false,
            data: { tipoOficina: tipoOficinaSeleccionada },
            success: function (data) {
                var oficinas = document.getElementById("oficinasSelect");
                oficinas.innerHTML = "";
                var defaultOption = document.createElement("option");
                defaultOption.value = "";
                defaultOption.text = "-- Seleccione Plaza/Sucursal --";
                oficinas.appendChild(defaultOption);

                // Cargar oficinas
                data.forEach(function (oficina) {
                    var option = document.createElement("option");
                    option.value = oficina.Id;
                    option.text = oficina.Nombre;
                    oficinas.appendChild(option);
                });
                $('#oficinasSelect').prop('disabled', false);
            },
            error: function (xhr, status, error) {
                console.error('Error al recuperar oficinas:', error);
            }
        });
    } catch (e) {
        console.error('Error en RecuperarOficinas:', e);
    }
}

//Recuperar Usuarios de la oficina Seleccionada
let idsUsuarios = [];
function RecuperarUsuariosPorOficina(oficinaId) {
    $('#lblOficinas').hide();
    OcultarAlertaDinamica();
    idsUsuarios = [];
    var url = tipoOficinaSeleccionada === 1 ? urlRecuperarUsuariosOdg : urlRecuperarUsuarios;
    var data = tipoOficinaSeleccionada === 1 ? { oficinaId: oficinaId } : { oficinaId: oficinaId, tipoOficina: tipoOficinaSeleccionada };
    try {
        $.ajax({
            type: 'GET',
            url: url,
            contentType: 'application/json;charset=utf-8',
            cache: false,
            data: data,
            success: function (data) {
                var usuariosSelect = $('#usuariosSelect');
                usuariosSelect.empty();
                // Cargar usuarios
                if (!data || data.length === 0) {
                    usuariosSelect.prop('disabled', true);
                    $('#fechaInicio').prop('disabled', true);
                    $('#fechaFin').prop('disabled', true);
                    $('#tipoOperacion').prop('disabled', true);
                    $('#tipoEvento').prop('disabled', true);
                    mostrarAlertaDinamica('info', 'No se encontraron usuarios para la oficina seleccionada.');
                    return;
                }

                data.forEach(function (usuario) {
                    var usuarios = document.getElementById("usuariosSelect");
                    var option = document.createElement("option");
                    option.value = usuario.UsuarioId;
                    option.text = usuario.NombreUsuario;
                    idsUsuarios.push(usuario.UsuarioId);
                    usuarios.appendChild(option);
                });
                // Inicializar Select2 o actualizarlo si ya está inicializado
                $('#usuariosSelect').prop('disabled', false);
                $('#fechaInicio').prop('disabled', false);
                $('#fechaFin').prop('disabled', false);
                $('#tipoOperacion').prop('disabled', false);
                $('#tipoEvento').prop('disabled', false);
                $('#usuariosSelect').trigger('change');
            },
            error: function (xhr, status, error) {
                console.error('Error al recuperar usuarios:', error);
            }
        });
    } catch (e) {
        console.error('Error en RecuperarUsuariosPorSucursal:', e);
    }
}

// Función para validar campos requeridos
function validarCamposRequeridos() {
    var isValid = true;
    var tipoOperacion = document.getElementById("tipoOperacion");
    var fechaInicio = document.getElementById('fechaInicio');
    var fechaFin = document.getElementById('fechaFin');

    // Validar tipo operación
    if (!tipoOperacion.value) {
        tipoOperacion.classList.add('is-invalid');
        isValid = false;
    } else {
        tipoOperacion.classList.remove('is-invalid');
    }

    // Validar fecha
    if (!fechaInicio.value) {
        fechaInicio.classList.add('is-invalid');
        isValid = false;
    } else {
        fechaInicio.classList.remove('is-invalid');
    }
    if (!fechaFin.value) {
        fechaFin.classList.add('is-invalid');
        isValid = false;
    } else {
        fechaFin.classList.remove('is-invalid');
    }

    return isValid;
}

//Bloquear campo evento si operación es Acceso
function BloquearEvento() {
    var tipoOperacion = document.getElementById("tipoOperacion");
    var operacionSeleccionada = tipoOperacion.options[tipoOperacion.selectedIndex].value;
    var tipoEvento = document.getElementById("tipoEvento");
    tipoEvento.selectedIndex = -1;
    if (operacionSeleccionada === "4") {
        $("#tipoEvento").prop("disabled", true);
        $("#lblTipoEvento").hide();
    }
    else {
        $("#tipoEvento").prop("disabled", false);
    }
}

// Función principal para exportar a Excel
async function ExportarTablaAExcel() {
    const usuariosSeleccionados = obtenerUsuariosSeleccionados();
    const oficina = document.getElementById("oficinasSelect")?.value || -1;
    const tipoOperacion = document.getElementById("tipoOperacion")?.value || -1;
    const tipoEvento = document.getElementById("tipoEvento")?.value || -1;
    const fechaInicio = document.getElementById("fechaInicio").value;
    const fechaFin = document.getElementById("fechaFin")?.value || "";

    $(".invalid-feedback").hide();
    //OcultarAlertaDinamica();
    validarCamposRequeridos();
    if (!ValidarParametros(oficina, fechaInicio, fechaFin, tipoOperacion, tipoEvento)) return;

    MostrarSpinnerExcel();
    BloquearFiltros();

    try {
        const response = await fetch(exportarExcelUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({
                usuariosSeleccionados: usuariosSeleccionados ? usuariosSeleccionados.join(",") : "",
                tipoOperacion,
                tipoEvento,
                fechaInicio,
                fechaFin
            })

        });

        if (response.status === 204) {
            mostrarAlertaDinamica("warning", "No se encontraron registros para exportar.");
            FinalizarDescargaExcel();
            return;
        }

        if (!response.ok) {
            mostrarAlertaDinamica("danger", "Ocurrió un error al exportar el archivo.");
            FinalizarDescargaExcel();
            return;
        }

        const blob = await response.blob();
        let fileName = "Auditoria.xlsx";
        const disposition = response.headers.get("Content-Disposition");

        if (disposition && disposition.includes("filename=")) {
            const match = disposition.match(/filename=["']?([^"';\n]+)["']?/);
            if (match && match[1]) {
                fileName = match[1];
            }
        }

        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = fileName;
        document.body.appendChild(a);
        a.click();
        a.remove();
        window.URL.revokeObjectURL(url);

        mostrarAlertaDinamica("success", "Archivo Excel generado correctamente.");
    } catch (error) {
        console.error("Error:", error);
        alert("Ocurrió un error al exportar el Excel.");
    } finally {
        FinalizarDescargaExcel();
    }
}
function ValidarRangoFecha() {
    const inicioVal = $('#fechaInicio').val();
    const finVal = $('#fechaFin').val();

    if (!inicioVal || !finVal) return true;

    let [anioI, mesI, diaI] = inicioVal.split('-').map(Number);
    let [anioF, mesF, diaF] = finVal.split('-').map(Number);
    let diffMes;
    const diffAnio = anioF - anioI;
    if (mesI == 12 && mesF == 1) {
        diffMes = 1;
    }
    else if (mesI != 12) {
        if (mesI > mesF) {
            diffMes = mesI - mesF;
        }
        else {
            diffMes = mesF - mesI;
         }
    }     
    const rangoInvalido =
        (anioI !== anioF && (diffMes < 0 || diffMes > 1)) ||
        (diffMes >=0  && diffAnio >= 1 && mesI!=12) ||
        (anioI == anioF && (diffMes < 0 || diffMes > 1)) ||
        (diffMes === 1 && diaF > diaI);

    if (rangoInvalido) {
        mostrarAlertaDinamica(
            "warning",
            "El rango de fecha no debe ser mayor a un mes."
        );
        LimpiarFechaFin();
        return false;
    }

    return true;
}


function ValidarParametros(oficina, fechaInicio, fechaFin, tipoOperacion, tipoEvento) {

    const oficinaSeleccionada = oficina;
    const dateInicio = new Date(fechaInicio);
    const dateFin = new Date(fechaFin);
    if (oficinaSeleccionada == null || oficinaSeleccionada == undefined || oficinaSeleccionada == "" || oficinaSeleccionada == -1) {
        $("#lblOficinas").show();
        return false;
    }
    if (fechaInicio == null || fechaInicio == undefined || fechaInicio == "") {
        $("#lblFechaInicio").show();
        return false;
    }
    if (fechaFin == null || fechaFin == undefined || fechaFin == "") {
        $("#lblFechaFin").show();
        return false;
    }
    if (dateFin < dateInicio) {
        $("#lblFechaFinAlerta").show();
        return false;
    }
    if (tipoOperacion == null || tipoOperacion == undefined || tipoOperacion == "" || tipoOperacion == -1) {
        $("#lblTipoOperacion").show();
        return false;
    }
    if (tipoOperacion !== "4") {
        if (tipoEvento == null || tipoEvento == undefined || tipoEvento == "" || tipoEvento == -1) {
            $("#lblTipoEvento").show();
            return false;
        }
    }
    return true;
}

//function crearInputOculto(name, value) {
//    var input = document.createElement("input");
//    input.type = "hidden";
//    input.name = name;
//    input.value = value;
//    return input;
//}
function MostrarSpinnerExcel() {
    $('#modalSpinnerExcel').modal('show');
}
function OcultarSpinnerExcel() {
    $('#modalSpinnerExcel').modal('hide');

}  
function mostrarAlertaDinamica(tipo, mensaje) {
    const alerta = document.getElementById("alertaBasica");
    const mensajeSpan = document.getElementById("mensajeBasico");

    alerta.className = `alert alert-${tipo} mt-3`;
    mensajeSpan.textContent = mensaje;
    alerta.style.display = "block";

    //setTimeout(() => {
    //    alerta.style.display = "none";
    //}, 5000);
}
function OcultarAlertaDinamica() {
    const alerta = document.getElementById("alertaBasica");
    alerta.style.display = "none";
}
function BloquearFiltros() {
    const filtros = document.querySelectorAll("#usuarioId, #tipoOperacion, #tipoEvento, #auditDate, #generarReporte, #btnExportarExcel");
    filtros.forEach(elem => {
        elem.disabled = true;
    });
}
function DesbloquearFiltros() {
    const filtros = document.querySelectorAll("#usuarioId, #tipoOperacion, #tipoEvento, #auditDate, #generarReporte, #btnExportarExcel");
    filtros.forEach(elem => {
        elem.disabled = false;
    });
}
function FinalizarDescargaExcel() {
    OcultarSpinnerExcel();
    DesbloquearFiltros();
}

function obtenerUsuariosSeleccionados() {
    var usuarios = $('#usuariosSelect').val();

    if (usuarios && usuarios.length > 0) {
        return $('#usuariosSelect').val();
    } else {
        return idsUsuarios;
    }
}
function LimpiarFechaFin() {
    $('#fechaFin').val('');
}
function LimpiarUsuarios() {
    const usuariosSelect = $('#usuariosSelect');

    usuariosSelect.empty();
    usuariosSelect.val(null).trigger('change');
    usuariosSelect.prop('disabled', true);
}

