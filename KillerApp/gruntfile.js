/// <binding BeforeBuild='default' />
module.exports = function (grunt) {
    'use strict';

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        // Sass
        sass: {                              // Task
			ist: {                            // Target
			    options: {                       // Target options
                    style: 'expanded'
			    },
			        files: {                         // Dictionary of files
				    'wwwroot/css/main.css': 'Sass/main.scss',       // 'destination': 'source'
			    }
            }
        }
    });

    // Load the plugin
    grunt.loadNpmTasks('grunt-contrib-sass');

    // Default task(s).
    grunt.registerTask('default', ['sass']);
};