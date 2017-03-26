'use strict';
app.controller('refreshController', ['$scope', '$location', 'localStorageService', 'authService', function ($scope, $location, localStorageService, authService) {

  $scope.authentication = authService.authentication;
  $scope.tokenRefreshed = false;
  $scope.tokenResponse = null;

  console.log($scope.authentication);

  $scope.refreshToken = function () {
      let authData = localStorageService.get('authorizationData');
      let oldRefreshToken = authData.refreshToken;

      authService.refreshToken().then(function (response) {
          $scope.tokenRefreshed = true;
          $scope.tokenResponse = response;

          // console.log(oldRefreshToken);
          // authService.deleteRefreshToken(oldRefreshToken);
      },
       function (err) {
           $location.path('/login');
       });
  };

}]);
