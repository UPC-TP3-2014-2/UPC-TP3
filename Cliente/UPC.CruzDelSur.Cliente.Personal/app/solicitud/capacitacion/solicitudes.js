(function () {
    'use strict';

    var controllerId = 'solicitudes';

    angular.module('app').controller(controllerId,
        ['$location', 'common', 'datacontext', solicitudes]);

    function solicitudes($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.goToSolicitudCapacitacion = goToSolicitudCapacitacion;
        vm.solicitudesCapacitacion = [];
        vm.solicitudesCapacitacionArchivadas = [];
        vm.refresh = refresh;
        vm.title = 'Solicitudes';

        activate();

        function activate() {
            common.activateController([getSolicitudesCapacitacion(), getSolicitudesCapacitacionArchivadas()], controllerId)
                .then(function () { log('Activated Solicitudes View'); });
        }

        function getSolicitudesCapacitacion(forceRemote) {
            return datacontext.solicitudCapacitacion.getAll(forceRemote)
                .then(function(data) {
                    return vm.solicitudesCapacitacion = data;
                });
        }

        function getSolicitudesCapacitacionArchivadas(forceRemote) {
            return datacontext.solicitudCapacitacion.getAll(forceRemote, true)
                .then(function (data) {
                    return vm.solicitudesCapacitacionArchivadas = data;
                });
        }

        function goToSolicitudCapacitacion(solicitudCapacitacion) {
            if (solicitudCapacitacion && solicitudCapacitacion.id) {
                $location.path('/solicitud/capacitacion/' + solicitudCapacitacion.id);
            }
        }

        function refresh() {
             getSolicitudesCapacitacion(true);
             getSolicitudesCapacitacionArchivadas(true);
        }
    }
})();
