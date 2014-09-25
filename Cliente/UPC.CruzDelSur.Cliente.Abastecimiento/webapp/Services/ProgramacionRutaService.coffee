# ProgramacionRutaService.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

abastecimiento.factory "ProgramacionRutaService", ["$http", ($http) ->
    {
        getAll: () ->
            return $http.get "api/ProgramacionRuta"

        getById: (id) ->
            return $http.get "api/ProgramacionRuta/" + id

        getByDateRange: (fechaInicial, fechaFinal) ->
            return $http.get "api/ProgramacionRuta?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal
    }
]