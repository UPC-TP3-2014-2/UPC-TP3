(function () {
    'use strict';

    var controllerId = 'cargodesempenadodetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog', 'common', 'config', 'datacontext',
            cargodesempenadodetalle]);

    function cargodesempenadodetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.areas = [];
        vm.cancel = cancel;
        vm.desdeDatePickerOpened = false;
        vm.hastaDatePickerOpened = false;
        vm.deleteCargoDesempenado = deleteCargoDesempenado;
        vm.goBack = goBack;
        vm.goToPersona = goToPersona;
        vm.hasChanges = false;
        vm.isSaving = false;
        vm.cargoDesempenado = undefined;
        vm.cargoDesempenadoIdParameter = $routeParams.idCargoDesempenado;
        vm.desdeOpenDatePicker = desdeOpenDatePicker;
        vm.hastaOpenDatePicker = hastaOpenDatePicker;
        vm.personaIdParameter = $routeParams.idPersona;
        vm.save = save;
        vm.title = 'cargodesempenadodetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        function canSave() { return vm.hasChanges && !vm.isSaving; }

        activate();

        function activate() {
            initLookups();
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedCargoDesempenado()], controllerId);
        }

        function cancel() {
            datacontext.cancel();
            if (vm.cargoDesempenado.entityAspect.entityState.isDetached()) {
                goToPersona();
            }
        }

        function deleteCargoDesempenado() {
            return bsDialog.deleteDialog(
                    '¿Desea eliminar este Cargo Desempeñado?',
                    'Confirmar Eliminación',
                    'Eliminar')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.cargoDesempenado);
                vm.save().then(success, failed);

                function success() { goToPersona(); }

                function failed(error) { cancel(); }
            }
        }

        function goToPersona() {
            if (vm.cargoDesempenado && vm.cargoDesempenado.personaId) {
                $location.path('/persona/' + vm.cargoDesempenado.personaId);
            }
        }

        function initLookups() {
            var lookups = datacontext.lookup.lookupCachedData;
            vm.areas = lookups.areas;
        }

        function onDestroy() {
            $scope.$on('$destroy', function () {
                datacontext.cancel();
            });
        }

        function onHasChanges() {
            $scope.$on(config.events.hasChangesChanged, function (event, data) {
                vm.hasChanges = data.hasChanges;
            });
        }

        function getRequestedCargoDesempenado() {
            var id = $routeParams.idCargoDesempenado;
            var idPersona = $routeParams.idPersona;
            if (id === 'nuevo') {
                vm.cargoDesempenado = datacontext.cargoDesempenado.create();
                vm.cargoDesempenado.desde = moment.utc().format('YYYY/MM/DD');
                vm.cargoDesempenado.personaId = idPersona;

                return vm.cargoDesempenado;
            }

            return datacontext.cargoDesempenado.getById(id)
                .then(function (data) {
                    vm.cargoDesempenado = data;
                }, function (error) {
                    logError('No se pudo obtener cargo desempeñado ' + id);
                });
        }

        function goBack() { goToPersona(); }

        function desdeOpenDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.desdeDatePickerOpened = true;
        }

        function hastaOpenDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.hastaDatePickerOpened = true;
        }

        function save() {
            if (!canSave()) { return $q.when(null); }

            vm.isSaving = true;
            return datacontext.save()
                .then(function (saveResult) {
                    vm.isSaving = false;
                }, function (error) {
                    vm.isSaving = false;
                });
        }
    }
})();
