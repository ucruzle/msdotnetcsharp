(function () {
    'use strict';
    
    var app = angular.module('app');
    app.controller().controller('criarConta', function ($scope, $rootScope, $location, $http, parceiroService) {

        $scope.pageTitle = 'Nova Conta Parceiro';

        $scope.ParceiroDto = {
            NomeFantasia: undefined,
            CpfCnpj: undefined,
            Email: undefined,
            Senha: undefined,
            ConfirmaSenha: undefined,
            Telefone: undefined,
            Celular: undefined,
            RamoAtividade: undefined,
            Endereco:{
                Cep: undefined,
                Logradouro: undefined,
                Numero: undefined,
                Complemento: undefined,
                Bairro: undefined,
                Cidade: undefined,
                Uf: undefined,
                PontoReferencia: undefined,
            },
            PlanoContratado:{
                PlanoID: undefined,
                QuantidadeProdutosPorPlano: undefined,
            }
        };

        var saveContaParceiro = function (parceiro) {
            parceiroService.criarConta(parceiro)
                .then(function (data) {
                    $scope.ParceiroDto = angular.copy(data);
                })
                .catch(function (erro) {
                   var testee = erro.data.exceptionMessage
                });
        };

        var getParceiro = function (parceiro) {
            parceiroService.getParceiros()
                .then(function (data) {
                    $scope.ParceiroDto = angular.copy(data);
                })
                .catch(function (data, status) {
                    var teste = data + status;
                });
        };

        $scope.Confirmar = function () {
            saveContaParceiro($scope.ParceiroDto);
        };

    });
})();