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

        public bool CreateUser(RegisterUserDTO userDto)
        {
            User user = new User();

            if (userDto != null)
            {
                user.UserName = userDto.UserName;
                user.PasswordHash = userDto.PasswordHash;
                user.PhoneNumber = userDto.PhoneNumber;
                user.Email = userDto.Email;
                user.DateRegistration = DateTime.Now;

                _userRepository.Add(user);
                _unitOfWork.Commit();

                return true;
            }
            else
            {
                return false;
            }
        }

        public UserDTO FindUser(int userId)
        {
            var users = _userRepository.GetAll();
            User user = users.Where(p => p.Id == userId).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                UserDTO userDto = new UserDTO();
                userDto.Id = user.Id;
                userDto.UserName = user.UserName;
                userDto.PhoneNumber = user.PhoneNumber;
                userDto.PhoneConfirmed = user.PhoneConfirmed;
                userDto.Email = user.Email;
                userDto.EmailConfirmed = user.EmailConfirmed;
                userDto.DateRegistration = user.DateRegistration;
                userDto.AccessFailedCount = user.AccessFailedCount;

                return userDto;
            }
        }

        public UserDTO FindUser(string userName)
        {
            var users = _userRepository.GetAll();
            User user = users.Where(p => p.UserName == userName).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                UserDTO userDto = new UserDTO();
                userDto.Id = user.Id;
                userDto.UserName = user.UserName;
                userDto.PhoneNumber = user.PhoneNumber;
                userDto.PhoneConfirmed = user.PhoneConfirmed;
                userDto.Email = user.Email;
                userDto.EmailConfirmed = user.EmailConfirmed;
                userDto.DateRegistration = user.DateRegistration;
                userDto.AccessFailedCount = user.AccessFailedCount;

                return userDto;
            }
        }
    }
}
