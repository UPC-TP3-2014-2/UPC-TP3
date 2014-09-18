(function () {
    'use strict';

    var controllerId = 'solicitudespersonal';

    angular.module('app').controller(controllerId,
        ['$location', 'common', 'datacontext', solicitudespersonal]);

    function solicitudespersonal($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.goToSolicitudPersonal = goToSolicitudPersonal;
        vm.solicitudesPersonal = [];
        vm.solicitudesPersonalArchivadas = [];
        vm.refresh = refresh;
        vm.title = 'Solicitudes de Personal';

        activate();

        function activate() {
            common.activateController([getSolicitudesPersonal(), getSolicitudesPersonalArchivadas()], controllerId)
                .then(function () { log('Activated ' + vm.title); });
        }

        function getSolicitudesPersonal(forceRemote) {
            return datacontext.solicitudPersonal.getAll(forceRemote)
                .then(function(data) {
                    return vm.solicitudesPersonal = data;
                });
        }

        function getSolicitudesPersonalArchivadas(forceRemote) {
            return datacontext.solicitudPersonal.getAll(forceRemote, true)
                .then(function (data) {
                    return vm.solicitudesPersonalArchivadas = data;
                });
        }

        function goToSolicitudPersonal(solicitudPersonal) {
            if (solicitudPersonal && solicitudPersonal.id) {
                $location.path('/solicitud/personal/' + solicitudPersonal.id);
            }
        }

        function refresh() {
             getSolicitudesPersonal(true);
             getSolicitudesPersonalArchivadas(true);
        }
    }
})();
