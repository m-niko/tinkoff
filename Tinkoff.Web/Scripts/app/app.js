var app = angular.module("app", ["ngRoute", "ngCookies", "shortenControllers", "shortenService"]);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/', {
            templateUrl: 'scripts/app/partials/shorten.html',
            controller: 'ShortenCreateCtrl'
        }).
        when('/allmyshortens', {
            templateUrl: 'scripts/app/partials/shorten-list.html',
            controller: 'ShortenListCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });
  }]);