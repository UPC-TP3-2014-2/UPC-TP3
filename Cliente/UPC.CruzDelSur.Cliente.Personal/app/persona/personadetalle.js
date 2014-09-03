(function () {
    'use strict';

    var controllerId = 'personadetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog',
            'common', 'config', 'datacontext', 
            personadetalle]);

    function personadetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.cancel = cancel;
        vm.datePickerMaxDate = datePickerMaxDate;
        vm.datePickerOpened = false;
        vm.deletePersona = deletePersona;
        vm.goBack = goBack;
        vm.goToEducacion = goToEducacion;
        vm.goToExperienciaLaboral = goToExperienciaLaboral;
        vm.hasChanges = false;
        vm.isSaving = false;
        vm.persona = undefined;
        vm.personaIdParameter = $routeParams.id;
        vm.openDatePicker = openDatePicker;
        vm.save = save;
        vm.tiposDocumento = [];
        vm.title = 'personadetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        Object.defineProperty(vm, 'isNew', {
            get: isNew
        });

        activate();

        function activate() {
            initLookups();
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedPersona()], controllerId);
        }

        function cancel() {
            datacontext.cancel();
            if (vm.persona.entityAspect.entityState.isDetached()) {
                gotoPersonas();
            }
        }

        function canSave() { return vm.hasChanges && !vm.isSaving; }

        function datePickerMaxDate() {
            return moment.subtract('years', 18);
        }

        function deletePersona() {
            return bsDialog.deleteDialog('Persona')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.persona);
                vm.save().then(success, failed);

                function success() { gotoPersonas(); }

                function failed(error) { cancel(); }
            }
        }

        function getRequestedPersona() {
            var id = $routeParams.id;
            if (id === 'nuevo') {
                vm.persona = datacontext.persona.create();

                return vm.persona;
            }

            return datacontext.persona.getById(id)
                .then(function(data) {
                    vm.persona = data;
                }, function(error) {
                    logError('No se pudo obtener persona ' + id);
                });
        }

        function goBack() { gotoPersonas(); }

        function goToEducacion(educacion) {
            if (vm.persona && vm.persona.id) {
                var id = (educacion ? (educacion.id || 'nuevo') : 'nuevo');

                $location.path('/persona/' + vm.persona.id + '/educacion/' + id);
            }
        }

        function goToExperienciaLaboral(experienciaLaboral) {
            if (vm.persona && vm.persona.id) {
                var id = (experienciaLaboral ? (experienciaLaboral.id || 'nuevo') : 'nuevo');

                $location.path('/persona/' + vm.persona.id + '/experienciaLaboral/' + id);
            }
        }

        function gotoPersonas() { $location.path('/personas'); }

        function initLookups() {
            var lookups = datacontext.lookup.lookupCachedData;
            vm.tiposDocumento = lookups.tiposDocumento;
        }

        function isNew() {
            return vm.persona && vm.persona.id <= 0;
        }

        function onDestroy() {
            $scope.$on('$destroy', function() {
                datacontext.cancel();
            });
        }

        function onHasChanges() {
            $scope.$on(config.events.hasChangesChanged, function(event, data) {
                vm.hasChanges = data.hasChanges;
            });
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.datePickerOpened = true;
        }

        function save() {
            if (!canSave()) { return $q.when(null); }

            vm.isSaving = true;
            return datacontext.save()
                .then(function(saveResult) {
                    vm.isSaving = false;
                }, function(error) {
                    vm.isSaving = false;
                });
        }
    }
})();
