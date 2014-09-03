(function () {
    'use strict';

    var controllerId = 'tecnicos';

    angular.module('app').controller(controllerId,
        ['$location', 'common', 'datacontext', tecnicos]);

    function tecnicos($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.goToTecnico = goToTecnico;
        vm.tecnicos = [];
        vm.refresh = refresh;
        vm.title = 'Tecnicos';

        activate();

        function activate() {
            common.activateController([getTecnicos()], controllerId)
                .then(function () { log('Activated Tecnicos View'); });
        }

        function getTecnicos(forceRemote) {
            return datacontext.tecnico.getAll(forceRemote)
                .then(function(data) {
                    return vm.tecnicos = data;
                });
        }

        function goToTecnico(tecnico) {
            if (tecnico && tecnico.id) {
                $location.path('/tecnico/' + tecnico.id);
            }
        }

        function refresh() { getTecnicos(true); }
    }
})();
