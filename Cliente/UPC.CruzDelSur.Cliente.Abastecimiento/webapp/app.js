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
    }).when("/SolicitudInsumo/Registrar", {
      templateUrl: "Webapp/Templates/SolicitudInsumo/Registrar.html",
      controller: "SolicitudInsumoController"
    }).when("/SolicitudInsumo/Consultar", {
      templateUrl: "Webapp/Templates/SolicitudInsumo/Consultar.html",
      controller: "SolicitudInsumoController"
    }).when("/SolicitudInsumo/Anular/:id", {
      templateUrl: "Webapp/Templates/SolicitudInsumo/Anular.html",
      controller: "SolicitudInsumoController"
    }).when("/GuiaSalidaInsumo/Registrar", {
      templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Registrar.html",
      controller: "GuiaSalidaInsumoController"
    }).when("/GuiaSalidaInsumo/Consultar", {
      templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Consultar.html",
      controller: "GuiaSalidaInsumoController"
    }).when("/GuiaSalidaInsumo/Anular/:id", {
      templateUrl: "Webapp/Templates/GuiaSalidaInsumo/Anular.html",
      controller: "GuiaSalidaInsumoController"
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

abastecimiento.factory("GuiaSalidaInsumoService", [
  "$http", function($http) {
    return {
      getAll: function() {
        return $http.get("api/GuiaSalidaInsumo");
      },
      getById: function(id) {
        return $http.get("api/GuiaSalidaInsumo/" + id);
      },
      getByDateRange: function(fechaInicial, fechaFinal) {
        return $http.get("api/GuiaSalidaInsumo?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal);
      },
      save: function(guiaSalidaInsumo) {
        return $http.post("api/GuiaSalidaInsumo", guiaSalidaInsumo);
      },
      update: function(guiaSalidaInsumo) {
        return $http.put("api/GuiaSalidaInsumo", guiaSalidaInsumo);
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

abastecimiento.controller("NavbarController", ["$scope", function($scope) {}]);

abastecimiento.controller("HomeController", [
  "$scope", function($scope) {
    $scope.message = "Ventana de inicio del módulo de Abastecimiento.";
  }
]);

abastecimiento.controller("SolicitudCocinaController", [
  "$scope", "$routeParams", "$location", "SolicitudCocinaService", "ProgramacionRutaService", "RefrigerioService", function($scope, $routeParams, $location, $solicitudCocinaService, $programacionRutaService, $refrigerioService) {
    $scope.consultar = {};
    $scope.anular = {};
    $scope.registrar = {};
    $scope.registrar.solicitudCocina = {};
    $scope.registrar.registrado = false;
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
      if ((angular.isUndefined(fechaInicial) || fechaInicial.trim() === "") || (angular.isUndefined(fechaFinal) || fechaFinal.trim() === "")) {
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
    $refrigerioService.getAll().success(function(data) {
      $scope.registrar.listadoRefrigerios = data;
    });
    $scope.registrar.buscarProgramacionRuta = function(fechaInicialOrigen, fechaFinalOrigen) {
      if ((angular.isUndefined(fechaInicialOrigen) || fechaInicialOrigen.trim() === "") || (angular.isUndefined(fechaFinalOrigen) || fechaFinalOrigen.trim() === "")) {
        $programacionRutaService.getAll().success(function(data) {
          $scope.registrar.listadoProgramacionRuta = data;
        });
      } else {
        $programacionRutaService.getByDateRange(fechaInicialOrigen, fechaFinalOrigen).success(function(data) {
          $scope.registrar.listadoProgramacionRuta = data;
        });
      }
    };
    $scope.registrar.cancelarBusquedaProgramacionRuta = function() {
      $scope.registrar.listadoProgramacionRuta = [];
    };
    $scope.registrar.seleccionarProgramacionRuta = function(programacionRuta) {
      $scope.registrar.solicitudCocina.programacionRuta = programacionRuta;
      $scope.registrar.cancelarBusquedaProgramacionRuta();
    };
    $scope.registrar.registrarSolicitud = function(solicitudCocina) {
      solicitudCocina.id = 0;
      solicitudCocina.estado = 1;
      $solicitudCocinaService.save(solicitudCocina).success(function(data) {
        $scope.registrar.registrado = true;
      });
    };
    $scope.registrar.seleccionarRefrigerio = function(refrigerio) {
      console.log(refrigerio);
    };
  }
]);

abastecimiento.controller("SolicitudInsumoController", [
  "$scope", "$routeParams", "$location", "SolicitudInsumoService", "SolicitudCocinaService", "InsumoService", function($scope, $routeParams, $location, $solicitudInsumoService, $solicitudCocinaService, $insumoService) {
    $scope.consultar = {};
    $scope.anular = {};
    $scope.registrar = {};
    $scope.registrar.solicitudInsumo = {};
    $scope.registrar.registrado = false;
    if (!angular.isUndefined($routeParams.id)) {
      $solicitudInsumoService.getById($routeParams.id).success(function(data) {
        $scope.anular.solicitudInsumo = data;
      });
    }
    $scope.consultar.buscarPorId = function(id) {
      if (angular.isUndefined(id)) {
        $solicitudInsumoService.getAll().success(function(data) {
          $scope.consultar.listadoSolicitudesInsumo = data;
        });
      } else {
        $solicitudInsumoService.getById(id).success(function(data) {
          $scope.consultar.listadoSolicitudesInsumo = [data];
        });
      }
    };
    $scope.consultar.buscarPorRangoFechas = function(fechaInicial, fechaFinal) {
      if ((angular.isUndefined(fechaInicial) || fechaInicial.trim() === "") || (angular.isUndefined(fechaFinal) || fechaFinal.trim() === "")) {
        $solicitudInsumoService.getAll().success(function(data) {
          $scope.consultar.listadoSolicitudesInsumo = data;
        });
      } else {
        $solicitudInsumoService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
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
    $insumoService.getAll().success(function(data) {
      $scope.registrar.listadoInsumos = data;
    });
    $scope.registrar.buscarSolicitudCocina = function(fechaInicial, fechaFinal) {
      if ((angular.isUndefined(fechaInicial) || fechaInicial.trim() === "") || (angular.isUndefined(fechaFinal) || fechaFinal.trim() === "")) {
        $solicitudCocinaService.getAll().success(function(data) {
          $scope.registrar.listadoSolicitudCocina = _.where(data, {
            estado: 1
          });
        });
      } else {
        $solicitudCocinaService.getByDateRange(fechaInicial, fechaFinal).success(function(data) {
          $scope.registrar.listadoSolicitudCocina = _.where(data, {
            estado: 1
          });
        });
      }
    };
    $scope.registrar.cancelarBusquedaSolicitudCocina = function() {
      $scope.registrar.listadoSolicitudCocina = [];
    };
    $scope.registrar.seleccionarSolicitudCocina = function(solicitudCocina) {
      $scope.registrar.solicitudInsumo.solicitudCocina = solicitudCocina;
    };
    $scope.registrar.registrarSolicitud = function(solicitudInsumo) {
      solicitudInsumo.id = 0;
      solicitudInsumo.estado = 0;
      $solicitudInsumoService.save(solicitudInsumo).success(function(data) {
        $scope.registrar.registrado = true;
      });
    };
  }
]);

abastecimiento.controller("GuiaSalidaInsumoController", [
  "$scope", "$routeParams", "$location", "GuiaSalidaInsumoService", "SolicitudInsumoService", function($scope, $routeParams, $location, $guiaSalidaInsumoService, $solicitudInsumoService) {
    $scope.consultar = {};
    $scope.anular = {};
    $scope.registrar = {};
    $scope.registrar.guiaSalidaInsumo = {};
    $scope.registrar.registrado = false;
    if (!angular.isUndefined($routeParams.id)) {
      $guiaSalidaInsumoService.getById($routeParams.id).success(function(data) {
        $scope.anular.guiaSalidaInsumo = data;
      });
    }
    $scope.consultar.buscarPorId = function(id) {
      if (angular.isUndefined(id)) {
        $guiaSalidaInsumoService.getAll().success(function(data) {
          $scope.consultar.listadoGuiaSalidaInsumo = data;
        });
      } else {
        $guiaSalidaInsumoService.getById(id).success(function(data) {
          $scope.consultar.listadoGuiaSalidaInsumo = [data];
        });
      }
    };
    $scope.consultar.buscarPorRangoFechas = function(fechaInicial, fechaFinal) {
      if ((angular.isUndefined(fechaInicial) || fechaInicial.trim() === "") || (angular.isUndefined(fechaFinal) || fechaFinal.trim() === "")) {
        $guiaSalidaInsumoService.getAll().success(function(data) {
          $scope.consultar.listadoGuiaSalidaInsumo = data;
        });
      } else {
        $solicitudInsumoService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
          $scope.consultar.listadoGuiaSalidaInsumo = data;
        });
      }
    };
    $scope.anular.anularGuiaSalidaInsumo = function(guiaSalidaInsumo) {
      guiaSalidaInsumo.estado = 0;
      $guiaSalidaInsumoService.update(guiaSalidaInsumo).success(function(data) {
        $location.path("/GuiaSalidaInsumo/Consultar");
      });
    };
    $scope.registrar.buscarSolicitudInsumo = function(fechaInicial, fechaFinal) {
      if ((angular.isUndefined(fechaInicial) || fechaInicial.trim() === "") || (angular.isUndefined(fechaFinal) || fechaFinal.trim() === "")) {
        $solicitudInsumoService.getAll().success(function(data) {
          $scope.registrar.listadoSolicitudInsumo = _.where(data, {
            estado: 1
          });
        });
      } else {
        $solicitudInsumoService.getByRangeDate(fechaInicial, fechaFinal).success(function(data) {
          $scope.registrar.listadoSolicitudInsumo = _.where(data, {
            estado: 1
          });
        });
      }
    };
    $scope.registrar.cancelarBusquedaSolicitudInsumo = function() {
      $scope.registrar.listadoSolicitudInsumo = [];
    };
    $scope.registrar.seleccionarSolicitudInsumo = function(solicitudInsumo) {
      $scope.registrar.guiaSalidaInsumo.solicitudInsumo = solicitudInsumo;
    };
    $scope.registrar.registrarGuiaSalidaInsumo = function(guiaSalidaInsumo) {
      guiaSalidaInsumo.id = 0;
      guiaSalidaInsumo.estado = 0;
      $guiaSalidaInsumoService.save(guiaSalidaInsumo).success(function(data) {
        $scope.registrar.registrado = true;
      });
    };
  }
]);
