using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using tba.DAL.Contracts;
using tba.DAL.Implementations;
using tba.Model;
using tba.Repository;
using tba.Services.Contracts;
using tba.Services.Implementations;

namespace tba.API
{
    public class AuthRepository : IDisposable
    {
        private readonly IAuthService _authService;

        public AuthRepository()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IAuthService>().To<AuthService>();
            ninjectKernel.Bind<IDatabaseFactory>().To<DatabaseFactory>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IClientRepository>().To<ClientRepository>();
            ninjectKernel.Bind<IRefreshTokenRepository>().To<RefreshTokenRepository>();

            _authService = ninjectKernel.Get<IAuthService>();
        }

        #region Helpers

        public void Dispose()
        {
            //
        }

        #endregion

        #region User

        public User FindUser(string userName, string passwordHash)
        {
            var user = _authService.FindUser(userName, passwordHash);
            return user;
        }

        #endregion

        #region Client

        public Client FindClient(string clientId)
        {
            var client = _authService.FindClient(clientId);
            return client;
        }

        #endregion

        #region RefreshToken

        public bool AddRefreshToken(RefreshToken token)
        {
            var tokens = _authService.GetAllRefreshTokens();
            var existingToken = tokens.FirstOrDefault(p => p.Subject == token.Subject && p.ClientId == token.ClientId);

            if (existingToken != null)
                RemoveRefreshToken(token);

            _authService.AddRefreshToken(token);
            
            return true;
        }

        public bool RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = _authService.FindRefreshToken(refreshTokenId);

            if (refreshToken == null) return false;

            _authService.RemoveRefreshToken(refreshToken);
            return true;
        }

        public bool RemoveRefreshToken(RefreshToken refreshToken)
        {
            return _authService.RemoveRefreshToken(refreshToken);
            ;
        }

        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = _authService.FindRefreshToken(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _authService.GetAllRefreshTokens();
        }

        #endregion
    }
}