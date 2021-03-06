﻿using System;
using System.Collections.Generic;
using System.Linq;
using tba.DAL.Contracts;
using tba.DAL.Implementations;
using tba.Model;

namespace tba.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private TbaContext _dataContext;

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
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IUserRepository : IRepository<User>
    {
    }
}
