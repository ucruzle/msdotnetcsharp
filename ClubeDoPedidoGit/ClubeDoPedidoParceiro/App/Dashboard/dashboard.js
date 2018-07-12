(function () {
    'use strict';
    angular.module('app').controller('dashboard', function ($scope) {

        $scope.pageTitle = 'Painel de controle';
        $scope.message = 'chada de tela dashboard.';

        $('.button-collapse').sideNav();


        var mainState = {
            name: 'main',
            views: {
                configuracao: 'ConfiguracaoComponent',
            }
        }
    });
})();