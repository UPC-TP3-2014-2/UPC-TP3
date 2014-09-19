(function () {
    'use strict';

    var controllerId = 'solicitudcapacitaciondetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog', 'common', 'config', 'datacontext',
            solicitudcapacitaciondetalle]);

    function solicitudcapacitaciondetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.archivarCapacitaion = archivarCapacitaion;
        vm.cancel = cancel;
        vm.deleteEntity = deleteEntity;
        vm.fechaPlanificadaDatePickerOpened = false;
        vm.goBack = goBack;
        vm.goToParent = goToParent;
        vm.hasChanges = false;
        vm.isNew = isNew;
        vm.isSaving = false;
        vm.niveles = [];
        vm.openFechaPlanificadaDatePicker = openFechaPlanificadaDatePicker;
        vm.solicitudCapacitacion = undefined;
        vm.save = save;
        vm.trabajadores = [];
        vm.title = 'solicitudcapacitaciondetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        Object.defineProperty(vm, 'isNew', {
            get: isNew
        });

        function canSave() { return vm.hasChanges && !vm.isSaving; }
        
        activate();

        function activate() {
            initLookups();
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedEntity()], controllerId);
        }

        function archivarCapacitaion() {
            vm.solicitudCapacitacion.archivada = true;

            vm.save().then(success, failed);

            function success() { goToParent(); }

            function failed(error) { cancel(); }
        }

        function cancel() {
            datacontext.cancel();
            if (vm.solicitudCapacitacion.entityAspect.entityState.isDetached()) {
                goToParent();
            }
        }

        function deleteEntity() {
            return bsDialog.deleteDialog(
                    '¿Desea anular esta Solicitud de Capacitación?',
                    'Confirmar Anulación',
                    'Anular',
                    'warning')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.solicitudCapacitacion);
                vm.save().then(success, failed);

                function success() { goToParent(); }

                function failed(error) { cancel(); }
            }
        }

        function goToParent() {
            $location.path('/solicitudes/capacitacion');
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

        function getRequestedEntity() {
            var id = $routeParams.id;
            if (id === 'nuevo') {
                vm.solicitudCapacitacion = datacontext.solicitudCapacitacion.create();
                vm.solicitudCapacitacion.fechaRegistro = moment.utc().format('YYYY/MM/DD');
                vm.solicitudCapacitacion.fechaPlanificada = moment.utc().add(1, 'months').format('YYYY/MM/DD');
                vm.solicitudCapacitacion.estado = 'Pendiente';

                return vm.solicitudCapacitacion;
            }

            return datacontext.solicitudCapacitacion.getById(id)
                .then(function (data) {
                    vm.solicitudCapacitacion = data;
                }, function (error) {
                    logError('No se pudo obtener solicitud de capacitacion ' + id);
                });
        }

        function goBack() { goToParent(); }

        function initLookups() {
            var lookups = datacontext.lookup.lookupCachedData;
            vm.capacitaciones = lookups.capacitaciones;

            datacontext.persona.getAll().then(function(data) {
                vm.trabajadores = data;
            });
        }

        function isNew() {
            return vm.solicitudCapacitacion && vm.solicitudCapacitacion.id <= 0;
        }

        function openFechaPlanificadaDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.fechaPlanificadaDatePickerOpened = true;
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
