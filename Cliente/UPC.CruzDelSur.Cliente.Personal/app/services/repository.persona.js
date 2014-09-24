(function () {
    'use strict';

    var serviceId = 'repository.persona';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositoryPersona]);

    function RepositoryPersona(model, AbstractRepository) {
        var entityName = model.entityNames.persona;
        var EntityQuery = breeze.EntityQuery;
        var orderBy = 'apellidos, nombre';

        function Ctor(mgr) {
            this.serviceId = serviceId;
            this.entityName = entityName;
            this.manager = mgr;

            this.create = create;
            this.getAll = getAll;
            this.getById = getById;
            this.getCount = getCount;
        }

        AbstractRepository.extend(Ctor);

        return Ctor;

        function create() {
            return this.manager.createEntity(entityName);
        }

        function getAll(forceRemote) {
            var self = this;
            var personas = [];

            if (self._areItemsLoaded() && !forceRemote) {
                personas = self._getAllLocal(entityName, orderBy);
                
                return self.$q.when(personas);
            }

            return EntityQuery
                .from('Personas')
                .orderBy(orderBy)
                .expand('tipoDocumento, detallesHojaVida, cargosDesempenados')
                .toType(entityName)
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                personas = data.results;
                self._areItemsLoaded(true);
                self.log('Se obtuvieron [Personas] del origen de datos remoto', personas, true);

                return personas;
            }
        }

        function getById(id, forceRemote) {
            return this._getById(entityName, id, forceRemote);
        }

        function getCount() {
            if (this._areItemsLoaded()) {
                return this.$q.when(this._getLocalEntityCount(entityName));
            }

            return EntityQuery
                .from('Personas')
                .inlineCount(true)
                .using(this.manager)
                .execute()
                .then(this._getInlineCount);
        }
    }
})();