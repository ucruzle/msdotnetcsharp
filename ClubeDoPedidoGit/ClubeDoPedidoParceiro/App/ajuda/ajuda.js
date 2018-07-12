(function () {
    'use strict';
    angular.module('app').controller('ajuda', function ($scope) {

        $scope.pageTitle = 'Como Funciona';
        $scope.message = 'chamada tela ajuda sobre funcionamento de app.';

        $(document).ready(function () {
            $('.slider').slider({ interval: 7000 });
        });

    });
})();