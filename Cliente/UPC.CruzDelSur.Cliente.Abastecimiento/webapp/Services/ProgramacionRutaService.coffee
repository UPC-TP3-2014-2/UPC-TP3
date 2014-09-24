# ProgramacionRutaService.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

abastecimiento.factory "ProgramacionRutaService", ["$http", ($http) ->

    return {
        getAll: () ->
            return $http.get "api/ProgramacionRuta"

        getById: (id) ->
            return $http.get "api/ProgramacionRuta/" + id
    }
]