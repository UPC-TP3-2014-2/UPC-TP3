# SolicitudInsumoService.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

abastecimiento.factory "SolicitudInsumoService", ["$http", ($http) ->

    return {
        getAll: () ->
            return $http.get "api/SolicitudInsumo"

        getById: (id) ->
            return $http.get "api/SolicitudInsumo/" + id

        getByRangeDate: (fechaInicial, fechaFinal) ->
            return $http.get "api/SolicitudInsumo?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal

        save: (solicitudInsumo) ->
            return $http.post "api/SolicitudInsumo", solicitudInsumo

        update: (solicitudInsumo) ->
            return $http.put "api/SolicitudInsumo", solicitudInsumo
    }
]