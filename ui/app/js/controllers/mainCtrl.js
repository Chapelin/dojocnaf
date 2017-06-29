(function () {
    'use strict';

    angular.module('appGeoCaf').controller('MainCtrl', MainCtrl);

    MainCtrl.$inject = ['$scope', '$filter', '$timeout', '$compile', '$modal', 'ngProgress', 'geoCafConfig', 'AppCafServices'];
    function MainCtrl($scope, $filter, $timeout, $compile, $modal, ngProgress, geoCafConfig, AppCafServices) {
        // Définition des variables AngularJS pour l'outil
        $scope.lang = "fr";
        $scope.version = geoCafConfig.version;
        $scope.loading = { value: false };
        $scope.filtres = {};
        $scope.display = {
            legend: false,
            polpo: false,
            cvip: false,
            cvi: false,
            acces: false,
            lvs: false,
            bon_plan: false,
            lien_transac: false
        };
        $scope.markers = [];
        $scope.alerts = [];

        var basemap = L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        });

        // Paramétrage et définition de la map Leaflet
        var map = new L.Map('map', {
            layers: [basemap],
            center: [48.853, 2.35],
            zoom: 10,
            minZoom: 10,
            maxZoom: 15,
            zoomControl: false
        });
        L.control.zoom({ position: 'topright' }).addTo(map);

        // Suppression des marqueurs passés en paramètre
        var unload_markers = function (list_markers) {
            list_markers.forEach(function (marker) {
                if (marker && marker != $scope.markers_selected) {
                    map.removeLayer(marker);
                }
            });
        };

        var load_data = function () {
            AppCafServices.locate({ address: "12 avenue henri fréville 35000 RENNES" }, function (results) {
                console.log(results);
                load_marker(results.features[0]);
                $scope.ngProgress.complete();
            }, function (error) {
                $rootScope.ngProgress.reset();
                console.error('Erreur load_data(): ', error);
            });
        }

        var load_marker = function (result) {
            var customMarker = L.AwesomeMarkers.icon({
                icon: 'user',
                markerColor: 'red',
                prefix: 'glyphicon',
                iconColor: 'white'
            });
            var marker = L.marker([result.geometry.coordinates[1], result.geometry.coordinates[0]], {
                icon: customMarker,
                zIndexOffset: 500
            }).addTo(map);

            var content = '<div style="width:230px">' +
                '<table class="table table-striped table-bordered table-condensed">' +
                '<tr><th>Adresse</th><td><b>' + result.properties.label + '</b></td></tr>';

            content += '</table>' +
                //'<button style="float:right;margin-top:5px" ng-click="setEtablissementAsSelected())">Sélectionner</button>' +
                '<div style="clear:both"></div>' +
                '</div>';

            var linkFunction = $compile(angular.element(content)),
                newScope = $scope.$new();

            marker.bindPopup(linkFunction(newScope)[0], {
                maxWidth: "auto",
                closeButton: true
            });

            map.setView([result.geometry.coordinates[1], result.geometry.coordinates[0]]);
        }

        load_data();
    }
})();