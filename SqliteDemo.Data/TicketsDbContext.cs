using System.Data.Entity;

namespace SqliteDemo.Data
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext()
            : base("name=TicketsDbContext")
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}