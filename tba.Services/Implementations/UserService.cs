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

        public User FindUser(string userName, string password)
        {
            User user = new User { Id = 1, UserName = userName, Password = password };
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return user;
        }
    }
}
