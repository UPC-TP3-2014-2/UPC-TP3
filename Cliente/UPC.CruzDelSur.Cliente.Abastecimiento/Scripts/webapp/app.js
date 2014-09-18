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
        .when('/SolicitudInsumo', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/consultar.html',
            controller: 'SolicitudInsumoController'
        })
        .when('/SolicitudInsumo/Register', {
            templateUrl: 'Scripts/webapp/template/solicitud-insumo/registrar.html',
            controller: 'SolicitudInsumoController'
        })
        ;

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


    if (!angular.isUndefined($routeParams.id)) {
        $solicitudCocinaService.getById($routeParams.id)
            .success(function (data) {
                console.log(data);
                $scope.anular.solicitudCocina = data;
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


















}]);



abastecimiento.controller('SolicitudInsumoController', ['$scope', 'SolicitudInsumoService', 'SolicitudCocinaService', 'InsumoService', function ($scope, $solicitudInsumoService, $solicitudCocinaService, $insumoService) {
    
    $scope.consultar = {};
    $scope.consultar.solicitudInsumo = {};
    $scope.consultar.listado = {};

    $scope.registrar = {};
    $scope.registrar.solicitudInsumo = {};
    $scope.registrar.detSolicitudInsumo = [];
    $scope.registrar.collapse = {};
    $scope.registrar.listado = {};
    $scope.registrar.collapse.solicitudCocina = true;

    $scope.consultar.buscarSolicitudInsumoPorId = function (id) {
        $solicitudInsumoService.getById(id)
            .success(function (data) {
                $scope.consultar.listado.solicitudInsumo = [data];
            })
            .error(function (data) {
                console.log('ERROR:');
                console.log(data);
            });
    }

    $scope.consultar.buscarSolicitudInsumoPorRangoFechas = function (fechaSolicitudDesde, fechaSolicitudHasta) {

        $solicitudInsumoService.getAll()
            .success(function (data) {
                $scope.consultar.listado.solicitudInsumo = data;
            })
            .error(function (data) {
                console.log('Error: ');
                console.log(data);
            });
    }

    $scope.consultar.anularSolicitudInsumo = function (key) {
        var solicitudInsumo = angular.copy($scope.consultar.listado.solicitudInsumo[key]);
        var result = confirm('¿Está seguro de anular la Solicitud de Insumo ' + solicitudInsumo.id);

        if (result) {
            solicitudInsumo.estado = 0;

            $solicitudInsumoService.update(solicitudInsumo)
                .success(function (data) {
                    $scope.consultar.listado.solicitudInsumo[key] = solicitudInsumo;
                })
                .error(function (data) {
                    console.log(data);
                });
        }
    }

    //$scope.registrar.buscarInsumos = function () {
    //    //return $insumoService.getAll().then(function (data) {
    //    //    return data;
    //    //})
    //    return [
    //{
    //    "id": 1,
    //    "descripcion": "Insumo 1",
    //    "tipoUnidad": "Tipo Unidad 1",
    //    "fechaVencimiento": "2014-09-17T04:43:00"
    //},
    //{
    //    "id": 2,
    //    "descripcion": "Insumo 2",
    //    "tipoUnidad": "Tipo Unidad 2",
    //    "fechaVencimiento": "2014-09-16T04:43:00"
    //},
    //{
    //    "id": 3,
    //    "descripcion": "Insumo 3",
    //    "tipoUnidad": "Tipo Unidad 3",
    //    "fechaVencimiento": "2014-09-15T04:43:00"
    //},
    //{
    //    "id": 4,
    //    "descripcion": "Insumo 4",
    //    "tipoUnidad": "Tipo Unidad 4",
    //    "fechaVencimiento": "2014-09-14T04:43:00"
    //},
    //{
    //    "id": 5,
    //    "descripcion": "Insumo 5",
    //    "tipoUnidad": "Tipo Unidad 5",
    //    "fechaVencimiento": "2014-09-13T04:43:00"
    //}
    //    ];
    //}

    //$scope.registrar.buscarSolicitudCocina = function () {
    //    $scope.registrar.collapse.solicitudCocina = !$scope.registrar.collapse.solicitudCocina;

    //    $solicitudCocinaService.getAll()
    //        .success(function (data) {
    //            $scope.registrar.listado.solicitudCocina = data;
    //        })
    //        .error(function (data) {
    //            console.log(data);
    //        });
    //}

    //$scope.registrar.aceptarBusquedaSolicitudCocina = function () {
    //    $scope.registrar.collapse.solicitudCocina = !$scope.registrar.collapse.solicitudCocina;
    //    $scope.registrar.solicitudInsumo.solicitudCocina = $scope.registrar.listado.solicitudCocina[$scope.registrar.solicitudCocinaIndex];
    //}

    //$scope.registrar.cancelarBusquedaSolicitudCocina = function () {
    //    $scope.registrar.collapse.solicitudCocina = !$scope.registrar.collapse.solicitudCocina;
    //}


    //$scope.registrar.agregarInsumo = function (insumo) {
    //    $scope.registrar.detSolicitudInsumo.push({
    //        id: 0,
    //        solicitudInsumo: $scope.registrar.solicitudInsumo,
    //        insumo: insumo,
    //        cantidad: 0,
    //        unidad: insumo.tipoUnidad
    //    });

    //    $scope.registrar.insumoSeleccionado = null;
    //}

    //$scope.registrar.quitarInsumo = function (key) {
    //    var insumo = $scope.registrar.detSolicitudInsumo[key];
    //    $scope.registrar.detSolicitudInsumo = _.without($scope.registrar.detSolicitudInsumo, insumo);
    //}


    //$scope.registrar.grabarSolicitudInsumo = function (solicitudInsumo) {
    //    console.log(solicitudInsumo);
    //    console.log($scope.registrar.detSolicitudInsumo);

    //    //$solicitudInsumoService.save(solicitudInsumo)
    //    //    .success(function (data) {
    //    //        console.log('Todo ok');
    //    //    })
    //    //    .error(function (data) {
    //    //        console.log('Todo error');
    //    //    });
    //}

}]);