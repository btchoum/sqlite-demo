using NUnit.Framework;
using SqliteDemo.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace SqliteDemo.IntegrationTests
{
    [TestFixture]
    public class TicketsDbContextTests
    {
        [SetUp]
        public void SetUp()
        {
            using (var context = new SqLiteTicketsDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Comments");
                context.Database.ExecuteSqlCommand("DELETE FROM Tickets");
            }
        }

        [Test]
        public void TicketsDbContext_CanBeCreated()
        {
            CreateAndCountTicket();
        }

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

                ticket.AddComment("Some Comment");
                ticket.AddComment("Some Other Comment");

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
