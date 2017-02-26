using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.DAL.Contracts;
using tba.Model;

namespace tba.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private TbaContext dataContext;
        public TbaContext Get()
        {
            return dataContext ?? (dataContext = new TbaContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
