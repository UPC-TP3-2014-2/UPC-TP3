var abastecimiento = angular.module('abastecimiento', ['ui.bootstrap', 'ngRoute']);


// routing
abastecimiento.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider
        .when('/', {
            templateUrl: 'Scripts/Webapp/Templates/Home.html',
            controller: 'HomeController'
        })
        .when('/SolicitudCocina', {
            templateUrl: 'Scripts/Webapp/Templates/ConsultarSolicitudCocina.html',
            controller: 'SolicitudCocinaController'
        })
        .when('/SolicitudCocina/Register', {
            templateUrl: 'Scripts/Webapp/Templates/RegistrarSolicitudCocina.html',
            controller: 'SolicitudCocinaController'
        });

}]);





// controllers
abastecimiento.controller('NavbarController', ['$scope', function ($scope) {
    $scope.message = "Hola Mundo desde el home";


}]);

abastecimiento.controller('HomeController', ['$scope', function ($scope) {
    $scope.message = "Hola Mundo desde el home";


}]);

abastecimiento.controller('SolicitudCocinaController', ['$scope', '$http', function ($scope, $http) {
    $scope.buscarPorRangoFechas = function (fechaDesde, fechaHasta) {
        $scope.nroSolicitud = "";

        $http.get('/api/SolicitudCocina')
            .success(function (data, status, headers, config) {
                $scope.solicitudesCocina = data;
                console.log(data);
            })
            .error(function (data, status, headers, config) {
                console.log('Error');
            });
    }

    $scope.buscarPorNroSolicitud = function (nroSolicitud) {
        $scope.fechaDesde = "";
        $scope.fechaHasta = "";

        $http.get('/api/SolicitudCocina/' + nroSolicitud)
            .success(function (data, status, headers, config) {
                $scope.solicitudesCocina = [data];
                console.log([data]);
            })
            .error(function (data, status, headers, config) {
                console.log('Error');
            });
    }


}]);