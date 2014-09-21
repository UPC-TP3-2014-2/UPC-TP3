# config.coffee
# @author: Ricardo Barreno <rickraf.01@gmail.com>


abastecimiento.config ["$routeProvider", ($routeProvider) ->
    

    # Routing
    $routeProvider
        .when "/", {
            templateUrl: "Scripts/Webapp/Templates/Home.html"
            controller: "HomeController"
        }
        .when "/SolicitudCocina/Register", {
            templateUrl: "Scripts/Webapp/Templates/SolicitudCocina/Register.html"
            controller: "SolicitudCocinaController"
        }
        .when "/SolicitudCocina/Search", {
            templateUrl: "Scripts/Webapp/Templates/SolicitudCocina/Search.html"
            controller: "SolicitudCocinaController"
        }
        .otherwise {
            redirectTo: "/"
        }

    
    return
]

