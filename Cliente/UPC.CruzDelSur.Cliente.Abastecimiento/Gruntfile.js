module.exports = function (grunt) {

    require('load-grunt-tasks')(grunt);

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        
        coffee: {
            compile: {
                options: {
                    bare: true,
                    join: true
                },
                files: {
                    'Webapp/app.js': [
                        'Webapp/app.coffee',
                        'Webapp/config.coffee',
                        'Webapp/Services/SolicitudCocinaService.coffee',
                        'Webapp/Services/SolicitudInsumoService.coffee',
                        'Webapp/Services/ProgramacionRutaService.coffee',
                        'Webapp/Controllers/NavbarController.coffee',
                        'Webapp/Controllers/HomeController.coffee',
                        'Webapp/Controllers/SolicitudCocinaController.coffee', 
                        'Webapp/Controllers/SolicitudInsumoController.coffee'
                    ]
                }
            }
        },

        uglify: {
            minified: {
                files: {
                    'Webapp/app.min.js': 'Webapp/app.js'
                }
            }
        }, 

        watch: {
            coffee: {
                files: ['Webapp/**/*.coffee'],
                tasks: ['coffee:compile', 'uglify:minified'],
                options: {
                    livereload: true
                }
            },

            template: {
                files: ['Webapp/**/*.html'], 
                tasks: [], 
                options: {
                    livereload: true
                }
            }, 

            grunt: {
                files: ['Gruntfile.js']
            }
        }
    });

    grunt.registerTask('default', ['watch'])

}