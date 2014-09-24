# config.coffee
# @author: Ricardo Barreno <rickraf.01@gmail.com>


abastecimiento.config ["$routeProvider", ($routeProvider) ->
    

    # Routing
    $routeProvider
        .when "/", {
            templateUrl: "Webapp/Templates/Home.html"
            controller: "HomeController"
        }
        .when "/SolicitudCocina/Registrar", {
            templateUrl: "Webapp/Templates/SolicitudCocina/Registrar.html"
            controller: "SolicitudCocinaController"
        }
        .when "/SolicitudCocina/Consultar", {
            templateUrl: "Webapp/Templates/SolicitudCocina/Consultar.html"
            controller: "SolicitudCocinaController"
        }
        .when "/SolicitudCocina/Anular/:id", {
            templateUrl: "Webapp/Templates/SolicitudCocina/Anular.html"
            controller: "SolicitudCocinaController"
        }
        .when "/SolicitudInsumo/Consultar", {
            templateUrl: "Webapp/Templates/SolicitudInsumo/Consultar.html"
            controller: "SolicitudInsumoController"
        }
        .when "/SolicitudInsumo/Anular/:id", {
            templateUrl: "Webapp/Templates/SolicitudInsumo/Anular.html"
            controller: "SolicitudInsumoController"
        }
        .otherwise {
            redirectTo: "/"
        }

    return
]

