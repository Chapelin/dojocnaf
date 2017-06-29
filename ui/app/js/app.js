//'use strict'

//var appGeoCaf = angular.module('geocafApp',[
//	"ngSanitize",
//	"ngProgress",
//	"ngResource",
//	"ui.bootstrap"
//	]).constant('geoCafConfig', {
//        "version": "0.0.1",
//        "apis": {
//            "ban": "https://api-adresse.data.gouv.fr/search/?q="
//        }
//	}
//);

(function () {
    'use strict';

    angular.module('appGeoCaf', [
        "ngSanitize",
        "ngProgress",
        "ngResource",
        "ui.bootstrap"
    ]).constant('geoCafConfig', {
        "version": "0.0.1",
        "apis": {
            "ban": "https://api-adresse.data.gouv.fr/search/?q=",
            "caf": "http://caffrmapback20170629041333.azurewebsites.net/api/POI"
        }
    });

    angular.module('appGeoCaf').run(appGeoCafRun);

    appGeoCafRun.$inject = ['$rootScope', 'ngProgressFactory'];
    function appGeoCafRun($rootScope, ngProgressFactory) {
        $rootScope.alerts = [];
        $rootScope.user = null;

        $rootScope.lang = 'fr';

        $rootScope.ngProgress = ngProgressFactory.createInstance();

        $rootScope.ngProgress.setColor('#000');
        $rootScope.ngProgress.setHeight('3px');
        
        $rootScope.closeAlert = function (index) {
            $rootScope.alerts.splice(index, 1);
        };

        $rootScope.closeError = function () {
            delete $rootScope.error;
        };

        $rootScope.closeSuccess = function () {
            delete $rootScope.success;
        };
    }
})();