$(document).on("ready", loadPage);


function loadPage() {
    ocultarBotonAceptarBusquedaSolicitudCocina();
    ocultarMensajeErrorAceptarBusquedaSolicitudCocina();
    limpiarTablaBusquedaSolicitudCocina();

    ocultarBotonAceptarBusquedaInsumo();
    ocultarMensajeErrorAceptarBusquedaInsumo();
    limpiarTablaBusquedaInsumo();

    $("#buscar-solicitud-cocina").on("click", buscarSolicitudCocina);
    $('#buscar-solicitud-cocina-aceptar').on('click', aceptarBusquedaSolicitudCocina);

    $("#buscar-insumo").on("click", buscarInsumo);
    $('#buscar-insumo-aceptar').on('click', aceptarBusquedaInsumo);
}


function buscarSolicitudCocina() {
    var url = $(this).attr("href");

    $.post(url, function (data) {

        ocultarBotonAceptarBusquedaSolicitudCocina();
        limpiarTablaBusquedaSolicitudCocina();

        data.forEach(function (item) {
            $("#buscar-solicitud-cocina-tabla tbody").append('<tr><td>' + item["FechaIngreso"] + '</td><td>' + item["NroSolicitud"] + '</td><td>' + item["UnidadTransporte"] + '</td><td>' + item["RutaProgramada"] + '</td><td><input type="radio" name="buscar-solicitud-cocina-radio" value="' + item["NroSolicitud"] + '" /></td></tr>');
        });

        mostrarBotonAceptarBusquedaSolicitudCocina();

    });

    return false;
    
}


function buscarInsumo() {
    var url = $(this).attr("href");
    
    $.post(url, function (data) {
        ocultarBotonAceptarBusquedaInsumo();
        limpiarTablaBusquedaInsumo();

        data.forEach(function (item) {
            $("#buscar-insumo-tabla tbody").append('');
        });

        mostrarBotonAceptarBusquedaInsumo();
    });

    return false;
}




function limpiarTablaBusquedaSolicitudCocina() {
    $("#buscar-solicitud-cocina-tabla tbody").html("");
}

function limpiarTablaBusquedaInsumo() {
    $("#buscar-insumo-tabla tbody").html("");
}


function ocultarBotonAceptarBusquedaSolicitudCocina() {
    $("#buscar-solicitud-cocina-aceptar").hide();
}

function ocultarBotonAceptarBusquedaInsumo() {
    $("#buscar-insumo-aceptar").hide();
}

function mostrarBotonAceptarBusquedaSolicitudCocina() {
    $("#buscar-solicitud-cocina-aceptar").show();
}

function mostrarBotonAceptarBusquedaInsumo() {
    $("#buscar-insumo-aceptar").show();
}

function mostrarMensajeErrorAceptarBusquedaSolicitudCocina(mensaje) {
    $('#buscar-solicitud-cocina-aceptar-error').show().html(mensaje);
}

function mostrarMensajeErrorAceptarBusquedaInsumo(mensaje) {
    $('#buscar-insumo-aceptar-error').show().html(mensaje);
}

function ocultarMensajeErrorAceptarBusquedaSolicitudCocina(mensaje) {
    $('#buscar-solicitud-cocina-aceptar-error').hide();
}

function ocultarMensajeErrorAceptarBusquedaInsumo(mensaje) {
    $('#buscar-insumo-aceptar-error').hide();
}

function aceptarBusquedaSolicitudCocina() {
    var SolicitudCocinaId = $('input[name="buscar-solicitud-cocina-radio"]:checked').val();

    ocultarMensajeErrorAceptarBusquedaSolicitudCocina();

    if (typeof (SolicitudCocinaId) == 'undefined' || SolicitudCocinaId.trim() == '') {
        mostrarMensajeErrorAceptarBusquedaSolicitudCocina('Debe seleccionar una Solicitud de Cocina.');
        return false;
    };

    $("#solicitud-cocina-id").val(SolicitudCocinaId);
    $('#buscar-solicitud-cocina-container').collapse('hide');
}


function aceptarBusquedaInsumo() {
    console.log("aaaa");
    //var SolicitudCocinaId = $('input[name="buscar-solicitud-cocina-radio"]:checked').val();

    //ocultarMensajeErrorAceptarBusquedaSolicitudCocina();

    //if (typeof (SolicitudCocinaId) == 'undefined' || SolicitudCocinaId.trim() == '') {
    //    mostrarMensajeErrorAceptarBusquedaSolicitudCocina('Debe seleccionar una Solicitud de Cocina.');
    //    return false;
    //};

    //$("#solicitud-cocina-id").val(SolicitudCocinaId);
    //$('#buscar-solicitud-cocina-container').collapse('hide');
}
