using NUnit.Framework;
using SqliteDemo.Data.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace SqliteDemo.IntegrationTests
{
    [TestFixture]
    public class SqlServerTicketsDbContextTests
    {
        [SetUp]
        public void SetUp()
        {
            using (var context = new SqlServerTicketsDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Comments");
                context.Database.ExecuteSqlCommand("DELETE FROM Tickets");
                context.Database.ExecuteSqlCommand("DELETE FROM AppUsers");
            }
        }

        [Test]
        public void TicketsDbContext_CanBeCreated()
        {
            CreateAndCountTicket();
        }

        [Test] public void TicketsDbContext_CanBeCreated1() { CreateAndCountTicket(); }
        [Test] public void TicketsDbContext_CanBeCreated2() { CreateAndCountTicket(); }
        [Test] public void TicketsDbContext_CanBeCreated3() { CreateAndCountTicket(); }
        [Test] public void TicketsDbContext_CanBeCreated4() { CreateAndCountTicket(); }
        [Test] public void TicketsDbContext_CanBeCreated5() { CreateAndCountTicket(); }


        private static void CreateAndCountTicket()
        {
            using (var context = new SqlServerTicketsDbContext())
            {
                var appUser = context.AppUsers.Add(new AppUser());
                context.SaveChanges();

                var ticket = Ticket.Create("Title", "Details", appUser.AppUserId);

                ticket.AddComment("Some Comment", appUser.AppUserId);
                ticket.AddComment("Some Other Comment", appUser.AppUserId);

                context.Tickets.Add(ticket);
                context.SaveChanges();
            }

            using (var context = new SqlServerTicketsDbContext())
            {
                var ticket = context.Tickets
                    .Include(t => t.Comments)
                    .FirstOrDefault();

                Assert.That(ticket, Is.Not.Null);
                Assert.That(ticket.Comments.Count, Is.EqualTo(2));

                var ticketCount = context.Tickets.Count();
                Assert.That(ticketCount, Is.EqualTo(1));
            }
        }
    }
}
