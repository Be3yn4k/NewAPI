using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UsersId { get; set; }
        public string Number { get; set; } = null!;
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
