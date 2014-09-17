var abastecimiento = angular.module('abastecimiento', ['ui.bootstrap', 'ngRoute']);


// Routing
abastecimiento.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider
        .when('/', {
            templateUrl: 'Scripts/webapp/template/home.html',
            controller: 'HomeController'
        })
        .when('/SolicitudCocina', {
            templateUrl: 'Scripts/webapp/template/consultar_solicitud_cocina.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudCocina/Register', {
            templateUrl: 'Scripts/webapp/template/actualizar_solicitud_cocina.html',
            controller: 'SolicitudCocinaController'
        })
    ;

}]);



// Services
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

abastecimiento.factory('SolicitudCocinaService', ['$http', function ($http) {
    return {
        getAll: function () { return $http.get('/api/SolicitudCocina'); },
        getById: function (id) { return $http.get('/api/SolicitudCocina/' + id); },
        save: function (data) { return $http.post('/api/SolicitudCocina/', data, { headers: { 'Content-Type': 'application/json' } }); }
    };
}]);









// controllers
abastecimiento.controller('NavbarController', ['$scope', function ($scope) {
    $scope.message = "Hola Mundo desde el home";


}]);

abastecimiento.controller('HomeController', ['$scope', function ($scope) {
    $scope.message = "Hola Mundo desde el home";


}]);


// Controller: SolicitudCocinaController
abastecimiento.controller('SolicitudCocinaController', ['$scope', 'ProgramacionRutaService', 'RefrigerioService', 'SolicitudCocinaService', function ($scope, $programacionRutaService, $refrigerioService, $solicitudCocinaService) {

    // busqueda.listado.solicitudCocina

    $scope.buscarSolicitudCocinaPorId = function (id) {

        console.log(id);
    }


    $scope.buscarSolicitudCocinaPorRangoFechas = function (fechaSolicitudDesde, fechaSolicitudHasta) {

        $solicitudCocinaService.getAll()
            .success(function (data) {
                console.log(data);
            })
            .error(function (data) {
                console.log('Error: ');
                console.log(data);
            });


        console.log(fechaSolicitudDesde);
        console.log(fechaSolicitudHasta);
    }





    $scope.alert = {
        register: {
            show: false
        }
    };

    $scope.collapse = {
        programacionRuta: true,
        refrigerio: true
    };

    $scope.listado = {
        programacionRuta: [],
        refrigerio: []
    };

    $scope.solicitudCocina = {
        id: 0, 
        details: []
    };


    $scope.buscarProgramacionRuta = function () {
        $scope.collapse.programacionRuta = !$scope.collapse.programacionRuta;
        
        $programacionRutaService.getAll().success(function (data) {
            $scope.listado.programacionRuta = data;
        }).error(function (data) {
            alert('Ha ocurrido un error');
            console.log(data);
        });
    }

    $scope.aceptarBusquedaProgramacionRuta = function () {
        $scope.collapse.programacionRuta = true;
        $scope.solicitudCocina.programacionRuta = $scope.listado.programacionRuta[$scope.programacionRutaIndex];
    }

    $scope.cancelarBusquedaProgramacionRuta = function () {
        $scope.collapse.programacionRuta = true;
    }
    
    $scope.buscarRefrigerio = function () {
        $scope.collapse.refrigerio = !$scope.collapse.refrigerio;

        $refrigerioService.getAll().success(function (data) {
            $scope.listado.refrigerio = data;
        }).error(function (data) {
            alert('Ha ocurrido un error');
            console.log(data);
        });
    }

    $scope.aceptarBusquedaRefrigerio = function () {
        $scope.collapse.refrigerio = true;
        console.log($scope);
    }


    $scope.registrarSolicitudCocina = function () {

        $solicitudCocinaService.save(JSON.stringify($scope.solicitudCocina))
            .success(function (data) {
                console.log(data);
            }).error(function (data) {
                alert("Ha ocurrido un error.");
                console.log(data);
            });
    }



}]);