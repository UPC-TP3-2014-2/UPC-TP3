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

    $('#solicitud-insumo-form').on('submit', registrarSolicitudInsumo);
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
            var registro = '<tr><td>' + item['Id'] + '</td><td>' + item['Descripcion'] + '</td><td><input type="checkbox" name="insumo-id-select" value="' + item['Id'] + '" /></td></tr>';
            $("#buscar-insumo-tabla tbody").append(registro);
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
    $("#SolicitudCocinaId").val(SolicitudCocinaId);
    $('#buscar-solicitud-cocina-container').collapse('hide');
}


function aceptarBusquedaInsumo() {

    var insumos = $('input[name="insumo-id-select"]:checked');

    
    insumos.each(function () {

        var id = $(this).val();

        $.post('/Insumo/SearchById/' + id, function (data) {
            var registro = '<tr><td>' + data['Id'] + '<input type="hidden" name="insumo-id" id="insumo-id[' + data['Id'] + ']" value="' + data['Id'] + '" /></td><td>' + data['Descripcion'] + '</td><td>' + data['Descripcion'] + '</td><td><div class="col-lg-4"><input type="number" name="insumo-cantidad" id="insumo-cantidad[' + data['Id'] + ']" class="form-control" /></div></td></td></tr>';
            $('#insumo-tabla tbody').append(registro);
        });

    });

    $('#busq-insumo-container').collapse('hide');
}



function registrarSolicitudInsumo() {

    var url = $(this).attr("action");
    var data = {
        'SolicitudCocinaId': $('#SolicitudCocinaId').val(),
        'Insumos': []
    };
    

    var filas = $('#insumo-tabla tbody').each(function (item) {
        
        console.log(item);
        var id = $('input[name="insumo-id"]', this).val();
        var cantidad = $('input[name="insumo-cantidad"]', this).val()

        data['Insumos'].push(id);
    });

    console.log(data);

    
    //$.ajax({
    //    type: "POST",
    //    url: url,
    //    data: data, 
    //    success: function (data) {
    //        alert(data.Result);
    //    },
    //    dataType: "json",
    //    traditional: true,
    //    contentType: "application/json; charset=utf-8"
    //});

    return false;
}