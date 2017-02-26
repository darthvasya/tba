using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.DAL.Contracts;
using tba.DAL.Implementations;
using tba.Model;

namespace tba.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private TbaContext dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected TbaContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

    }

    public interface IUserRepository : IRepository<User>
    {
    }
}
