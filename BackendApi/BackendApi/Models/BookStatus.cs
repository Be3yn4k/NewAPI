using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class BookStatus
    {
        public BookStatus()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
