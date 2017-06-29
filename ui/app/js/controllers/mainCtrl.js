(function () {
    'use strict';

    angular.module('appGeoCaf').controller('MainCtrl', MainCtrl);

    MainCtrl.$inject = ['$scope', '$rootScope', '$filter', '$timeout', '$compile', '$modal', 'ngProgress', 'geoCafConfig', 'AppCafServices', 'AppBanServices'];
    function MainCtrl($scope, $rootScope, $filter, $timeout, $compile, $modal, ngProgress, geoCafConfig, AppCafServices, AppBanServices) {
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

        var markers = {
            agence: { color: 'blue', icon: 'building' },
            antenne: { color: 'brown', icon: 'wifi' },
            centre_impots: { color: 'magenta', icon: 'money' },
            cpam: { color: 'cyan', icon: 'cab' },
            mairie: { color: 'purple', icon: 'institution' },
            permanence: { color: 'yellow', icon: 'id-card' },
            pole_emploi: { color: 'green', icon: 'user-plus' },
            allocataire: { color: 'red', icon: 'user' }
        }

        // Paramétrage et définition de la map Leaflet
        var map = new L.Map('map', {
            layers: [basemap],
            center: [48.853, 2.35],
            zoom: 10,
            //minZoom: 10,
            //maxZoom: 15,
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

        var load_data = function (_adresse) {
            AppBanServices.locateAllocataire({ address: _adresse }, function (results) {
                console.log(results);
                var _tmp_data = {
                    adresse: results.features[0].properties.label,
                    lat: results.features[0].geometry.coordinates[1],
                    lon: results.features[0].geometry.coordinates[0]
                }
                load_marker(_tmp_data, markers.allocataire);
                $rootScope.ngProgress.complete();
            }, function (error) {
                $rootScope.ngProgress.reset();
                console.error('Erreur load_data(): ', error);
            });
        }

        var load_marker = function (result, marker_style) {
            if (marker_style == markers.antenne) {
                var content = '<div style="width:230px">' +
                    '<table class="table table-striped table-bordered table-condensed">' +
                    '<tr><th>Adresse</th><td><b>' + result.adresse + '</b></td></tr>' +
                    '</table>' +
                    '<div style="clear:both"></div>' +
                    '</div>';
            }

            var customMarker = null;

            if (marker_style == markers.pole_emploi) {
                customMarker = L.icon({
                    iconUrl: 'img/pole_emploi.png'
                });
            } else if (marker_style == markers.cpam) {
                customMarker = L.icon({
                    iconUrl: 'img/cpam.png'
                });
            } else {
                customMarker = L.AwesomeMarkers.icon({
                    icon: marker_style.icon,
                    markerColor: marker_style.color,
                    prefix: 'glyphicon',
                    iconColor: 'white'
                });
            }

            var marker = L.marker([result.lat, result.lon], {
                icon: customMarker,
                zIndexOffset: 500
            }).addTo(map);

            var linkFunction = $compile(angular.element(content)),
                newScope = $scope.$new();

            marker.bindPopup(linkFunction(newScope)[0], {
                maxWidth: "auto",
                closeButton: true
            });

            if (marker_style == markers.allocataire) {
                map.setView([result.lat, result.lon]);
            }
        }

        var getDataAllocataire = function () {
            // Appel API CAF
            AppCafServices.getAllocataire({}, function (result) {
                console.log("getDataAllocataire:", result);
                load_data(result.AdresseComplete);
                $rootScope.ngProgress.complete();
            }, function (error) {
                $rootScope.ngProgress.reset();
                console.error('Erreur appel au service : ', error);
            });
        }

        var getDataPOI = function () {
            AppCafServices.getPoi({}, function (results) {
                console.log("getDataPOI:", results);
                // TODO : add markers
                angular.forEach(results, function (result, key) {
                    var _tmp_data = {
                        adresse: result.AdresseComplete,
                        lat: result.X,
                        lon: result.Y
                    }
                    load_marker(_tmp_data, result.Type);
                });
                
                $rootScope.ngProgress.complete();
            }, function (error) {
                $rootScope.ngProgress.reset();
                console.error('Erreur appel au service : ', error);
            });
        }
       
        getDataAllocataire();
        getDataPOI();
    }
})();