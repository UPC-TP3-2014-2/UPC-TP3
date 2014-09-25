# SolicitudCocinaController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudCocinaController", ["$scope", "$routeParams", "$location", "SolicitudCocinaService", "ProgramacionRutaService", "RefrigerioService", ($scope, $routeParams, $location, $solicitudCocinaService, $programacionRutaService, $refrigerioService) ->
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    $scope.registrar.solicitudCocina = {}
    $scope.registrar.registrado = false


    if not angular.isUndefined $routeParams.id
        $solicitudCocinaService
            .getById $routeParams.id
            .success (data) ->
                $scope.anular.solicitudCocina = data
                return

    # consultar
    
    $scope.consultar.buscarPorId = (id) ->
        if angular.isUndefined id
            $solicitudCocinaService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoSolicitudesCocina = data
                    return
        else
            $solicitudCocinaService
                .getById id
                .success (data) ->
                    $scope.consultar.listadoSolicitudesCocina = [data]
                    return
        return
    

    $scope.consultar.buscarPorRangoFechas = (fechaInicial, fechaFinal) ->
        
        if (angular.isUndefined(fechaInicial) or fechaInicial.trim() == "") or (angular.isUndefined(fechaFinal) or fechaFinal.trim() == "")
            $solicitudCocinaService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoSolicitudesCocina = data   
                    return
        else
            $solicitudCocinaService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data) ->
                    $scope.consultar.listadoSolicitudesCocina = data   
                    return
        return


    # anular
    $scope.anular.anularSolicitud = (solicitudCocina) ->
        solicitudCocina.estado = 0

        $solicitudCocinaService
            .update solicitudCocina
            .success (data) ->
                $location.path "/SolicitudCocina/Consultar"
                return
        return


    # registrar

    $refrigerioService
        .getAll()
        .success (data) ->
            $scope.registrar.listadoRefrigerios = data
            return

    $scope.registrar.buscarProgramacionRuta = (fechaInicialOrigen, fechaFinalOrigen) ->
        if (angular.isUndefined(fechaInicialOrigen) or fechaInicialOrigen.trim() == "" ) or (angular.isUndefined(fechaFinalOrigen) or fechaFinalOrigen.trim() == "")
            $programacionRutaService
                .getAll()
                .success (data)->
                    $scope.registrar.listadoProgramacionRuta = data
                    return
        else
            $programacionRutaService
                .getByDateRange(fechaInicialOrigen, fechaFinalOrigen)
                .success (data)->
                    $scope.registrar.listadoProgramacionRuta = data
                    return
        return
    
    $scope.registrar.cancelarBusquedaProgramacionRuta = () ->
        $scope.registrar.listadoProgramacionRuta = []
        return

    $scope.registrar.seleccionarProgramacionRuta = (programacionRuta) ->
        $scope.registrar.solicitudCocina.programacionRuta = programacionRuta
        $scope.registrar.cancelarBusquedaProgramacionRuta()
        return

    $scope.registrar.registrarSolicitud = (solicitudCocina) ->
        solicitudCocina.id = 0
        solicitudCocina.estado = 1

        $solicitudCocinaService
            .save(solicitudCocina)
            .success (data) ->
                $scope.registrar.registrado = true
                return
        return
    
    $scope.registrar.seleccionarRefrigerio = (refrigerio) ->
        console.log refrigerio
        return





 
    
    return
]