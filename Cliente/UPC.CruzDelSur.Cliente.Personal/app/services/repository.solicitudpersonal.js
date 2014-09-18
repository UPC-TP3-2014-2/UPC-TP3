(function () {
    'use strict';

    var serviceId = 'repository.solicitudpersonal';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositorySolicitudPersonal]);

    function RepositorySolicitudPersonal(model, AbstractRepository) {
        var entityName = model.entityNames.solicitudPersonal;
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
            entity.fechaVencimiento = moment().add(1, 'months');
            return entity;
        }

        function getAll(forceRemote, archivadas) {
            var self = this;
            var solicitudesPersonal = [];

            var predicate = where;
            if (archivadas) {
                predicate = breeze.Predicate('archivada', '==', true);
            }

            if (self._areItemsLoaded() && !forceRemote) {
                solicitudesPersonal = self._getAllLocal(entityName, orderBy, predicate);
                
                return self.$q.when(solicitudesPersonal);
            }

            return EntityQuery
                .from('SolicitudesPersonal')
                .where(predicate)
                .orderBy(orderBy)
                .expand('area, cargo, tipoEducacion')
                .toType(entityName)
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                solicitudesPersonal = data.results;
                self._areItemsLoaded(true);
                self.log('Se obtuvieron [Solicitudes de Personal] del origen de datos remoto', solicitudesPersonal);

                return solicitudesPersonal;
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
                .from('SolicitudesPersonal')
                .inlineCount(true)
                .using(this.manager)
                .execute()
                .then(this._getInlineCount);
        }
    }
})();