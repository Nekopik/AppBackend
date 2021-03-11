using System;
using System.Collections.Generic;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class Participant
    {
        public Participant()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int ConversationId { get; set; }
        public int UsersId { get; set; }
        public string Type { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
