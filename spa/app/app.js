var app = angular.module("authApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.config(function ($routeProvider) {

  $routeProvider.when("/home", {
    controller: "homeController",
    templateUrl: "/app/templates/home.html"
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

app.run(['authService', function (authService) {
  authService.fillAuthData();
}]);
