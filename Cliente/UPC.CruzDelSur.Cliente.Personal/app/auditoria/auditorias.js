(function () {
    'use strict';

    var controllerId = 'auditorias';

    angular.module('app').controller(controllerId,
        ['$location', 'common', 'datacontext', auditorias]);

    function auditorias($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.auditorias = [];
        vm.refresh = refresh;
        vm.title = 'Auditoria';

        activate();

        function activate() {
            common.activateController([getAuditorias()], controllerId)
                .then(function () { log('Activated Auditorias View'); });
        }

        function getAuditorias(forceRemote) {
            return datacontext.auditoria.getAll(forceRemote)
                .then(function(data) {
                    return vm.auditorias = data;
                });
        }

        function refresh() { getAuditorias(true); }
    }
})();
