'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
  let serviceBase = 'http://localhost:58429/';
  let authServiceFactory = {};

  let _authentification = {
    isAuth: false,
    userName: ""
  };

  let _saveRegistration = function (registration) {

    _logOut();

    return $http.post(serviceBase + "api/account/register", registration).then(function (response) {
      return response;
    });

  };

  let _login = function (loginData) {

    let data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

    let deferred = $q.defer();

    $http.post(serviceBase + "token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded'} })
    .success(function (response) {

      localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

      _authentification.isAuth = true;
      _authentification.userName = loginData.userName;

      deferred.resolve(response);
    }).error(function (err, status) {
      //logout
      deferred.reject(err);
    });

    return deferred.promise;

  };

  let _logOut = function () {

    localStorageService.remove('authorizationData');

    _authentification.isAuth = false;
    _authentification.userName = "";

  };

  let _fillAuthData = function () {

    let authData = localStorageService.get('authorizationData');
    if(authData)
    {
      _authentification.isAuth = true;
      _authentification.userName = authData.userName;
    }

  };

  authServiceFactory.saveRegistration = _saveRegistration;
  authServiceFactory.login = _login;
  authServiceFactory.logOut = _logOut;
  authServiceFactory.fillAuthData = _fillAuthData;
  authServiceFactory.authentification = _authentification;

  return authServiceFactory;

}]);
