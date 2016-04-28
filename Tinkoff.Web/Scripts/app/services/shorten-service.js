var shortenService = angular.module("shortenService", ['ngResource', 'ngCookies']);

shortenService.factory("Shorten", [
    '$resource', function($resource) {
        return $resource('api/shorten', {}, {
            get: { method: 'GET', isArray: true }
         });
    }
]);

shortenService.factory("CookiesStore", [
    "$cookies", function($cookies) {
        var KEY = "rawUrls";
        return {
            get: function() {
                return  $cookies.getObject(KEY);
            },

            set: function(value) {
                var rawUrls = this.get();
                if (rawUrls === undefined) {
                    rawUrls = [];
                }

                if (rawUrls.indexOf(value) === -1) {
                    rawUrls.push(value);
                }

                $cookies.putObject(KEY, rawUrls);
            }
        }
    }
]);