using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        #region User

        public User FindUser(string userName, string passwordHash)
        {
            var user = _authService.FindUser(userName, passwordHash);
            return user;
        }

        #endregion

        #region Client
        
        #endregion

        public void Dispose()
        {
            //
        }
    }
}