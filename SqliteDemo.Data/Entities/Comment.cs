using System;

namespace SqliteDemo.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual AppUser CreatedBy { get; set; }
        public int CreatedById { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public static Comment Create(string text, int ticketId, int createdById)
        {
            return new Comment()
            {
                Text = text,
                TicketId = ticketId,
                CreatedById = createdById
            };
        }
    }
}
