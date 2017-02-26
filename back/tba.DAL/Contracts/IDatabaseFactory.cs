using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tba.Model;

namespace tba.DAL.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        TbaContext Get();
    }
}
