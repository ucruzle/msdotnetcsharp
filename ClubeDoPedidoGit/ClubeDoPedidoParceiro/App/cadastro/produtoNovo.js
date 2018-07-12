(function () {
    'use strict';
    angular.module('app').controller('produtoNovo', function ($scope) {

        $scope.pageTitle = 'Inclusão de Produto';

        //Carrega Imagem
        document.getElementById("files").onchange = function () {
            var reader = new FileReader();

            reader.onload = function (e) {
                document.getElementById("image").src = e.target.result;
            };

            reader.readAsDataURL(this.files[0]);
        };

    });
})();