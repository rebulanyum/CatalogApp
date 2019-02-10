(function () {
    'use strict';

    angular.module('imageFile', [])
        .directive("imageFile", function () {
            return {
                //require: 'ngModel',
                restrict: 'E',
                scope: {
                    data: '=ngModel'
                },
                template: '<input type="file"></input>',
                link: function (scope, element, attr) {
                    element.on('change', function (evt) {
                        var file = angular.element(evt.currentTarget).contents()[0].files[0];
                        var reader = new FileReader();
                        reader.onload = function (evt) {
                            scope.data = evt.target.result;
                            scope.$apply();
                        };
                        reader.readAsDataURL(file);
                    });
                }
            };
        });
})();