using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Book
    {
        public Book()
        {
            Comments = new HashSet<Comment>();
            Notes = new HashSet<Note>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int GenreId { get; set; }
        public int BookStatusId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublicationDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual BookStatus BookStatus { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
