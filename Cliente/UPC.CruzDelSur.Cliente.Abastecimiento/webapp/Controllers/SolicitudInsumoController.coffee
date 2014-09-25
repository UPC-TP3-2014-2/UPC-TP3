# SolicitudInsumoController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudInsumoController", ["$scope", "$routeParams", "$location", "SolicitudInsumoService", "SolicitudCocinaService", "InsumoService", ($scope, $routeParams, $location, $solicitudInsumoService, $solicitudCocinaService, $insumoService) ->
    
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    $scope.registrar.solicitudInsumo = {}
    $scope.registrar.registrado = false
    
    if not angular.isUndefined $routeParams.id
        $solicitudInsumoService
            .getById $routeParams.id
            .success (data) ->
                $scope.anular.solicitudInsumo = data
                return

    
    # Consultar
    $scope.consultar.buscarPorId = (id) ->
        if angular.isUndefined id
            $solicitudInsumoService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoSolicitudesInsumo = data
                    return
        else
            $solicitudInsumoService
                .getById id
                .success (data) ->
                    $scope.consultar.listadoSolicitudesInsumo = [data]
                    return
        return

    
    $scope.consultar.buscarPorRangoFechas = (fechaInicial, fechaFinal) ->
        if (angular.isUndefined(fechaInicial) or fechaInicial.trim() == "") or (angular.isUndefined(fechaFinal) or fechaFinal.trim() == "")
            $solicitudInsumoService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoSolicitudesInsumo = data
                    return
        else
            $solicitudInsumoService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data) ->
                    $scope.consultar.listadoSolicitudesInsumo = data
                    return
        return

    
    # Anular
    $scope.anular.anularSolicitud = (solicitudInsumo) ->
        solicitudInsumo.estado = 0

        $solicitudInsumoService
            .update solicitudInsumo
            .success (data) ->
                $location.path "/SolicitudInsumo/Consultar"
                return

        return


    # Registrar
    $insumoService
        .getAll()
        .success (data) ->
            $scope.registrar.listadoInsumos = data
            return

    $scope.registrar.buscarSolicitudCocina = (fechaInicial, fechaFinal) ->
        if (angular.isUndefined(fechaInicial) or fechaInicial.trim() == "" ) or (angular.isUndefined(fechaFinal) or fechaFinal.trim() == "")
            $solicitudCocinaService
                .getAll()
                .success (data)->
                    $scope.registrar.listadoSolicitudCocina = _.where data, {estado: 1}
                    return
        else
            $solicitudCocinaService
                .getByDateRange(fechaInicial, fechaFinal)
                .success (data)->
                    $scope.registrar.listadoSolicitudCocina = _.where data, {estado: 1}
                    return
        return
    
    $scope.registrar.cancelarBusquedaSolicitudCocina = () ->
        $scope.registrar.listadoSolicitudCocina = []
        return
    
    $scope.registrar.seleccionarSolicitudCocina = (solicitudCocina) ->
        $scope.registrar.solicitudInsumo.solicitudCocina = solicitudCocina
        return
        
    $scope.registrar.registrarSolicitud = (solicitudInsumo) ->
        solicitudInsumo.id = 0
        solicitudInsumo.estado = 0

        $solicitudInsumoService
            .save(solicitudInsumo)
            .success (data) ->
                $scope.registrar.registrado = true
                return
        return

    
    
    return
]