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
        .when "/SolicitudInsumo/Registrar", {
            templateUrl: "Webapp/Templates/SolicitudInsumo/Registrar.html"
            controller: "SolicitudInsumoController"
        }
        .when "/SolicitudInsumo/Consultar", {
            templateUrl: "Webapp/Templates/SolicitudInsumo/Consultar.html"
            controller: "SolicitudInsumoController"
        }
        .when "/SolicitudInsumo/Anular/:id", {
            templateUrl: "Webapp/Templates/SolicitudInsumo/Anular.html"
            controller: "SolicitudInsumoController"
        }
        .when "/GuiaSalidaInsumo/Registrar", {
            templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Registrar.html"
            controller: "GuiaSalidaInsumoController"
        }
        .when "/GuiaSalidaInsumo/Consultar", {
            templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Consultar.html"
            controller: "GuiaSalidaInsumoController"
        }
        .when "/GuiaSalidaInsumo/Anular/:id", {
            templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Anular.html"
            controller: "GuiaSalidaInsumoController"
        }
        .otherwise {
            redirectTo: "/"
        }

    return
]

