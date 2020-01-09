using SqliteDemo.Data;
using System.Data.Entity;

namespace SqliteDemo.IntegrationTests
{
    public class SqlServerTicketsDbContext: TicketsDbContext
    {
        public SqlServerTicketsDbContext()
            : base("EfTicketsDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new DropCreateDatabaseIfModelChanges<SqlServerTicketsDbContext>();
            Database.SetInitializer(initializer);
            base.OnModelCreating(modelBuilder);
        }
    }
}
