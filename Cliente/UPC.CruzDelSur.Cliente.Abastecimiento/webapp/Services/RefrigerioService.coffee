# RefrigerioService.coffee
# @author: Ricardo Barreno Cortijo

abastecimiento.factory "RefrigerioService", ["$http", ($http) ->
    {
        getAll: () ->
            return $http.get "api/Refrigerio"

        getById: (id) ->
            return $http.get "api/Refrigerio/" + id
    }
]