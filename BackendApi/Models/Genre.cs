using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
