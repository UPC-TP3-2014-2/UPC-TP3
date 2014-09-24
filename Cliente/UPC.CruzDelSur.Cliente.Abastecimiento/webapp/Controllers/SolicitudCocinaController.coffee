# SolicitudCocinaController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudCocinaController", ["$scope", "$routeParams", "$location", "SolicitudCocinaService", "ProgramacionRutaService", ($scope, $routeParams, $location, $solicitudCocinaService, $programacionRutaService) ->
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    
    $scope.registrar.message = "Hola Mundo desde Solicitud Cocina Controller - Register"


    $programacionRutaService
        .getAll()
        .success (data) ->
            $scope.registrar.listadoProgramacionRuta = data
            return



    if not angular.isUndefined $routeParams.id
        $solicitudCocinaService
            .getById $routeParams.id
            .success (data) ->
                $scope.anular.solicitudCocina = data
                return

    $scope.consultar.buscarPorId = (id) ->
        if angular.isUndefined id
            console.log "El id es indefinido"
        else
            $solicitudCocinaService
                .getById id
                .success (data) ->
                    console.log "Búsqueda por id: " + id
                    $scope.consultar.listadoSolicitudesCocina = [data]
                    return
        return
    

    $scope.consultar.buscarPorRangoFechas = (fechaInicial, fechaFinal) ->
        
        if angular.isUndefined fechaInicial
            console.log "No se ha ingresado la fecha inicial."
        else if angular.isUndefined fechaFinal
            console.log "No se ha ingresado la fecha final."
        else
            $solicitudCocinaService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data) ->
                    console.log "Búsqueda por fechas: " + fechaInicial + " - " + fechaFinal
                    $scope.consultar.listadoSolicitudesCocina = data   
                    return
        return

    $scope.anular.anularSolicitud = (solicitudCocina) ->
        solicitudCocina.estado = 0

        $solicitudCocinaService
            .update solicitudCocina
            .success (data) ->
                $location.path "/SolicitudCocina/Consultar"
                return

        return
    
    
    return
]