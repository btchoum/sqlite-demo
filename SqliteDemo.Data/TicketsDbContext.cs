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
            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.CreatedBy)
                .WithMany(u => u.TicketsCreated)
                .HasForeignKey(t => t.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasOptional(t => t.Owner)
                .WithMany(u => u.TicketsOwned)
                .HasForeignKey(t => t.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(t => t.CreatedBy)
                .WithMany(u => u.CommentsCreated)
                .HasForeignKey(t => t.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(t => t.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}