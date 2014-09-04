(function () {
    'use strict';

    var serviceId = 'repository.auditoria';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositoryAuditoria]);

    function RepositoryAuditoria(model, AbstractRepository) {
        var entityName = model.entityNames.auditoria;
        var EntityQuery = breeze.EntityQuery;
        var orderBy = 'eventTime desc';

        function Ctor(mgr) {
            this.serviceId = serviceId;
            this.entityName = entityName;
            this.manager = mgr;

            this.getAll = getAll;
            this.getById = getById;
            this.getCount = getCount;
        }

        AbstractRepository.extend(Ctor);

        return Ctor;

        function getAll(forceRemote) {
            var self = this;
            var auditorias = [];

            if (self._areItemsLoaded() && !forceRemote) {
                auditorias = self._getAllLocal(entityName, orderBy);
                
                return self.$q.when(auditorias);
            }

            return EntityQuery
                .from('AuditEntries')
                .orderBy(orderBy)
                .toType(entityName)
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                auditorias = data.results;
                self._areItemsLoaded(true);
                self.log('Se obtuvieron [Auditorias] del origen de datos remoto', auditorias, true);

                return auditorias;
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
                .from('AuditEntries')
                .inlineCount(true)
                .using(this.manager)
                .execute()
                .then(this._getInlineCount);
        }
    }
})();