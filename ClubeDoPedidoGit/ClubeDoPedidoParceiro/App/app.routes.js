//(function () {
//    'use strict';

//    var app = angular.module('app', ['ui.router']);

//    app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

//        $urlRouterProvider.otherwise('/');

//        $stateProvider
//            .when("home", {
//                url: "/",
//                templateUrl: "App/home/home.html",
//                controller: "home",
//            })
//            .when("dashboard", {
//                url: "/dashboard",
//                templateUrl: 'App/dashboard/dashboard.html',
//                controller: 'dashboard'
//            })
//            .when("loginParceiro", {
//                url: "/loginParceiro",
//                templateUrl: 'App/parceiro/loginParceiro.html',
//                controller: 'loginParceiro'
//            })
//            .when("ajuda", {
//                url: "/ajuda",
//                templateUrl: 'App/ajuda/ajuda.html',
//                controller: 'ajuda'
//            })
//            .when("configuracaoEmpresa", {
//                url: "/configuracaoEmpresa",
//                templateUrl: 'App/configuracao/empresa/configuracaoEmpresa.html',
//                controller: 'configuracaoEmpresa'
//            })
//            .when("saldo", {
//                url: "/saldo",
//                templateUrl: 'App/historico/saldo.html',
//                controller: 'saldo'
//            })
//            .when("venda", {
//                url: "/venda",
//                templateUrl: 'App/historico/venda.html',
//                controller: 'venda'
//            })
//            .when("chat", {
//                url: "/chat",
//                templateUrl: 'App/marketing/chat.html',
//                controller: 'chat'
//            })
//            .when("loja", {
//                url: "/loja",
//                templateUrl: 'App/marketing/loja.html',
//                controller: 'loja'
//            })
//            .when("promocao", {
//                url: "/promocao",
//                templateUrl: 'App/marketing/promocao.html',
//                controller: 'promocao'
//            })
//            .when("produto", {
//                url: "/produto",
//                templateUrl: 'App/cadastro/produto.html',
//                controller: 'produto'
//            })
//            .when("produtoNovo", {
//                url: "/produtoNovo",
//                templateUrl: 'App/cadastro/produtoNovo.html',
//                controller: 'produtoNovo'
//            })
//            .when("criarConta", {
//                url: "/criarConta",
//                templateUrl: 'App/parceiro/conta/criarConta.html',
//                controller: 'criarConta'
//            })
//             .when("loginUsuario", {
//                 url: "/loginUsuario",
//                 templateUrl: 'App/usuario/loginUsuario.html',
//                 controller: 'loginUsuario'
//            })
//             .when("estabelecimento", {
//                 url: "/estabelecimento",
//                 templateUrl: 'App/estabelecimento/estabelecimento.html',
//                 controller: 'estabelecimento'
//            });

//        $locationProvider.html5Mode(true);
//    });
//})();

(function () {

    'use strict';

    var app = angular.module('app', ['ngRoute']);

    app.config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(false);

        $routeProvider

        .when("/", {
            templateUrl: "App/home/home.html",
            controller: "home",
        })
        .when("/dashboard", {
            templateUrl: 'App/dashboard/dashboard.html',
            controller: 'dashboard'
        })
        .when("/loginParceiro", {
            templateUrl: 'App/parceiro/login/loginParceiro.html',
            controller: 'loginParceiro'
        })
        .when("/ajuda", {
            templateUrl: 'App/ajuda/ajuda.html',
            controller: 'ajuda'
        })
        .when("/configuracaoEmpresa", {
            templateUrl: 'App/configuracao/empresa/configuracaoEmpresa.html',
            controller: 'configuracaoEmpresa'
        })
        .when("/saldo", {
            templateUrl: 'App/historico/saldo.html',
            controller: 'saldo'
        })
        .when("/venda", {
            templateUrl: 'App/historico/venda.html',
            controller: 'venda'
        })
        .when("/chat", {
            templateUrl: 'App/marketing/chat.html',
            controller: 'chat'
        })
        .when("/loja", {
            templateUrl: 'App/marketing/loja.html',
            controller: 'loja'
        })
        .when("/promocao", {
            templateUrl: 'App/marketing/promocao.html',
            controller: 'promocao'
        })
        .when("/produto", {
            templateUrl: 'App/cadastro/produto.html',
            controller: 'produto'
        })
        .when("/produtoNovo", {
            templateUrl: 'App/cadastro/produtoNovo.html',
            controller: 'produtoNovo'
        })
        .when("/criarConta", {
            templateUrl: 'App/parceiro/conta/criarConta.html',
            controller: 'criarConta'
        })
        .when("/loginUsuario", {
            templateUrl: 'App/usuario/loginUsuario.html',
            controller: 'loginUsuario'
        })
        .when("/estabelecimento", {
            templateUrl: 'App/estabelecimento/estabelecimento.html',
            controller: 'estabelecimento'
        })

        // caso não seja nenhum desses, redirecione para a rota '/'
        .otherwise({ redirectTo: '/' });
    });

})();