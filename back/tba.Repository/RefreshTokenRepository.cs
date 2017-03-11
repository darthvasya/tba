using tba.DAL.Contracts;
using tba.DAL.Implementations;
using tba.Model;

namespace tba.Repository
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private TbaContext _dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public RefreshTokenRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected TbaContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
    }
}