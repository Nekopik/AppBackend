using System;
using System.Collections.Generic;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ParticipantsId { get; set; }
        public string ReportType { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Participant Participants { get; set; }
        public virtual User Users { get; set; }
    }
}
