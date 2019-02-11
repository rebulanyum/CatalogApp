function Initialize(apiBase, productId) {
    var catalogApp = angular.module('CatalogApp', ['uiCropper', 'imageFile']);
    catalogApp.controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        apiBase = apiBase + '/products/' + productId;

        $scope.product = {
            code: null,
            name: null,
            photo: null,
            price: null
        };
        $scope.croppedImage = null;
        $http.get(apiBase, { responseType: 'json' })
            .then(function (response) {
                if (response.data) {
                    response.data.photo = 'data:image/png;base64, ' + response.data.photo;
                }
                $scope.product = response.data;
            }, function (ex, er) {
                alert(ex);
            });
        $scope.save = function () {
            if ($scope.product.price > 999) {
                var result = window.confirm("The product price is more than 999. Do you wish to continue?");
                if (!result) {
                    return false;
                }
            }

            if ($scope.croppedImage) {
                var base64 = $scope.croppedImage.split(',');
                $scope.product.photo = base64[1].trim();
            } else {
                $scope.product.photo = null;
            }

            $http.put(apiBase, JSON.stringify($scope.product), { responseType: 'json' })
                .then(function (response) {
                    window.location.href = '/Product/View' + '/' + $scope.product.id;
                }, function (ex, er) {
                    alert(ex);
                });
            return false;
        };
    }]);
}