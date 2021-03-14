using System;
using System.Collections.Generic;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class Conversation
    {
        public Conversation()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public string ChannelId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
