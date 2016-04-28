var shortenControllers = angular.module('shortenControllers', []);

shortenControllers.controller("ShortenCreateCtrl", ["$scope", "CookiesStore", "Shorten" ,function ($scope, CookiesStore, Shorten) {
    $scope.title = "SHORTEN. SHARE. MEASURE.";

    $scope.shorten = { rawUrl: "" };
   
    $scope.submit = function() {
        if ($scope.shortenForm.$valid) {
             Shorten.save(JSON.stringify($scope.shorten.rawUrl)
                , function(data) {
                    $scope.shorted = data;
                     CookiesStore.set($scope.shorten.rawUrl);
                 }, function(error) {
                    console.log(error);
                });
        }
    }
}]);

shortenControllers.controller("ShortenListCtrl", ["$scope", "CookiesStore", "Shorten", function ($scope, CookiesStore, Shorten) {
    $scope.title = "All my shorted urls";

    Shorten.get({"rawUrls[]": CookiesStore.get()}, function(data) {
            $scope.shortedList = data;
        }, function(error) {
            console.log(error);
        });
}]);