using System;
using System.Collections.Generic;

namespace SqliteDemo.Data
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Comment> Comments { get; set; }

        public Ticket()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Comments = new List<Comment>();
        }

        public void AddComment(string commentText)
        {
            Comments.Add(Comment.Create(commentText, TicketId));
        }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public static Comment Create(string text, int ticketId)
        {
            return new Comment()
            {
                Text = text,
                TicketId = ticketId
            };
        }
    }
}
