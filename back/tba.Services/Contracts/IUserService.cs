using tba.Model.DTO;

namespace tba.Services.Contracts
{
    public interface IUserService
    {
        UserDTO FindUser(string userName);
        UserDTO FindUser(int userId);
        bool CreateUser(RegisterUserDTO user);
    }
}
