using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using tba.DAL.Contracts;
using tba.Model;
using tba.Model.DTO;
using tba.Repository;
using tba.Services.Contracts;
using tba.Common.Helpers;

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

        public bool CreateUser(UserDTO userDto)
        {
            User user = new User();

            if (userDto != null)
            {
                user.UserName = userDto.UserName;
                user.PhoneNumber = userDto.PhoneNumber;
                user.PasswordHash = Crypto.GetHash(userDto.Password);

                _userRepository.Add(user);
                _unitOfWork.Commit();

                return true;
            }
            else
            {
                return false;
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
