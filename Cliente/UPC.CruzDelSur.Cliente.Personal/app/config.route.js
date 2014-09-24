(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            setRoute(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });

        function setRoute(url, definition) {
            definition.resolve = angular.extend(definition.resolve || {}, {
                prime: prime
            });
            $routeProvider.when(url, definition);

            return $routeProvider;
        }
    }

    prime.$inject = ['datacontext'];
    function prime(datacontext) { return datacontext.prime(); }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            },
            {
                url: '/personas',
                config: {
                    title: 'personas',
                    templateUrl: 'app/persona/personas.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-group"></i> Personas'
                    }
                }
            },
            {
                url: '/persona/:id',
                config: {
                    title: 'persona',
                    templateUrl: 'app/persona/personadetalle.html',
                    settings: { }
                }
            },
            {
                url: '/persona/:idPersona/cargoDesempenado/:idCargoDesempenado',
                config: {
                    title: 'cargo desempenado',
                    templateUrl: 'app/persona/cargoDesempenado/cargodesempenadodetalle.html',
                    settings: {}
                }
            },
            {
                url: '/persona/:idPersona/educacion/:idEducacion',
                config: {
                    title: 'educacion',
                    templateUrl: 'app/persona/educacion/educaciondetalle.html',
                    settings: {}
                }
            },
            {
                url: '/persona/:idPersona/experienciaLaboral/:idExperienciaLaboral',
                config: {
                    title: 'experiencia laboral',
                    templateUrl: 'app/persona/experienciaLaboral/experiencialaboraldetalle.html',
                    settings: {}
                }
            },
            {
                url: '/solicitudes/capacitacion',
                config: {
                    title: 'solicitudes de capacitacion',
                    templateUrl: 'app/solicitud/capacitacion/solicitudescapacitacion.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-file"></i> Capacitaciones'
                    }
                }
            },
            {
                url: '/solicitud/capacitacion/:id',
                config: {
                    title: 'solicitud de capacitacion',
                    templateUrl: 'app/solicitud/capacitacion/solicitudcapacitaciondetalle.html',
                    settings: {}
                }
            },
            {
                url: '/solicitudes/personal',
                config: {
                    title: 'solicitudes de personal',
                    templateUrl: 'app/solicitud/personal/solicitudespersonal.html',
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-file"></i> Contrataciones'
                    }
                }
            },
            {
                url: '/solicitud/personal/:id',
                config: {
                    title: 'solicitud de personal',
                    templateUrl: 'app/solicitud/personal/solicitudpersonaldetalle.html',
                    settings: {}
                }
            },
            {
                url: '/auditorias',
                config: {
                    title: 'auditorias',
                    templateUrl: 'app/auditoria/auditorias.html',
                    settings: {
                        nav: 5,
                        content: '<i class="fa fa-legal"></i> Auditorias'
                    }
                }
            },
        ];
    }
})();