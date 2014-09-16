$(document).on("ready", loadPage);


function loadPage() {
    $("#buscar-solicitud-cocina").on("click", buscarSolicitudCocina)
    
}


function buscarSolicitudCocina() {
    var url = $(this).attr("href");


    $.post(url, function (data) {
        

        $("#buscar-solicitud-cocina-tabla tbody").html("");

        data.forEach(function (item) {
            $("#buscar-solicitud-cocina-tabla tbody")
                .append('<tr><td>' + item["FechaIngreso"] + '</td><td>' + item["NroSolicitud"] + '</td><td>' + item["UnidadTransporte"] + '</td><td>' + item["RutaProgramada"] + '</td><td><input type="radio" name="buscar-solicitud-cocina-radio" value="' + item["NroSolicitud"] + '" /></td></tr>');
        });



    });

    return false;



    
}

function seleccionarSolicitudCocina()
{
    console.log("Selección la solicitud " + $('input[name="buscar-solicitud-cocina-radio"]:checked').val());
}
