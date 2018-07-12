(function () {
    "user strict";

    var service = angular.module('app');
    service.factory('parceiroService', function ($http, appConfig) {
        var constantRoute = appConfig.clubePedido_Api_Localhost + '/';

        /* CRIAR CONTA */
        var _criarConta = function (parceiro) {
            return $http.post(constantRoute + 'parceiro/cadastronovoparceiro', parceiro);
        };

        /* LOGIN PARCEIRO */
        var _getParceiros = function () {
            return $http.get(constantRoute + 'parceiro/buscaparceiros')
        };

        return {
            criarConta: _criarConta,
            getParceiros: _getParceiros
        }

    });
})();
