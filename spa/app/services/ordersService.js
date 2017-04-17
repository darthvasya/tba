'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

  let serviceBase = ngAuthSettings.apiServiceBaseUri;
  let ordersServiceFactory = {};

  let _getOrders = function () {

    return $http.get(serviceBase + "api/orders").then(function (results) {
      return results;
    });

  };

  ordersServiceFactory.getOrders = _getOrders;

  return ordersServiceFactory;

}]);
