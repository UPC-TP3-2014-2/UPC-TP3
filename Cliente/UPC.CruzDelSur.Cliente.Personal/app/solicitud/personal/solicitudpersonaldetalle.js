(function () {
    'use strict';

    var controllerId = 'solicitudpersonaldetalle';

    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', '$scope', '$window', 'bootstrap.dialog', 'common', 'config', 'datacontext',
            solicitudpersonaldetalle]);

    function solicitudpersonaldetalle($location, $routeParams, $scope, $window, bsDialog, common, config, datacontext) {
        var vm = this;
        var logError = common.logger.getLogFn(controllerId, 'error');

        vm.activate = activate;
        vm.archivarPersonal = archivarPersonal;
        vm.areas = [];
        vm.cancel = cancel;
        vm.deleteEntity = deleteEntity;
        vm.fechaVencimientoDatePickerOpened = false;
        vm.goBack = goBack;
        vm.goToParent = goToParent;
        vm.hasChanges = false;
        vm.isNew = isNew;
        vm.isSaving = false;
        vm.niveles = [];
        vm.openFechaVencimientoDatePicker = openFechaVencimientoDatePicker;
        vm.solicitudPersonal = undefined;
        vm.save = save;
        vm.tiposEducacion = [];
        vm.title = 'solicitudpersonaldetalle';

        Object.defineProperty(vm, 'canSave', {
            get: canSave
        });

        function canSave() { return vm.hasChanges && !vm.isSaving; }

        activate();

        function activate() {
            initLookups();
            onDestroy();
            onHasChanges();
            common.activateController([getRequestedEntity()], controllerId);
        }

        function archivarPersonal() {
            vm.solicitudPersonal.archivada = true;

            vm.save().then(success, failed);

            function success() { goToParent(); }

            function failed(error) { cancel(); }
        }

        function cancel() {
            datacontext.cancel();
            if (vm.solicitudPersonal.entityAspect.entityState.isDetached()) {
                goToParent();
            }
        }

        function deleteEntity() {
            return bsDialog.deleteDialog('Solicitud de Personal')
                .then(confirmDelete);

            function confirmDelete() {
                datacontext.markDeleted(vm.solicitudPersonal);
                vm.save().then(success, failed);

                function success() { goToParent(); }

                function failed(error) { cancel(); }
            }
        }

        function goToParent() {
            $location.path('/solicitudes/personal');
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
                vm.solicitudPersonal = datacontext.solicitudPersonal.create();
                vm.solicitudPersonal.fechaRegistro = moment.utc().format('YYYY/MM/DD');
                vm.solicitudPersonal.estado = 'Pendiente';

                return vm.solicitudPersonal;
            }

            return datacontext.solicitudPersonal.getById(id)
                .then(function (data) {
                    vm.solicitudPersonal = data;
                }, function (error) {
                    logError('No se pudo obtener solicitud de personal ' + id);
                });
        }

        function goBack() { goToParent(); }

        function initLookups() {
            var lookups = datacontext.lookup.lookupCachedData;
            vm.areas = lookups.areas;
            vm.tiposEducacion = lookups.tiposEducacion;
        }

        function isNew() {
            return vm.solicitudPersonal.id <= 0;
        }

        function openFechaVencimientoDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.fechaVencimientoDatePickerOpened = true;
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
