using SQLite.CodeFirst;
using SqliteDemo.Data;
using System.Data.Entity;

namespace SqliteDemo.IntegrationTests
{
    public class SqLiteTicketsDbContext : TicketsDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new SqliteDropCreateDatabaseWhenModelChanges<SqLiteTicketsDbContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}
