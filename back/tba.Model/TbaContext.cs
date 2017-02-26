using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tba.Model
{
    public class TbaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TbaContext()
            : base("DefaultConnection")
        {

        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
