(function () {
    'use strict';

    var controllerId = 'educaciondetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog', 'common', 'config', 'datacontext',
            educaciondetalle]);

    function educaciondetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.cancel = cancel;
        vm.desdeDatePickerOpened = false;
        vm.hastaDatePickerOpened = false;
        vm.deleteEducacion = deleteEducacion;
        vm.goBack = goBack;
        vm.goToPersona = goToPersona;
        vm.hasChanges = false;
        vm.isSaving = false;
        vm.educacion = undefined;
        vm.educacionIdParameter = $routeParams.idEducacion;
        vm.desdeOpenDatePicker = desdeOpenDatePicker;
        vm.hastaOpenDatePicker = hastaOpenDatePicker;
        vm.personaIdParameter = $routeParams.idPersona;
        vm.save = save;
        vm.tiposEducacion = [];
        vm.title = 'educaciondetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        function canSave() { return vm.hasChanges && !vm.isSaving; }

        activate();

        function activate() {
            initLookups();
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedEducacion()], controllerId);
        }

        function cancel() {
            datacontext.cancel();
            if (vm.educacion.entityAspect.entityState.isDetached()) {
                goToPersona();
            }
        }

        function deleteEducacion() {
            return bsDialog.deleteDialog(
                    '¿Desea eliminar esta Educación?',
                    'Confirmar Eliminación',
                    'Eliminar')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.educacion);
                vm.save().then(success, failed);

                function success() { goToPersona(); }

                function failed(error) { cancel(); }
            }
        }

        function goToPersona() {
            if (vm.educacion && vm.educacion.personaId) {
                $location.path('/persona/' + vm.educacion.personaId);
            }
        }

        function initLookups() {
            var lookups = datacontext.lookup.lookupCachedData;
            vm.tiposEducacion = lookups.tiposEducacion;
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

        function getRequestedEducacion() {
            var id = $routeParams.idEducacion;
            var idPersona = $routeParams.idPersona;
            if (id === 'nuevo') {
                vm.educacion = datacontext.educacion.create();
                vm.educacion.personaId = idPersona;

                return vm.educacion;
            }

            return datacontext.educacion.getById(id)
                .then(function (data) {
                    vm.educacion = data;
                }, function (error) {
                    logError('No se pudo obtener educacion ' + id);
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
