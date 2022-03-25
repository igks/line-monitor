using Microsoft.EntityFrameworkCore;

namespace LineMonitoring.Models
{
    public class DBsContext : DbContext
    {
        public DBsContext(DbContextOptions<DBsContext> option) : base(option) { }

        public DbSet<Employee> Employee { get; set; }

    }
}