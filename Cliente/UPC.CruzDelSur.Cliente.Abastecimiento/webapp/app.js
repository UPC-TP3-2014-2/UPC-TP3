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
    }).when("/SolicitudInsumo/Consultar", {
      templateUrl: "Webapp/Templates/SolicitudInsumo/Consultar.html",
      controller: "SolicitudInsumoController"
    }).when("/SolicitudInsumo/Anular/:id", {
      templateUrl: "Webapp/Templates/SolicitudInsumo/Anular.html",
      controller: "SolicitudInsumoController"
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

abastecimiento.factory("SolicitudInsumoService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/SolicitudInsumo");
      },
      getById: function(id) {
        return $http.get("api/SolicitudInsumo/" + id);
      },
      getByRangeDate: function(fechaInicial, fechaFinal) {
        return $http.get("api/SolicitudInsumo?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal);
      },
      save: function(solicitudInsumo) {
        return $http.post("api/SolicitudInsumo", solicitudInsumo);
      },
      update: function(solicitudInsumo) {
        return $http.put("api/SolicitudInsumo", solicitudInsumo);
      }
    };
  }
]);

abastecimiento.factory("ProgramacionRutaService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/ProgramacionRuta");
      },
      getById: function(id) {
        return $http.get("api/ProgramacionRuta/" + id);
      },
      getByDateRange: function(fechaInicial, fechaFinal) {
        return $http.get("api/ProgramacionRuta?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal);
      }
    };
  }
]);

abastecimiento.factory("RefrigerioService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/Refrigerio");
      },
      getById: function(id) {
        return $http.get("api/Refrigerio/" + id);
      }
    };
  }
]);

abastecimiento.factory("InsumoService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/Insumo");
      },
      getById: function(id) {
        return $http.get("api/Insumo/" + id);
      }
    };
  }
]);


/*
abastecimiento.directive "dateGreatherThan", ["$filter", ($filter) ->
    {
        require: "ngModel"
        link: (scope, elm, attrs, ctrl) ->
            var validateDateRange = (inputValue) ->
                fromDate = $filter("date")(attrs.dateGreaterThan, "short")
                toDate = $filter("date")(inputValue, "short")
                ctrl.$setValidity('dateGreaterThan', isValid);
                inputValue;
            return
    }
]

return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {            
            var validateDateRange = function (inputValue) {
                var fromDate = $filter('date')(attrs.dateGreaterThan, 'short');
                var toDate = $filter('date')(inputValue, 'short');
                var isValid = isValidDateRange(fromDate, toDate);
                ctrl.$setValidity('dateGreaterThan', isValid);
                return inputValue;
            };

            ctrl.$parsers.unshift(validateDateRange);
            ctrl.$formatters.push(validateDateRange);
            attrs.$observe('dateGreaterThan', function () {
                validateDateRange(ctrl.$viewValue);

            });
        }
    };
 */

abastecimiento.controller("NavbarController", ["$scope", function($scope) {}]);

abastecimiento.controller("HomeController", [
  "$scope", function($scope) {
    $scope.message = "Ventana de inicio del módulo de Abastecimiento.";
  }
]);

abastecimiento.controller("SolicitudCocinaController", [
  "$scope", "$routeParams", "$location", "SolicitudCocinaService", "ProgramacionRutaService", "InsumoService", function($scope, $routeParams, $location, $solicitudCocinaService, $programacionRutaService, $insumoService) {
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
        $solicitudCocinaService.getAll().success(function(data) {
          $scope.consultar.listadoSolicitudesCocina = data;
        });
      } else {
        $solicitudCocinaService.getById(id).success(function(data) {
          $scope.consultar.listadoSolicitudesCocina = [data];
        });
      }
    };
    $scope.consultar.buscarPorRangoFechas = function(fechaInicial, fechaFinal) {
      if (angular.isUndefined(fechaInicial) || angular.isUndefined(fechaFinal)) {
        $solicitudCocinaService.getAll().success(function(data) {
          $scope.consultar.listadoSolicitudesCocina = data;
        });
      } else {
        $solicitudCocinaService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
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
    $scope.registrar.buscarProgramacionRuta = function(fechaInicialOrigen, fechaFinalOrigen) {
      if (angular.isUndefined(fechaInicialOrigen) || angular.isUndefined(fechaFinalOrigen)) {
        $programacionRutaService.getAll().success(function(data) {
          $scope.registrar.listadoProgramacionRuta = data;
        });
      } else {
        $programacionRutaService.getByDateRange(fechaInicialOrigen, fechaFinalOrigen).success(function(data) {
          $scope.registrar.listadoProgramacionRuta = data;
        });
      }
    };
  }
]);

abastecimiento.controller("SolicitudInsumoController", [
  "$scope", "$routeParams", "$location", "SolicitudInsumoService", function($scope, $routeParams, $location, $solicitudInsumoService) {
    $scope.consultar = {};
    $scope.anular = {};
    $scope.registrar = {};
    $scope.registrar.message = "Hola Mundo desde Solicitud Insumo Controller - Registrar.";
    if (!angular.isUndefined($routeParams.id)) {
      $solicitudInsumoService.getById($routeParams.id).success(function(data) {
        $scope.anular.solicitudInsumo = data;
      });
    }
    $scope.consultar.buscarPorId = function(id) {
      if (angular.isUndefined(id)) {
        console.log("El id es indefinido");
      } else {
        $solicitudInsumoService.getById(id).success(function(data) {
          console.log("Búsqueda por id: " + id);
          $scope.consultar.listadoSolicitudesInsumo = [data];
        });
      }
    };
    $scope.consultar.buscarPorRangoFechas = function(fechaInicial, fechaFinal) {
      if (angular.isUndefined(fechaInicial)) {
        console.log("No se ha ingreso la fecha inicial.");
      } else if (angular.isUndefined(fechaFinal)) {
        console.log("No se ha ingreso la fecha final.");
      } else {
        $solicitudInsumoService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
          console.log("Búsqueda por fechas: " + fechaInicial + " - " + fechaFinal);
          $scope.consultar.listadoSolicitudesInsumo = data;
        });
      }
    };
    $scope.anular.anularSolicitud = function(solicitudInsumo) {
      solicitudInsumo.estado = 0;
      $solicitudInsumoService.update(solicitudInsumo).success(function(data) {
        $location.path("/SolicitudInsumo/Consultar");
      });
    };
  }
]);
