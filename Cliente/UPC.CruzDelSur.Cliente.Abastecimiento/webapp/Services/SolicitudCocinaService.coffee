# SolicitudCocinaService.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

abastecimiento.factory "SolicitudCocinaService", ["$http", ($http) ->

    return {
        getAll: () ->
            return $http.get "api/SolicitudCocina"

        getById: (id) ->
            return $http.get "api/SolicitudCocina/" + id

        getByRangeDate: (fechaInicial, fechaFinal) ->
            return $http.get "api/SolicitudCocina?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal

        save: (solicitudCocina) ->
            return $http.post "api/SolicitudCocina", solicitudCocina

        update: (solicitudCocina) ->
            return $http.put "api/SolicitudCocina", solicitudCocina
    }
]