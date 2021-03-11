using System;
using System.Collections.Generic;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class Contact
    {
        public Contact()
        {
            UsersNavigation = new HashSet<User>();
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public byte IsBlocked { get; set; }

        public virtual User Users { get; set; }
        public virtual ICollection<User> UsersNavigation { get; set; }
    }
}
