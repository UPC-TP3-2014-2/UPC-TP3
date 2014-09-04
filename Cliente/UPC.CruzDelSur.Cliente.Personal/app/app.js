﻿(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'breeze.angular',    // configures breeze for an angular app
        'breeze.directives', // contains the breeze validation directive (zValidate)
        'ui.bootstrap'       // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);

    // Handle routing errors and success events.
    // Trigger breeze configuration
    app.run([
        '$route', 'datacontext', 'routemediator',
        function ($route, datacontext, routemediator) {
            // Include $route to kick start the router.
            datacontext.prime();
            routemediator.setRoutingHandlers();
        }
    ]);
})();