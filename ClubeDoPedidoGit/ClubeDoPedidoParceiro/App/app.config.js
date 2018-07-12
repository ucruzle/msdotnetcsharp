(function () {
    'use strict';
    var service = angular.module('app');

    service.constant('appConfig', {
        clubePedido_Api_Domain: 'http://localhost:9091',
        clubePedido_Api_Localhost: 'http://localhost:50820'
    });
}());