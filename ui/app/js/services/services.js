(function () {
    'use strict';

    /* Services */
    angular.module('appGeoCaf').factory('AppCafServices', AppCafServices);

    AppCafServices.$inject = ['$resource', 'geoCafConfig'];
    function AppCafServices($resource, geoCafConfig) {
        return $resource(geoCafConfig.apis.ban + ':address', {}, {
            locate: {
                method: 'GET',
                params: {}
            }
        });
    }
})();