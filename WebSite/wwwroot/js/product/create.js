function Initialize(apiBase) {
    var catalogApp = angular.module('CatalogApp', ['uiCropper', 'imageFile']);
    catalogApp.controller('ProductsController', ['$scope', '$http', function ($scope, $http) {
        apiBase = apiBase + '/products';

        $scope.product = {
            code: null,
            name: null,
            photo: null,
            price: null
        };
        $scope.croppedImage = null;
        $scope.create = function () {
            if ($scope.product.price > 999) {
                var result = window.confirm("The product price is more than 999. Do you wish to continue?");
                if (!result) {
                    return false;
                }
            }

            if ($scope.croppedImage) {
                var base64 = $scope.croppedImage.split(',');
                $scope.product.photo = base64[1].trim();
            }

            $http.post(apiBase, JSON.stringify($scope.product), { responseType: 'json' })
                .then(function (response) {
                    window.location.href = '/Product/Index';
                }, function (ex, er) {
                    alert(ex);
                });
            return false;
        };
    }]);
}