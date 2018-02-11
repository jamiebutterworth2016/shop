using DAL.DataModels;
using System.Data.Common;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=Context") { }

        public Context(DbConnection connection) : base(connection, true) { }

        public virtual DbSet<Product> Products { get; set; }
    }
}