using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.Model;

namespace tba.Services.Contracts
{
    public interface IAuthService
    {
        User FindUser(string userId);
        User FindUser(int userId);
        User FindUser(string userName, string passwordHash);
    }
}
