using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext() : base("DbConnection") { }
    }
}
