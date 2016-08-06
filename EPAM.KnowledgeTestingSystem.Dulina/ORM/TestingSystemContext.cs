using System.Data.Entity;

namespace ORM
{
    public class TestingSystemContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
