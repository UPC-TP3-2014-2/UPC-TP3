(function () {
    'use strict';

    var controllerId = 'experiencialaboraldetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog', 'common', 'config', 'datacontext',
            experiencialaboraldetalle]);

    function experiencialaboraldetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.cancel = cancel;
        vm.desdeDatePickerOpened = false;
        vm.hastaDatePickerOpened = false;
        vm.deleteExperienciaLaboral = deleteExperienciaLaboral;
        vm.goBack = goBack;
        vm.goToPersona = goToPersona;
        vm.hasChanges = false;
        vm.isSaving = false;
        vm.experienciaLaboral = undefined;
        vm.experienciaLaboralIdParameter = $routeParams.idExperienciaLaboral;
        vm.desdeOpenDatePicker = desdeOpenDatePicker;
        vm.hastaOpenDatePicker = hastaOpenDatePicker;
        vm.personaIdParameter = $routeParams.idPersona;
        vm.save = save;
        vm.title = 'experiencialaboraldetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        function canSave() { return vm.hasChanges && !vm.isSaving; }

        activate();

        function activate() {
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedExperienciaLaboral()], controllerId);
        }

        function cancel() {
            datacontext.cancel();
            if (vm.experienciaLaboral.entityAspect.entityState.isDetached()) {
                goToPersona();
            }
        }

        function deleteExperienciaLaboral() {
            return bsDialog.deleteDialog('Experiencia Laboral')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.experienciaLaboral);
                vm.save().then(success, failed);

                function success() { goToPersona(); }

                function failed(error) { cancel(); }
            }
        }

        function goToPersona() {
            if (vm.experienciaLaboral && vm.experienciaLaboral.personaId) {
                $location.path('/persona/' + vm.experienciaLaboral.personaId);
            }
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

        function getRequestedExperienciaLaboral() {
            var id = $routeParams.idExperienciaLaboral;
            var idPersona = $routeParams.idPersona;
            if (id === 'nuevo') {
                vm.experienciaLaboral = datacontext.experienciaLaboral.create();
                vm.experienciaLaboral.personaId = idPersona;

                return vm.experienciaLaboral;
            }

            return datacontext.experienciaLaboral.getById(id)
                .then(function (data) {
                    vm.experienciaLaboral = data;
                }, function (error) {
                    logError('No se pudo obtener experiencia laboral ' + id);
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
