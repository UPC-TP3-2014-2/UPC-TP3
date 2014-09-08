(function () {
    'use strict';

    var serviceId = 'repository.lookup';

    angular.module('app').factory(serviceId,
        ['model', 'repository.abstract', RepositoryLookup]);

    function RepositoryLookup(model, AbstractRepository) {
        var entityName = 'lookups';
        var entityNames = model.entityNames;
        var EntityQuery = breeze.EntityQuery;

        function Ctor(mgr) {
            this.serviceId = serviceId;
            this.entityName = entityName;
            this.manager = mgr;

            this.getAll = getAll;
            this.setLookups = setLookups;
        }

        AbstractRepository.extend(Ctor);

        return Ctor;

        function getAll() {
            var self = this;

            return EntityQuery
                .from('Lookups')
                .using(self.manager)
                .execute()
                .then(querySucceeded, self._queryFailed);

            function querySucceeded(data) {
                model.createNullos(self.manager);
                self.log('Se obtuvo [Informacion General] del origen de datos remoto', data, true);
                return true;
            }
        }

        function setLookups() {
            this.lookupCachedData = {
                tiposDocumento: this._getAllLocal(entityNames.tipoDocumento, 'nombre'),
                capacitaciones: this._getAllLocal(entityNames.capacitacion, 'nombre'),
                cargos: this._getAllLocal(entityNames.cargo, 'nombre')
            }
        }
    }
})();