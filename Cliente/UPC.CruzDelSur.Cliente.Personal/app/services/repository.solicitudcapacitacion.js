(function () {
    'use strict';

    var serviceId = 'repository.solicitudcapacitacion';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositorySolicitudCapacitacion]);

    function RepositorySolicitudCapacitacion(model, AbstractRepository) {
        var entityName = model.entityNames.solicitudCapacitacion;
        var EntityQuery = breeze.EntityQuery;
        var where = breeze.Predicate("archivada", '==', false);
        var orderBy = 'fechaRegistro desc';

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
            var entity = this.manager.createEntity(entityName);

            return entity;
        }

        function getAll(forceRemote, archivadas) {
            var self = this;
            var solicitudesCapacitacion = [];

            var predicate = where;
            if (archivadas) {
                predicate = breeze.Predicate('archivada', '==', true);
            }

            if (self._areItemsLoaded() && !forceRemote) {
                solicitudesCapacitacion = self._getAllLocal(entityName, orderBy, predicate);
                
                return self.$q.when(solicitudesCapacitacion);
            }

            return EntityQuery
                .from('SolicitudesCapacitacion')
                .where(predicate)
                .orderBy(orderBy)
                .expand('trabajador, trabajador.cargo, capacitacion')
                .toType(entityName)
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                solicitudesCapacitacion = data.results;
                self._areItemsLoaded(true);
                self.log('Se obtuvieron [Solicitudes de Capacitacion] del origen de datos remoto', solicitudesCapacitacion, true);

                return solicitudesCapacitacion;
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
                .from('SolicitudesCapacitacion')
                .inlineCount(true)
                .using(this.manager)
                .execute()
                .then(this._getInlineCount);
        }
    }
})();