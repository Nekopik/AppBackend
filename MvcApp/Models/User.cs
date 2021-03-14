using System;
using System.Collections.Generic;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
            Conversations = new HashSet<Conversation>();
            Participants = new HashSet<Participant>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string EMail { get; set; }
        public string Fristname { get; set; }
        public string Lastname { get; set; }
        public byte IsActive { get; set; }
        public byte IsReported { get; set; }
        public int ContactsId { get; set; }
        public byte? Sex { get; set; }

        public virtual Contact ContactsNavigation { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
