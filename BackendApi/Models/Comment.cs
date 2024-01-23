using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UsersId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CommentDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
