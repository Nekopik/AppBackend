using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace MvcApp.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public string MessageType { get; set; }
        public string Message1 { get; set; }
        public string AttachmentThumbUrl { get; set; }
        public string AttachmentUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int UsersId { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual IdentityUser Users { get; set; }
    }
}
