using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.Model;
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
