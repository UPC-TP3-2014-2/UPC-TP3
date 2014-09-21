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
                    'Scripts/Webapp/app.js': [
                        'Scripts/Webapp/app.coffee',
                        'Scripts/Webapp/config.coffee',
                        'Scripts/Webapp/Controllers/NavbarController.coffee',
                        'Scripts/Webapp/Controllers/HomeController.coffee',
                        'Scripts/Webapp/Controllers/SolicitudCocinaController.coffee'
                    ]
                }
            }
        },

        uglify: {
            minified: {
                files: {
                    'Scripts/Webapp/app.min.js': 'Scripts/Webapp/app.js'
                }
            }
        }, 

        watch: {
            coffee: {
                files: ['Scripts/Webapp/**/*.coffee'],
                tasks: ['coffee:compile', 'uglify:minified'],
                options: {
                    livereload: true
                }
            },

            template: {
                files: ['Scripts/Webapp/**/*.html'], 
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