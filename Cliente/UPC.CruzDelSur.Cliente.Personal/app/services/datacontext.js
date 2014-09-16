(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId,
        ['common', 'config', 'entityManagerFactory', 'model', 'repositories', datacontext]);

    function datacontext(common, config, emFactory, model, repositories) {
        var entityNames = model.entityNames;
        var events = config.events;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');
        var manager = emFactory.newManager();
        var primePromise;
        var repoNames = ['auditoria', 'educacion', 'experienciaLaboral', 'lookup', 'persona', 'tecnico', 'solicitudCapacitacion'];
        var $q = common.$q;

        var service = {
            // TODO: Remove these
            getPeople: getPeople,
            getMessageCount: getMessageCount,

            cancel: cancel,
            markDeleted: markDeleted,
            prime: prime,
            save: save
        };

        init();

        return service;

        function init() {
            repositories.init(manager);
            defineLazyLoadedRepos();
            setupEventForHasChangesChanged();
        }

        function cancel() {
            if (manager.hasChanges()) {
                manager.rejectChanges();
                logSuccess('Se cancelaron los cambios', null, true);
            }
        }

        function defineLazyLoadedRepos() {
            repoNames.forEach(function(name) {
                Object.defineProperty(service, name, {
                    configurable: true,
                    get: function() {
                        var repo = repositories.getRepo(name);
                        Object.defineProperty(service, name, {
                            value: repo,
                            configurable: false,
                            enumerable: true
                        });

                        return repo;
                    }
                });
            });
        }

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];
            return $q.when(people);
        }

        function markDeleted(entity) {
            return entity.entityAspect.setDeleted();
        }

        function prime() {
            if (primePromise) return primePromise;

            primePromise = $q.all([service.lookup.getAll()])
                .then(extendMetadata)
                .then(success);

            return primePromise;

            function success() {
                service.lookup.setLookups();
                log('Se realizó descarga inicial de datos');
            }

            function extendMetadata() {
                var metadataStore = manager.metadataStore;
                model.extendMetadata(metadataStore);
                registerResourceNames(metadataStore);
            }

            function registerResourceNames(metadataStore) {
                var types = metadataStore.getEntityTypes();
                types.forEach(function (type) {
                    if (type instanceof breeze.EntityType) {
                        set(type.shortName, type);
                    }
                });

                function set(resourceName, entityName) {
                    metadataStore.setEntityTypeForResourceName(resourceName, entityName);
                }
            }
        }

        function save() {
            return manager.saveChanges()
                .then(saveSuccedded, saveFailed);

            function saveSuccedded(result) {
                logSuccess('Guardado exitoso', result, true);
            }

            function saveFailed(error) {
                var msg = config.appErrorPrefix + 'No se pudo guardar: ' +
                    breeze.saveErrorMessageService.getErrorMessage(error);
                error.message = msg;
                logError(msg, error);
                throw error;
            }
        }

        function setupEventForHasChangesChanged() {
            manager.hasChangesChanged.subscribe(function (eventArgs) {
                var data = { hasChanges: eventArgs.hasChanges };
                common.$broadcast(events.hasChangesChanged, data)
            });
        }
    }
})();