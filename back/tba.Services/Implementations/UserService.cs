using System;
using System.Linq;
using tba.DAL.Contracts;
using tba.Model;
using tba.Model.DTO;
using tba.Repository;
using tba.Services.Contracts;

namespace tba.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public bool CreateUser(RegisterUserDTO userDto)
        {
            var user = new User();

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
            var user = users.FirstOrDefault(p => p.Id == userId);
            if (user == null)
                return null;
            else
            {
                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    PhoneConfirmed = user.PhoneConfirmed,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    DateRegistration = user.DateRegistration,
                    AccessFailedCount = user.AccessFailedCount
                };

                return userDto;
            }
        }

        public UserDTO FindUser(string userName)
        {
            var users = _userRepository.GetAll();
            var user = users.FirstOrDefault(p => p.UserName == userName);
            if (user == null)
                return null;
            else
            {
                var userDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    PhoneConfirmed = user.PhoneConfirmed,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    DateRegistration = user.DateRegistration,
                    AccessFailedCount = user.AccessFailedCount
                };

                return userDto;
            }
        }
    }
}
