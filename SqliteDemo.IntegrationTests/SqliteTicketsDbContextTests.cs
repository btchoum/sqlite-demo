using NUnit.Framework;
using SqliteDemo.Data;
using SqliteDemo.Data.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace SqliteDemo.IntegrationTests
{
    [TestFixture]
    public class SqliteTicketsDbContextTests
    {
        [SetUp]
        public void SetUp()
        {
            using (var context = new SqLiteTicketsDbContext())
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
            using (var context = new SqLiteTicketsDbContext())
            {

                var ticket = new Ticket
                {
                    Title = "Title",
                    Details = "Details",
                    CreatedAt = DateTime.Now
                };

                ticket.AddComment("Some Comment", -1);
                ticket.AddComment("Some Other Comment", -1);

                context.Tickets.Add(ticket);
                context.SaveChanges();
            }

            using (var context = new SqLiteTicketsDbContext())
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
