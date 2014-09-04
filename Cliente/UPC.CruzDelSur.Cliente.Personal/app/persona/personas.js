(function () {
    'use strict';

    var controllerId = 'personas';

    angular.module('app').controller(controllerId,
        ['$location', 'common', 'datacontext', personas]);

    function personas($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.goToPersona = goToPersona;
        vm.personas = [];
        vm.refresh = refresh;
        vm.title = 'Personas';

        activate();

        function activate() {
            common.activateController([getPersonas()], controllerId)
                .then(function () { log('Activated Personas View'); });
        }

        function getPersonas(forceRemote) {
            return datacontext.persona.getAll(forceRemote)
                .then(function(data) {
                    return vm.personas = data;
                });
        }

        function goToPersona(persona) {
            if (persona && persona.id) {
                $location.path('/persona/' + persona.id);
            }
        }

        function refresh() { getPersonas(true); }
    }
})();
