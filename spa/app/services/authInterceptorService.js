'use strict';
app.factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {

  let authInterceptorServiceFactory = {};

  let _request = function (config) {

    config.headers = config.headers || {};

    let authData = localStorageService.get('authorizationData');
    if(authData) {
      config.headers.Authorization = "Bearer " + authData.token;
    }

    return config;
  };

  let _responseError = function (rejection) {
    if(rejection.status === 401) {

      let authService = $injector.get('authService');
      let authData = localStorageService.get('authorizationData');

      if (authData) {
        authService.refreshToken();
        //нужно подождать collback
        //$location.path('/refresh');
        return $q.reject(rejection);
      }
      authService.logOut();

      $location.path('/login');
    }
    return $q.reject(rejection);
  }

  authInterceptorServiceFactory.request = _request;
  authInterceptorServiceFactory.responseError = _responseError;

  return authInterceptorServiceFactory;

}]);
