# SolicitudInsumoController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudInsumoController", ["$scope", "$routeParams", "$location", "SolicitudInsumoService", ($scope, $routeParams, $location, $solicitudInsumoService) ->
    
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    
    $scope.registrar.message = "Hola Mundo desde Solicitud Insumo Controller - Registrar."


    if not angular.isUndefined $routeParams.id
        $solicitudInsumoService
            .getById $routeParams.id
            .success (data) ->
                $scope.anular.solicitudInsumo = data
                return

    $scope.consultar.buscarPorId = (id) ->
        if angular.isUndefined id
            console.log "El id es indefinido"
        else
            $solicitudInsumoService
                .getById id
                .success (data) ->
                    console.log "Búsqueda por id: " + id
                    $scope.consultar.listadoSolicitudesInsumo = [data]
                    return
        return

    $scope.consultar.buscarPorRangoFechas = (fechaInicial, fechaFinal) ->

        if angular.isUndefined fechaInicial
            console.log "No se ha ingreso la fecha inicial."
        else if angular.isUndefined fechaFinal
            console.log "No se ha ingreso la fecha final."
        else
            $solicitudInsumoService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data) ->
                    console.log "Búsqueda por fechas: " + fechaInicial + " - " + fechaFinal
                    $scope.consultar.listadoSolicitudesInsumo = data
                    return
        return

    
    $scope.anular.anularSolicitud = (solicitudInsumo) ->
        solicitudInsumo.estado = 0

        $solicitudInsumoService
            .update solicitudInsumo
            .success (data) ->
                $location.path "/SolicitudInsumo/Consultar"
                return

        return
    
    
    return
]