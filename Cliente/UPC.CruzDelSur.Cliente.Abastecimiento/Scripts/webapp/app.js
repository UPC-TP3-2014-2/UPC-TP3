var abastecimiento;

abastecimiento = angular.module("abastecimiento", ["ui.bootstrap", "ngRoute"]);

abastecimiento.config([
  "$routeProvider", function($routeProvider) {
    $routeProvider.when("/", {
      templateUrl: "Scripts/Webapp/Templates/Home.html",
      controller: "HomeController"
    }).when("/SolicitudCocina/Register", {
      templateUrl: "Scripts/Webapp/Templates/SolicitudCocina/Register.html",
      controller: "SolicitudCocinaController"
    }).when("/SolicitudCocina/Search", {
      templateUrl: "Scripts/Webapp/Templates/SolicitudCocina/Search.html",
      controller: "SolicitudCocinaController"
    }).otherwise({
      redirectTo: "/"
    });
  }
]);

abastecimiento.controller("NavbarController", ["$scope", function($scope) {}]);

abastecimiento.controller("HomeController", [
  "$scope", function($scope) {
    $scope.message = "Inicio del Módulo de Abastecimiento";
  }
]);

abastecimiento.controller("SolicitudCocinaController", [
  "$scope", function($scope) {
    $scope.search = {};
    $scope.register = {};
    $scope.register.message = "Hola Mundo desde Solicitud Cocina Controller - Register";
    $scope.search.message = "Hola Mundo desde Solicitud Cocina Controller - Search";
  }
]);
