(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            $stateProvider
                .state('groups', {
                    url: '/',
                    templateUrl: '/App/Main/views/groups/list.cshtml',
                    menu: 'Groups'
                })
                .state('students', {
                    url: '/students',
                    templateUrl: '/App/Main/views/students/list.cshtml',
                    menu: 'Students'
                });
        }
    ]);
})();