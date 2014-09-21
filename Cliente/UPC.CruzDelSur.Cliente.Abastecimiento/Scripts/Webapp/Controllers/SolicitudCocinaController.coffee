# SolicitudCocinaController.coffee
# @author: Ricardo Barreno <rickraf.@gmail.com>

abastecimiento.controller "SolicitudCocinaController", ["$scope", ($scope) ->
    $scope.search = {}
    $scope.register = {}
    
    $scope.register.message = "Hola Mundo desde Solicitud Cocina Controller - Register"
    $scope.search.message = "Hola Mundo desde Solicitud Cocina Controller - Search"

    return
]