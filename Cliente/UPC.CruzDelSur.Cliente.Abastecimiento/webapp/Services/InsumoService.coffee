# InsumoService.coffee
# @author: Ricardo Barreno Cortijo

abastecimiento.factory "InsumoService", ["$http", ($http) ->
    {
        getAll: () ->
            return $http.get "api/Insumo"

        getById: (id) ->
            return $http.get "api/Insumo/" + id
    }
]