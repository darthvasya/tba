var app = angular.module("authApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

  $routeProvider.when("/home", {
    controller: "homeController",
    templateUrl: "/app/templates/home.html"
  });

  $routeProvider.when("/refresh", {
    controller: "refreshController",
    templateUrl: "/app/templates/refresh.html"
  });

  $routeProvider.when("/login", {
    controller: "loginController",
    templateUrl: "/app/templates/login.html"
  });

  $routeProvider.when("/signup", {
    controller: "signupController",
    templateUrl: "/app/templates/signup.html"
  });

  $routeProvider.when("/orders", {
      controller: "ordersController",
      templateUrl: "/app/templates/orders.html"
  });

  $routeProvider.otherwise({ redirectTo: "/home"});

});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: "http://localhost:58429/",
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
  authService.fillAuthData();
}]);
