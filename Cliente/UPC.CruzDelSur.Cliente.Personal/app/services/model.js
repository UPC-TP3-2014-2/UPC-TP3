(function () {
    'use strict';

    var serviceId = 'model';

    angular.module('app').factory(serviceId, model);

    function model() {
        var entityNames = {
            auditoria: 'AuditEntry',
            cargo: 'Cargo',
            educacion: 'Educacion',
            experienciaLaboral: 'ExperienciaLaboral',
            persona: 'Persona',
            solicitudCapacitacion: 'SolicitudCapacitacion',
            tipoDocumento: 'TipoDocumento',
            tipoEducacion: 'TipoEducacion',
        };

        var service = {
            configureMetadataStore: configureMetadataStore,
            createNullos: createNullos,
            entityNames: entityNames
        };

        return service;

        function configureMetadataStore(metadataStore) {
            registerPersona(metadataStore);
        }

        function createNullos(manager) {
            var unchanged = breeze.EntityState.Unchanged;

            createNullo(entityNames.tipoDocumento);

            function createNullo(entityName, values) {
                var initialValues = values || { nombre: ' [Seleccione un ' + entityName + ']' };

                return manager.createEntity(entityName, initialValues, unchanged);
            }
        }

        function registerPersona(metadataStore) {
            metadataStore.registerEntityTypeCtor(entityNames.persona, Persona);

            function Persona() { }

            Object.defineProperty(Persona.prototype, 'nombreCompleto', {
                get: function() {
                    var nombre = this.nombre;
                    var apellidos = this.apellidos;

                    return apellidos ? nombre + ' ' + apellidos : nombre;
                }
            });

            Object.defineProperty(Persona.prototype, 'experienciasLaborales', {
                get: function() {
                    var detallesHojaVida = this.detallesHojaVida;

                    return filterExperienciasLaborales(detallesHojaVida);
                }
            });

            Object.defineProperty(Persona.prototype, 'educaciones', {
                get: function() {
                    var detallesHojaVida = this.detallesHojaVida;

                    return filterByTypeName(detallesHojaVida, entityNames.educacion);
                }
            });

            Object.defineProperty(Persona.prototype, 'ultimaExperienciaLaboral', {
                get: function () {
                    var ultimaExperienciaLaboral = null;
                    var detallesHojaVida = this.detallesHojaVida;
                    var experienciasLaborales = filterExperienciasLaborales(detallesHojaVida)
                        .filter(function(experienciaLaboral) {
                            return (experienciaLaboral.hasta === null);
                        });
                    if (experienciasLaborales.length > 0) {
                        ultimaExperienciaLaboral = experienciasLaborales[0];
                    }
                    
                    return ultimaExperienciaLaboral;
                }
            });

            function filterExperienciasLaborales(detallesHojaVida) {
                return filterByTypeName(detallesHojaVida, entityNames.experienciaLaboral);
            }

            function filterByTypeName(entities, typeName) {
                return entities.filter(function(entity) {
                    return (entity._$typeName.indexOf(typeName) > -1);
                });
            }
        }
    }
})();