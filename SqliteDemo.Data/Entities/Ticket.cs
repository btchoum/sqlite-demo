using System;
using System.Collections.Generic;

namespace SqliteDemo.Data.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Comment> Comments { get; set; }

        public virtual AppUser CreatedBy { get; set; }
        public int CreatedById { get; set; }

        public virtual AppUser Owner { get; set; }
        public int? OwnerId { get; set; }

        public Ticket()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Comments = new List<Comment>();
        }

        public void AddComment(string commentText, int createdById)
        {
            Comments.Add(Comment.Create(commentText, TicketId, createdById));
        }

        public static Ticket Create(string title, string details, int createdById)
        {
            return new Ticket
            {
                Title = title,
                Details = details,
                CreatedById = createdById
            };
        }
    }
}
