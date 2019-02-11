function Initialize(apiBase) {
    apiBase = apiBase + '/products';
    var catalogApp = angular.module('CatalogApp', []);
    catalogApp.controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        $http.get(apiBase, { responseType: 'json' })
            .then(function (response) {
                $scope.products = response.data;
            }, function (ex, er) {
                alert(ex);
            });
    }]);
}