'use strict';
app.factory('tokensManagerService', ['$http', 'ngAuthSettings'], function ($http, ngAuthSettings) {
  let serviceBase = ngAuthSettings.apiServiceBaseUri;

  let tokensManagerService = {};

  let _deleteRefreshToken = function (tokenId) {
    return $http.delete(serviceBase + "api/refreshtokens?tokenid=" + tokenid).then(function (result) {
      return result;
    })
  }

  tokensManagerServiceFactory.deleteRefreshToken = _deleteRefreshToken;

  return tokensManagerServiceFactory;

});
