using SqliteDemo.Data.Entities;
using System.Data.Entity;

namespace SqliteDemo.Data
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext()
            : base("name=TicketsDbContext")
        {
        }

        public TicketsDbContext(string connectionStringName)
            : base($"name={connectionStringName}")
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasRequired<Ticket>(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey<int>(c => c.TicketId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired<AppUser>(c => c.CreatedBy)
                .WithMany(a => a.TicketsCreated)
                .HasForeignKey<int>(t => t.CreatedById)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Comment>()
                .HasRequired<AppUser>(c => c.CreatedBy)
                .WithMany(a => a.CommentsCreated)
                .HasForeignKey<int>(c => c.CreatedById)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}