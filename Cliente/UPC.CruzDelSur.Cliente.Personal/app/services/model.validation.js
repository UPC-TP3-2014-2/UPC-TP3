(function () {
    'use strict';

    var serviceId = 'model.validation';

    angular.module('app').factory(serviceId, modelValidation);

    modelValidation.$inject = ['common'];

    function modelValidation(common) {
        var entityNames;
        var log = common.logger.getLogFn(serviceId);
        var Validator = breeze.Validator;

        var fromToRangeValidator;
        var legalAgeValidator;
        var requireReferenceValidator;
        var futureDateValidator;

        var service = {
            applyValidators: applyValidators,
            createAndRegister: createAndRegister
        };

        return service;

        function applyValidators(metadataStore) {

            applyToPersona(metadataStore);
            applyToExperienciaLaboral(metadataStore);
            applyToSolicitudCapacitacion(metadataStore);

            log('Validators applied', null, serviceId);
        }

        function applyToExperienciaLaboral(metadataStore) {
            var experienciaLaboralType = metadataStore.getEntityType(entityNames.experienciaLaboral);

            experienciaLaboralType.validators
                .push(fromToRangeValidator);
        }

        function applyToPersona(metadataStore) {
            var personaType = metadataStore.getEntityType(entityNames.persona);

            personaType.getProperty('nroDocumento').displayName = 'Nro de Documento';
            personaType.getProperty('fechaNacimiento').displayName = 'Fecha de Nacimiento';

            personaType.validators
                .push(legalAgeValidator);

            var tipoDocumento = personaType.getProperty('tipoDocumento');
            tipoDocumento.displayName = 'Tipo de Documento';
            tipoDocumento.validators
                .push(requireReferenceValidator);

            personaType.getProperty('cargo').validators
                .push(requireReferenceValidator);
        }

        function applyToSolicitudCapacitacion(metadataStore) {
            var solicitudCapacitacionType = metadataStore.getEntityType(entityNames.solicitudCapacitacion);

            solicitudCapacitacionType.getProperty('trabajador').validators
                .push(requireReferenceValidator);

            solicitudCapacitacionType.getProperty('capacitacion').validators
                .push(requireReferenceValidator);

            var fechaPlanificada = solicitudCapacitacionType.getProperty('fechaPlanificada');
            fechaPlanificada.displayName = 'Fecha Planificada';
            fechaPlanificada.validators
                .push(futureDateValidator);
        }

        function createAndRegister(eNames) {
            entityNames = eNames;

            var messageTemplate = 'Debe especificar %displayName%';

            Validator.messageTemplates['required'] = messageTemplate;

            requireReferenceValidator = createRequireReferenceValidator(messageTemplate);
            Validator.register(requireReferenceValidator);

            fromToRangeValidator = createFromToRangeValidator();
            Validator.register(fromToRangeValidator);

            legalAgeValidator = createLegalAgeValidator();
            Validator.register(legalAgeValidator);

            futureDateValidator = createFutureDateValidator();
            Validator.register(futureDateValidator);

            log('Validators created and registered', null, serviceId, false);
        }

        function createFromToRangeValidator() {
            var name = 'fromToRange';
            var ctx = {
                messageTemplate: '%toDisplayName% debe ser mayor a %fromDisplayName%'
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(entity, context) {
                var from = entity.getProperty('desde');
                var to = entity.getProperty('hasta');
                context.from = from;
                context.to = to;
                context.fromDisplayName = 'Desde';
                context.toDisplayName = 'Hasta';

                if (from != null & to != null) {
                    return from < to;
                }

                return true;
            }
        }

        function createFutureDateValidator() {
            var name = 'futureDate';
            var ctx = {
                messageTemplate: '%displayName% no puede ser una fecha en el pasado'
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(value) {
                return value ? moment().diff(value, 'days') <= 0 : true;
            }
        }

        function createLegalAgeValidator() {
            var name = 'legalAge';
            var ctx = {
                messageTemplate: '%fullName% debe ser mayor de %legalAge%'
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(entity, context) {
                var dob = entity.getProperty('fechaNacimiento');
                var fullName = entity.getProperty('nombreCompleto') || 'Persona';
                var legalAge = 18;
                context.fullName = fullName;
                context.legalAge = legalAge;

                if (dob != null) {
                    return dob <= moment().subtract('years', legalAge);
                }

                return true;
            }
        }

        function createRequireReferenceValidator(messageTemplate) {
            var name = 'requireReference';
            var ctx = {
                messageTemplate: messageTemplate,
                isRequired: true
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(value) {
                return value ? value.id !== 0 : false;
            }
        }
    }
})();