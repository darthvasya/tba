using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tba.DAL.Implementations;
using tba.Model;
using tba.Repository;
using tba.Services.Contracts;
using tba.Services.Implementations;

namespace tba.API
{
    public class AuthRepository : IDisposable
    {
        private TbaContext _context;
        private UserRepository _userRepository;

        public AuthRepository()
        {
            _context = new TbaContext();
            _userRepository = new UserRepository(new DatabaseFactory());
        }

        public User FindUser(string userName, string password)
        {
            List<User> users = _userRepository.GetAll().ToList<User>();
            User user = users.Where(p => p.UserName == userName && p.Password == password).FirstOrDefault();
            if (user != null)
                return user;
            return null;
        }

        public void Dispose()
        {
            _context.Dispose();
            //
        }
    }
}