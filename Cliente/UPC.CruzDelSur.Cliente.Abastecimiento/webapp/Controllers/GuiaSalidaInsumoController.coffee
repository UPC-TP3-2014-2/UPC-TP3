# GuiaSalidaInsumoController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "GuiaSalidaInsumoController", ["$scope", "$routeParams", "$location", "GuiaSalidaInsumoService", "SolicitudInsumoService", ($scope, $routeParams, $location, $guiaSalidaInsumoService, $solicitudInsumoService) ->
    
    $scope.consultar = {}
    $scope.anular = {}
    $scope.registrar = {}
    $scope.registrar.guiaSalidaInsumo = {}
    $scope.registrar.registrado = false

    if not angular.isUndefined $routeParams.id
        $guiaSalidaInsumoService
            .getById $routeParams.id
            .success (data) ->
                $scope.anular.guiaSalidaInsumo = data
                return

    # Consultar
    $scope.consultar.buscarPorId = (id) ->
        if angular.isUndefined id
            $guiaSalidaInsumoService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoGuiaSalidaInsumo = data
                    return
        else
            $guiaSalidaInsumoService
                .getById id
                .success (data) ->
                    $scope.consultar.listadoGuiaSalidaInsumo = [data]
                    return
        return

    
    $scope.consultar.buscarPorRangoFechas = (fechaInicial, fechaFinal) ->
        if (angular.isUndefined(fechaInicial) or fechaInicial.trim() == "") or (angular.isUndefined(fechaFinal) or fechaFinal.trim() == "")
            $guiaSalidaInsumoService
                .getAll()
                .success (data) ->
                    $scope.consultar.listadoGuiaSalidaInsumo = data
                    return
        else
            $solicitudInsumoService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data) ->
                    $scope.consultar.listadoGuiaSalidaInsumo = data
                    return
        return
    
    
    # Anular
    $scope.anular.anularGuiaSalidaInsumo = (guiaSalidaInsumo) ->
        guiaSalidaInsumo.estado = 0

        $guiaSalidaInsumoService 
            .update guiaSalidaInsumo
            .success (data) ->
                $location.path "/GuiaSalidaInsumo/Consultar"
                return
        return

    # Registrar
    $scope.registrar.buscarSolicitudInsumo = (fechaInicial, fechaFinal) ->
        if (angular.isUndefined(fechaInicial) or fechaInicial.trim() == "" ) or (angular.isUndefined(fechaFinal) or fechaFinal.trim() == "")
            $solicitudInsumoService
                .getAll()
                .success (data)->
                    $scope.registrar.listadoSolicitudInsumo = _.where data, {estado: 1}
                    return
        else
            $solicitudInsumoService
                .getByRangeDate(fechaInicial, fechaFinal)
                .success (data)->
                    $scope.registrar.listadoSolicitudInsumo = _.where data, {estado: 1}
                    return
        return

    $scope.registrar.cancelarBusquedaSolicitudInsumo = () ->
        $scope.registrar.listadoSolicitudInsumo = []
        return
    
    $scope.registrar.seleccionarSolicitudInsumo = (solicitudInsumo) ->
        $scope.registrar.guiaSalidaInsumo.solicitudInsumo = solicitudInsumo
        return

    $scope.registrar.registrarGuiaSalidaInsumo = (guiaSalidaInsumo) ->
        guiaSalidaInsumo.id = 0
        guiaSalidaInsumo.estado = 0

        $guiaSalidaInsumoService
            .save(guiaSalidaInsumo)
            .success (data) ->
                $scope.registrar.registrado = true
                return
        return

    return
]