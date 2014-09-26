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
        var pastDateValidator;
        var daysInTheFutureValidatorFactory;

        var service = {
            applyValidators: applyValidators,
            createAndRegister: createAndRegister
        };

        return service;

        function applyValidators(metadataStore) {

            applyToPersona(metadataStore);
            applyToExperienciaLaboral(metadataStore);
            applyToEducacion(metadataStore);
            applyToSolicitudCapacitacion(metadataStore);
            applyToSolicitudPersonal(metadataStore);

            log('Validators applied', null, serviceId);
        }

        function applyToEducacion(metadataStore) {
            var educacionType = metadataStore.getEntityType(entityNames.educacion);

            educacionType.validators
                .push(fromToRangeValidator);

            educacionType.getProperty('tipo').validators
                .push(requireReferenceValidator);

            educacionType.getProperty('hasta').validators
                .push(pastDateValidator);
        }

        function applyToExperienciaLaboral(metadataStore) {
            var experienciaLaboralType = metadataStore.getEntityType(entityNames.experienciaLaboral);

            experienciaLaboralType.validators
                .push(fromToRangeValidator);

            experienciaLaboralType.getProperty('hasta').validators
                .push(pastDateValidator);
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
            fechaPlanificada.validators
                .push(daysInTheFutureValidatorFactory({ days: 4 }));
        }

        function applyToSolicitudPersonal(metadataStore) {
            var solicitudPersonalType = metadataStore.getEntityType(entityNames.solicitudPersonal);

            solicitudPersonalType.getProperty('area').validators
                .push(requireReferenceValidator);

            solicitudPersonalType.getProperty('cargo').validators
                .push(requireReferenceValidator);

            var tipoEducacion = solicitudPersonalType.getProperty('tipoEducacion');
            tipoEducacion.displayName = 'Tipo de Educación';
            tipoEducacion.validators
                .push(requireReferenceValidator);

            var fechaVencimiento = solicitudPersonalType.getProperty('fechaVencimiento');
            fechaVencimiento.displayName = 'Fecha de Vencimiento';
            fechaVencimiento.validators
                .push(futureDateValidator);
            fechaVencimiento.validators
                .push(daysInTheFutureValidatorFactory({ days: 4 }));

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

            pastDateValidator = createPastDateValidator();
            Validator.register(pastDateValidator);

            daysInTheFutureValidatorFactory = createDaysInTheFutureValidatorFactory;
            Validator.registerFactory(daysInTheFutureValidatorFactory, "daysInTheFutureValidator");

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

        function createPastDateValidator() {
            var name = 'pastDate';
            var ctx = {
                messageTemplate: '%displayName% no puede ser una fecha en el futuro'
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(value) {
                return value ? moment().diff(value, 'days') >= 0 : true;
            }
        }

        function createDaysInTheFutureValidatorFactory(context) {
            var name = 'daysInTheFuture';
            var ctx = {
                messageTemplate: '%displayName% debe ser %days% días después de %origin%',
                days: context.days,
                origin: context.origin || 'hoy'
            };
            var val = new Validator(name, valFn, ctx);
            return val;

            function valFn(value, innerContext) {
                return value ? moment().diff(value, 'days') <= innerContext.days * -1 : true;
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