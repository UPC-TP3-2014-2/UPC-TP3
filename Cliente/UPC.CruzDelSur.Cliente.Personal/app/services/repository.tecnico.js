(function () {
    'use strict';

    var serviceId = 'repository.tecnico';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositoryTecnico]);

    function RepositoryTecnico(model, AbstractRepository) {
        var entityName = model.entityNames.tecnico;
        var EntityQuery = breeze.EntityQuery;
        var orderBy = 'persona.apellidos, persona.nombre';

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
            var tecnicos = [];

            if (self._areItemsLoaded() && !forceRemote) {
                tecnicos = self._getAllLocal(entityName, orderBy);
                
                return self.$q.when(tecnicos);
            }

            return EntityQuery
                .from('Tecnicos')
                .orderBy(orderBy)
                .expand('turno, persona')
                .toType(entityName)
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                tecnicos = data.results;
                self._areItemsLoaded(true);
                self.log('Se obtuvieron [Tecnicos] del origen de datos remoto', tecnicos, true);

                return tecnicos;
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
                .from('Tecnicos')
                .inlineCount(true)
                .using(this.manager)
                .execute()
                .then(this._getInlineCount);
        }
    }
})();