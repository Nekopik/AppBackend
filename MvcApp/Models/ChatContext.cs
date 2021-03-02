using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {

        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
