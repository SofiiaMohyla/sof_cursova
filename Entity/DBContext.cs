using Microsoft.EntityFrameworkCore;

namespace sof_curs.Entity
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }

        public DBContext() : base() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
