(function () {
    'use strict';

    var serviceId = 'repository.abstract';

    angular.module('app').factory(serviceId,
        ['common', 'config', AbstractRepository]);

    function AbstractRepository(common, config) {
        var EntityQuery = breeze.EntityQuery;
        var logError = common.logger.getLogFn(this.serviceId, 'error');

        function Ctor() {
            this.isLoaded = false;
        }

        Ctor.extend = function(repoCtor) {
            repoCtor.prototype = new Ctor();
            repoCtor.prototype.constructor = repoCtor;
        }

        Ctor.prototype._areItemsLoaded = _areItemsLoaded;
        Ctor.prototype._getAllLocal = _getAllLocal;
        Ctor.prototype._getById = _getById;
        Ctor.prototype._getInlineCount = _getInlineCount;
        Ctor.prototype._getLocalEntityCount = _getLocalEntityCount;
        Ctor.prototype._queryFailed = _queryFailed;
        Ctor.prototype.log = common.logger.getLogFn(this.serviceId);
        Ctor.prototype.$q = common.$q;

        return Ctor;

        function _areItemsLoaded(value) {
            if (value === undefined) {
                return this.isLoaded;
            }
            return this.isLoaded = value;
        }

        function _getAllLocal(resource, ordering, predicate) {
            return EntityQuery
                .from(resource)
                .orderBy(ordering)
                .where(predicate)
                .using(this.manager)
                .executeLocally();
        }

        function _getById(entityName, id, forceRemote) {
            var self = this;
            var manager = self.manager;
            if (!forceRemote) {
                var entity = manager.getEntityByKey(entityName, id);
                if (entity) {
                    self.log('Se obtuvo [' + entityName + '] id:' + id + ' desde el cache local', entity, true);
                    if (entity.entityAspect.entityState.isDeleted()) {
                        entity = null;
                    }
                    return self.$q.when(entity);
                }
            }

            return manager.fetchEntityByKey(entityName, id)
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                entity = data.entity;
                if (!entity) {
                    self.log('No se encontro [' + entityName + '] id:' + id, null, true);
                    return null;
                }

                self.log('Se obtuvo [' + entityName + '] id:' + id + ' desde el servidor', entity, true);

                return entity;
            }
        }

        function _getLocalEntityCount(resource) {
            var entities = EntityQuery
                .from(resource)
                .using(this.manager)
                .executeLocally();

            return entities.length;
        }

        function _getInlineCount(data) { return data.inlineCount; }

        function _queryFailed(error) {
            var msg = config.appErrorPrefix + 'Error retrieving data.' + error.message;
            logError(msg, error);
            throw error;
        }
    }
})();