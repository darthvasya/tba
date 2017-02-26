'use strict';
app.factory('ordersService', ['$http', function ($http) {

  let serviceBase = "http://localhost:58429/";
  let ordersServiceFactory = {};

  let _getOrders = function () {

    return $http.get(serviceBase + "api/orders").then(function (results) {
      return results;
    });

  };

  ordersServiceFactory.getOrders = _getOrders;

  return ordersServiceFactory;

}]);
