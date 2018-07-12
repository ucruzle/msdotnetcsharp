(function () {
    'use strict';
    angular.module('app').controller('home', function ($scope, $rootScope, $location) {
       
        $scope.pageTitle = 'Home';
        $scope.message = 'chamada tela Inicial.';

        $(menuPrincipal).removeClass("escondeMenu");
        $(menuGerenciador).addClass("escondeMenu");

        $(document).ready(function () {
            $('.slider').slider({interval: 7000});
        });

    });
})();