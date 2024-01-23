using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int? BooksId { get; set; }
        public string? NoteText { get; set; }
        public DateTime? NoteDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Book? Books { get; set; }
        public virtual User Users { get; set; } = null!;
    }
}
