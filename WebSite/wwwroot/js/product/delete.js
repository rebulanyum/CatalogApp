function Initialize(apiBase, productId) {
    apiBase = apiBase + '/products/' + productId;
    var catalogApp = angular.module('CatalogApp', []);
    catalogApp.controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        $http.get(apiBase, { responseType: 'json' })
            .then(function (response) {
                if (response.data) {
                    response.data.photo = 'data:image/png;base64, ' + response.data.photo;
                }
                $scope.product = response.data;
            }, function (ex, er) {
                alert(ex);
            });
        $scope.delete = function () {
            $http.delete(apiBase, { responseType: 'json' })
                .then(function (response) {
                    window.location.href = '/Product/Index';
                }, function (ex, er) {
                    alert(ex);
                });
            return false;
        };
    }]);
}