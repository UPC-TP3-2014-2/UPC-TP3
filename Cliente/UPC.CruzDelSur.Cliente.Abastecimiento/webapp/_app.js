var abastecimiento = angular.module('abastecimiento', ['ui.bootstrap', 'ngRoute']);


// Routing
abastecimiento.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider
        .when('/', {
            templateUrl: 'Scripts/webapp/template/home.html',
            controller: 'HomeController'
        })
        .when('/SolicitudCocina', {
            templateUrl: 'Scripts/webapp/template/solicitud-cocina/consultar.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudCocina/Anular/:id', {
            templateUrl: 'Scripts/webapp/template/solicitud-cocina/anular.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudCocina/Register', {
            templateUrl: 'Scripts/webapp/template/solicitud-cocina/registrar.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudCocina/Edit/:id', {
            templateUrl: 'Scripts/webapp/template/solicitud-cocina/actualizar.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudInsumo', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/consultar.html',
            controller: 'SolicitudInsumoController'
        })
        .when('/SolicitudInsumo/Anular/:id', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/anular.html',
            controller: 'SolicitudInsumoController'
        })
        .when('/SolicitudInsumo/Register', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/registrar.html',
            controller: 'SolicitudInsumoController'
        })
        .when('/SolicitudInsumo/Edit/:id', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/actualizar.html',
            controller: 'SolicitudInsumoController'
        });

}]);


// Servicios
abastecimiento.factory('ProgramacionRutaService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/ProgramacionRuta'); },
        getById: function (id) { return $http.get('/api/ProgramacionRuta/' + id); }
    };
}]);

abastecimiento.factory('RefrigerioService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/Refrigerio'); },
        getById: function (id) { return $http.get('/api/Refrigerio/' + id); }
    };
}]);

abastecimiento.factory('InsumoService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/Insumo'); },
        getById: function (id) { return $http.get('/api/Insumo/' + id); }
    };
}]);

abastecimiento.factory('SolicitudCocinaService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/SolicitudCocina'); },
        getById: function (id) { return $http.get('/api/SolicitudCocina/' + id); },
        getByRangeDate: function (dateStart, dateEnd) { return $http.get('/api/SolicitudCocina?fechaInicial=' + dateStart + '&fechaFinal=' + dateEnd); },
        save: function (data) { return $http.post('/api/SolicitudCocina/', data, { headers: { 'Content-Type': 'application/json' } }); },
        update: function (data) { return $http.put('/api/SolicitudCocina/', data, { headers: { 'Content-Type': 'application/json' } }); }
    };
}]);

abastecimiento.factory('SolicitudInsumoService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/SolicitudInsumo'); },
        getById: function (id) { return $http.get('/api/SolicitudInsumo/' + id); },
        save: function (data) { return $http.post('/api/SolicitudInsumo/', data, { headers: { 'Content-Type': 'application/json' } }); },
        update: function (data) { return $http.put('/api/SolicitudInsumo/', data, { headers: { 'Content-Type': 'application/json' } }); }
    };
}]);


// controllers
abastecimiento.controller('NavbarController', ['$scope', function ($scope) {

}]);

abastecimiento.controller('HomeController', ['$scope', function ($scope) {

}]);


// Controller: SolicitudCocinaController
abastecimiento.controller('SolicitudCocinaController', ['$scope', '$routeParams', '$location', 'ProgramacionRutaService', 'RefrigerioService', 'SolicitudCocinaService', function ($scope, $routeParams, $location, $programacionRutaService, $refrigerioService, $solicitudCocinaService) {

    $scope.consultar = {};
    $scope.consultar.solicitudCocina = {};
    $scope.consultar.listado = {};

    $scope.anular = {};
    $scope.anular.solicitudCocina = {};

    $scope.registrar = {};
    $scope.registrar.solicitudCocina = {};
    $scope.registrar.collapse = {};
    $scope.registrar.collapse.programacionRuta = true;
    $scope.registrar.listado = {};
    $scope.registrar.registroCorrecto = false;

    $scope.actualizar = {};
    $scope.actualizar.solicitudCocina = {};
    $scope.actualizar.collapse = {};
    $scope.actualizar.collapse.programacionRuta = true;
    $scope.actualizar.listado = {};
    $scope.actualizar.registroCorrecto = false;



    if (!angular.isUndefined($routeParams.id)) {
        $solicitudCocinaService.getById($routeParams.id)
            .success(function (data) {
                console.log(data);
                $scope.anular.solicitudCocina = data;
                $scope.actualizar.solicitudCocina = data;
            })
            .error(function (data) {
                console.log(data);
            });
    }
      

    $scope.consultar.buscarSolicitudCocinaPorId = function (id) {
        if (angular.isUndefined(id)) {
            alert('Ingrese el Nro. de Solicitud de Cocina');
            return;
        }

        $solicitudCocinaService.getById(id)
            .success(function (data) {
                $scope.consultar.listado.solicitudCocina = [data];
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.consultar.buscarSolicitudCocinaPorRangoFechas = function (fechaSolicitudDesde, fechaSolicitudHasta) {
        
        if ((angular.isUndefined(fechaSolicitudDesde) || fechaSolicitudDesde.trim() == "") || (angular.isUndefined(fechaSolicitudHasta) || fechaSolicitudHasta.trim() == "")) {
            $solicitudCocinaService.getAll()
                .success(function (data) {
                    $scope.consultar.listado.solicitudCocina = data;
                })
                .error(function (data) {
                    console.log(data);
                });
        } else {
            $solicitudCocinaService.getByRangeDate(fechaSolicitudDesde, fechaSolicitudHasta)
                .success(function (data) {
                    $scope.consultar.listado.solicitudCocina = data;
                })
                .error(function (data) {
                    console.log(data);
                });
        }

    }

    $scope.anular.anularSolicitudCocina = function (solicitudCocina) {
        solicitudCocina.estado = 0;

        $solicitudCocinaService.update(solicitudCocina)
            .success(function (data) {
                $location.path('/SolicitudCocina');
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.registrar.buscarProgramacionRuta = function () {
        $scope.registrar.collapse.programacionRuta = !$scope.registrar.collapse.programacionRuta;

        $programacionRutaService.getAll()
            .success(function (data) {
                $scope.registrar.listado.programacionRuta = data;
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.registrar.aceptarBusquedaProgramacionRuta = function () {
        var programacionRuta = $scope.registrar.listado.programacionRuta[$scope.registrar.programacionRutaIndex];
        $scope.registrar.solicitudCocina.programacionRuta = programacionRuta;
        $scope.registrar.cancelarBusquedaProgramacionRuta();
    }
    
    $scope.registrar.cancelarBusquedaProgramacionRuta = function () {
        $scope.registrar.collapse.programacionRuta = !$scope.registrar.collapse.programacionRuta;
    }

    $scope.registrar.grabarSolicitudCocina = function () {
        console.log($scope.registrar.solicitudCocina);

        $solicitudCocinaService.save($scope.registrar.solicitudCocina)
            .success(function () {
                $scope.registrar.registroCorrecto = true;
            })
            .error(function () {
                console.log(data);
                $scope.registrar.registroCorrecto = false;
            })
    }

    $scope.actualizar.buscarProgramacionRuta = function () {
        $scope.actualizar.collapse.programacionRuta = !$scope.actualizar.collapse.programacionRuta;

        $programacionRutaService.getAll()
            .success(function (data) {
                $scope.actualizar.listado.programacionRuta = data;
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.actualizar.aceptarBusquedaProgramacionRuta = function () {
        var programacionRuta = $scope.actualizar.listado.programacionRuta[$scope.actualizar.programacionRutaIndex];
        $scope.actualizar.solicitudCocina.programacionRuta = programacionRuta;
        $scope.actualizar.cancelarBusquedaProgramacionRuta();
    }

    $scope.actualizar.cancelarBusquedaProgramacionRuta = function () {
        $scope.actualizar.collapse.programacionRuta = !$scope.actualizar.collapse.programacionRuta;
    }

    $scope.actualizar.grabarSolicitudCocina = function () {
        console.log($scope.actualizar.solicitudCocina);

        $solicitudCocinaService.update($scope.actualizar.solicitudCocina)
            .success(function () {
                $scope.actualizar.registroCorrecto = true;
            })
            .error(function () {
                console.log(data);
                $scope.actualizar.registroCorrecto = false;
            })
    }


}]);



abastecimiento.controller('SolicitudInsumoController', ['$scope', '$routeParams', '$location', 'SolicitudInsumoService', 'SolicitudCocinaService', 'InsumoService', function ($scope, $routeParams, $location, $solicitudInsumoService, $solicitudCocinaService, $insumoService) {
    
    $scope.consultar = {};
    $scope.consultar.solicitudInsumo = {};
    $scope.consultar.listado = {};

    $scope.anular = {};
    $scope.anular.solicitudInsumo = {};

    $scope.registrar = {};
    $scope.registrar.solicitudInsumo = {};
    $scope.registrar.collapse = {};
    $scope.registrar.collapse.solicitudCocina = true;
    $scope.registrar.listado = {};
    $scope.registrar.registroCorrecto = false;

    $scope.actualizar = {};
    $scope.actualizar.solicitudInsumo = {};
    $scope.actualizar.collapse = {};
    $scope.actualizar.collapse.solicitudCocina = true;
    $scope.actualizar.listado = {};
    $scope.actualizar.registroCorrecto = false;


    $scope.consultar.buscarSolicitudInsumoPorId = function (id) {
        $solicitudInsumoService.getById(id)
            .success(function (data) {
                $scope.consultar.listado.solicitudInsumo = [data];
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.consultar.buscarSolicitudInsumoPorRangoFechas = function (fechaSolicitudDesde, fechaSolicitudHasta) {

        if ((angular.isUndefined(fechaSolicitudDesde) || fechaSolicitudDesde.trim() == "") || (angular.isUndefined(fechaSolicitudHasta) || fechaSolicitudHasta.trim() == "")) {
            $solicitudInsumoService.getAll()
                .success(function (data) {
                    $scope.consultar.listado.solicitudInsumo = data;
                })
                .error(function (data) {
                    console.log(data);
                });
        } else {
            $solicitudCocinaService.getByRangeDate(fechaSolicitudDesde, fechaSolicitudHasta)
                .success(function (data) {
                    $scope.consultar.listado.solicitudInsumo = data;
                })
                .error(function (data) {
                    console.log(data);
                });
        }

    }
    
    if (!angular.isUndefined($routeParams.id)) {
        $solicitudInsumoService.getById($routeParams.id)
            .success(function (data) {
                $scope.anular.solicitudInsumo = data;
                $scope.actualizar.solicitudInsumo = data;
            })
            .error(function (data) {
                console.log(data);
            });
    }


    $scope.anular.anularSolicitudInsumo = function (solicitudInsumo) {
        solicitudInsumo.estado = 0;

        $solicitudInsumoService.update(solicitudInsumo)
            .success(function (data) {
                $location.path('/SolicitudInsumo');
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.registrar.buscarSolicitudCocina = function () {
        $scope.registrar.collapse.solicitudCocina = !$scope.registrar.collapse.solicitudCocina;

        $solicitudCocinaService.getAll()
            .success(function (data) {
                $scope.registrar.listado.solicitudCocina = _.where(data, { estado: 1 });
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.registrar.aceptarBusquedaSolicitudCocina = function () {
        var solicitudCocina = $scope.registrar.listado.solicitudCocina[$scope.registrar.solicitudCocinaIndex];
        $scope.registrar.solicitudInsumo.solicitudCocina = solicitudCocina;
        $scope.registrar.cancelarBusquedaSolicitudCocina();
    }

    $scope.registrar.cancelarBusquedaSolicitudCocina = function () {
        $scope.registrar.collapse.solicitudCocina = !$scope.registrar.collapse.solicitudCocina;
    }

    $scope.registrar.grabarSolicitudInsumo = function () {
        console.log($scope.registrar.solicitudInsumo);

        $solicitudInsumoService.save($scope.registrar.solicitudInsumo)
            .success(function () {
                $scope.registrar.registroCorrecto = true;
            })
            .error(function () {
                console.log(data);
                $scope.registrar.registroCorrecto = false;
            })
    }

    $scope.actualizar.buscarSolicitudCocina = function () {
        $scope.actualizar.collapse.solicitudCocina = !$scope.actualizar.collapse.solicitudCocina;

        $solicitudCocinaService.getAll()
            .success(function (data) {
                $scope.actualizar.listado.solicitudCocina = _.where(data, { estado: 1 });
            })
            .error(function (data) {
                console.log(data);
            });
    }

    $scope.actualizar.aceptarBusquedaSolicitudCocina = function () {
        var solicitudCocina = $scope.actualizar.listado.solicitudCocina[$scope.actualizar.solicitudCocinaIndex];
        $scope.actualizar.solicitudInsumo.solicitudCocina = solicitudCocina;
        $scope.actualizar.cancelarBusquedaSolicitudCocina();
    }

    $scope.actualizar.cancelarBusquedaSolicitudCocina = function () {
        $scope.actualizar.collapse.solicitudCocina = !$scope.actualizar.collapse.solicitudCocina;
    }

    $scope.actualizar.grabarSolicitudInsumo = function () {
        console.log($scope.actualizar.solicitudInsumo);

        $solicitudInsumoService.update($scope.actualizar.solicitudInsumo)
            .success(function () {
                $scope.actualizar.registroCorrecto = true;
            })
            .error(function () {
                console.log(data);
                $scope.actualizar.registroCorrecto = false;
            })
    }

}]);