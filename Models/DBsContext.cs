using Microsoft.EntityFrameworkCore;

namespace LineMonitoring.Models
{
    public class DBsContext : DbContext
    {
        public DBsContext(DbContextOptions<DBsContext> option) : base(option) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Graph> Graph { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Graph>()
                .HasData(new Graph()
                {
                    Id = 1,
                    Title = "Graph Title",
                    Line1 = "Label for Data 1",
                    Line2 = "Label for Data 2",
                    Data1 = "1,2,3,4,5,6,7,8,9,10,11,12",
                    Data2 = "0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,0.10,0.11,0.12",
                    Axis = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec"
                });
        }

    }
}