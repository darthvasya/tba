using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.DAL.Contracts;
using tba.Model;
using tba.Repository;
using tba.Services.Contracts;

namespace tba.Services.Implementations
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public void CreateUser(User user)
        {

            if (user != null)
            {
                _userRepository.Add(user);
                _unitOfWork.Commit();
            }

        }

        public User FindUser(string userName, string password)
        {
            User user = new User { UserName = userName, PasswordHash = password };
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return user;
        }
    }
}
