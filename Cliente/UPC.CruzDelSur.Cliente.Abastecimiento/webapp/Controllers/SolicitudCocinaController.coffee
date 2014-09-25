# SolicitudCocinaController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudCocinaController", ["$scope", "$routeParams", "$location", "SolicitudCocinaService", "ProgramacionRutaService", "InsumoService", ($scope, $routeParams, $location, $solicitudCocinaService, $programacionRutaService, $insumoService) ->
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    
    $scope.registrar.message = "Hola Mundo desde Solicitud Cocina Controller - Register"


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
        
        if angular.isUndefined(fechaInicial) or angular.isUndefined(fechaFinal)
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
    $scope.registrar.buscarProgramacionRuta = (fechaInicialOrigen, fechaFinalOrigen) ->
        if angular.isUndefined(fechaInicialOrigen) or angular.isUndefined(fechaFinalOrigen)
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







 
    
    return
]