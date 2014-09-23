var abastecimiento;

abastecimiento = angular.module("abastecimiento", ["ui.bootstrap", "ngRoute"]);

abastecimiento.config([
  "$routeProvider", function($routeProvider) {
    $routeProvider.when("/", {
      templateUrl: "Webapp/Templates/Home.html",
      controller: "HomeController"
    }).when("/SolicitudCocina/Registrar", {
      templateUrl: "Webapp/Templates/SolicitudCocina/Registrar.html",
      controller: "SolicitudCocinaController"
    }).when("/SolicitudCocina/Consultar", {
      templateUrl: "Webapp/Templates/SolicitudCocina/Consultar.html",
      controller: "SolicitudCocinaController"
    }).when("/SolicitudCocina/Anular/:id", {
      templateUrl: "Webapp/Templates/SolicitudCocina/Anular.html",
      controller: "SolicitudCocinaController"
    }).otherwise({
      redirectTo: "/"
    });
  }
]);

abastecimiento.factory("SolicitudCocinaService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/SolicitudCocina");
      },
      getById: function(id) {
        return $http.get("api/SolicitudCocina/" + id);
      },
      getByRangeDate: function(fechaInicial, fechaFinal) {
        return $http.get("api/SolicitudCocina?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal);
      },
      save: function(solicitudCocina) {
        return $http.post("api/SolicitudCocina", solicitudCocina);
      },
      update: function(solicitudCocina) {
        return $http.put("api/SolicitudCocina", solicitudCocina);
      }
    };
  }
]);

abastecimiento.controller("NavbarController", ["$scope", function($scope) {}]);

abastecimiento.controller("HomeController", ["$scope", function($scope) {}]);

abastecimiento.controller("SolicitudCocinaController", [
  "$scope", "$routeParams", "$location", "SolicitudCocinaService", function($scope, $routeParams, $location, $solicitudCocinaService) {
    $scope.consultar = {};
    $scope.anular = {};
    $scope.registrar = {};
    $scope.registrar.message = "Hola Mundo desde Solicitud Cocina Controller - Register";
    if (!angular.isUndefined($routeParams.id)) {
      $solicitudCocinaService.getById($routeParams.id).success(function(data) {
        $scope.anular.solicitudCocina = data;
      });
    }
    $scope.consultar.buscarPorId = function(id) {
      if (angular.isUndefined(id)) {
        console.log("El id es indefinido");
      } else {
        $solicitudCocinaService.getById(id).success(function(data) {
          console.log("Búsqueda por id: " + id);
          $scope.consultar.listadoSolicitudesCocina = [data];
        });
      }
    };
    $scope.consultar.buscarPorRangoFechas = function(fechaInicial, fechaFinal) {
      if (angular.isUndefined(fechaInicial)) {
        console.log("No se ha ingresado la fecha inicial.");
      } else if (angular.isUndefined(fechaFinal)) {
        console.log("No se ha ingresado la fecha final.");
      } else {
        $solicitudCocinaService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
          console.log("Búsqueda por fechas: " + fechaInicial + " - " + fechaFinal);
          $scope.consultar.listadoSolicitudesCocina = data;
        });
      }
    };
    $scope.anular.anularSolicitud = function(solicitudCocina) {
      solicitudCocina.estado = 0;
      $solicitudCocinaService.update(solicitudCocina).success(function(data) {
        $location.path("/SolicitudCocina/Consultar");
      });
    };
  }
]);
