(function () {
    'use strict';

    var serviceId = 'repository.educacion';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositoryEducacion]);

    function RepositoryEducacion(model, AbstractRepository) {
        var entityName = model.entityNames.educacion;

        function Ctor(mgr) {
            this.serviceId = serviceId;
            this.entityName = entityName;
            this.manager = mgr;

            this.create = create;
            this.getById = getById;
        }

        AbstractRepository.extend(Ctor);

        return Ctor;

        function create() {
            return this.manager.createEntity(entityName);
        }

        function getById(id, forceRemote) {
            return this._getById(entityName, id, forceRemote);
        }
    }
})();