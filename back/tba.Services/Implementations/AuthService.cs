using System;
using System.Collections.Generic;
using System.Linq;
using tba.DAL.Contracts;
using tba.Model;
using tba.Repository;
using tba.Services.Contracts;

namespace tba.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IClientRepository _clientRepository;

        public AuthService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IClientRepository clientRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            this._refreshTokenRepository = refreshTokenRepository;
            this._clientRepository = clientRepository;
        }

        #region User    

        public User FindUser(string userId)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int userId)
        {
            var users = _userRepository.GetAll();
            var user = users.FirstOrDefault(p => p.Id == userId);
            return user;
        }

        public User FindUser(string userName, string passwordHash)
        {
            var users = _userRepository.GetAll().ToList();
            var user = users.FirstOrDefault(p => p.UserName == userName && p.PasswordHash == passwordHash);
            return user;
        }

        #endregion

        #region Client

        public Client FindClient(string clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return client;
        }

        #endregion

        #region RefreshToken


        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = _refreshTokenRepository.GetById(refreshTokenId);
            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            var refreshTokens = _refreshTokenRepository.GetAll().ToList();
            return refreshTokens;
        }

        public bool RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = _refreshTokenRepository.GetById(refreshTokenId);

            if (refreshToken == null) return false;

            _refreshTokenRepository.Delete(refreshToken);
            _unitOfWork.Commit();

            return true;
        }

        public bool RemoveRefreshToken(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Delete(refreshToken);
            _unitOfWork.Commit();

            return true;
        }

        public void AddRefreshToken(RefreshToken token)
        {
            _refreshTokenRepository.Add(token);
        }

        #endregion
    }
}
