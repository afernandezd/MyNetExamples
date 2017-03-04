using System.Data.Entity;
using AFD.Model;

namespace AFD.Data.EntityFramework
{
    public class JsonContext : DbContext
    {
        public DbSet<User> ObjUser { get; set; }
    }
}
