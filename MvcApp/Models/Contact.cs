using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace MvcApp.Models
{
    public partial class Contact
    {
        public Contact()
        {
            UsersNavigation = new HashSet<IdentityUser>();
        }

        public int Id { get; set; }
        public string UsersId { get; set; }
        public byte IsBlocked { get; set; }

        public virtual IdentityUser Users { get; set; }
        public virtual ICollection<IdentityUser> UsersNavigation { get; set; }
    }
}
