(function () {
    'use strict';
    angular.module('app').controller('loginParceiro', function ($scope, $rootScope, $location) {

        $scope.pageTitle = 'Autenticação de Usuário';
        $scope.message = 'Chamada de tela login.';

        $scope.mostrar = function () {
            $scope.mostrarMenuHome = false;
            $scope.mostrarMenuComoFunciona = false;
            $scope.mostrarMenuEntrar = false;
        };

       
        $scope.RedirecionarPagina = function () {
            $(menuPrincipal).addClass("escondeMenu");
            $(menuGerenciador).removeClass("escondeMenu");
            $location.path('/dashboard');
        }
        
        $scope.RedirecionarPaginaCriarConta = function () {
            $location.path('/criarConta');
        }

        $(document).ready(function () {
            $('.tooltipped').tooltip({ delay: 50 });
        });
        
    });
})();