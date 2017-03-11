using tba.DAL.Contracts;
using tba.DAL.Implementations;
using tba.Model;

namespace tba.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private TbaContext _dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ClientRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected TbaContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());
    }

    public interface IClientRepository : IRepository<Client>
    {
    }
}
