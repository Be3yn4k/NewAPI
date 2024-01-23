using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Notes = new HashSet<Note>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
