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
        private IAuthService _authService;

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
            //var users = _userRepository.GetAll().ToList();
            //var user = users.FirstOrDefault(p => p.UserName == userName && p.PasswordHash == passwordHash);
            //return user;
            return null;
        }

        #endregion

        #region Client

        //public Client FindClient(string clientId)
        //{
        //    var client = _clientRepository.GetById(clientId);

        //    return client;
        //}
        
        #endregion

        public void Dispose()
        {
            //
        }
    }
}