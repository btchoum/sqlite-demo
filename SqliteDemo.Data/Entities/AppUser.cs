using System.Collections.Generic;

namespace SqliteDemo.Data.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Ticket> TicketsCreated { get; internal set; }
        public ICollection<Ticket> TicketsOwned { get; internal set; }
        public ICollection<Comment> CommentsCreated { get; internal set; }
    }
}
