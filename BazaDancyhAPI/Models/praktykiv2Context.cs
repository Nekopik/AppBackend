using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BazaDancyhAPI.Models
{
    public partial class praktykiv2Context : DbContext
    {
        public praktykiv2Context()
        {
        }

        public praktykiv2Context(DbContextOptions<praktykiv2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RCAI0TO\\SQLEXPRESS01;Database=praktyki v2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IsBlocked).HasColumnName("is-blocked");

                entity.Property(e => e.UsersId).HasColumnName("users-ID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contacts_users");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("conversation");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("channel-ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create-date");

                entity.Property(e => e.CreatorId).HasColumnName("creator-ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conversation_users");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("messages");

                entity.Property(e => e.AttachmentThumbUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("attachment-thumb-url");

                entity.Property(e => e.AttachmentUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("attachment-url");

                entity.Property(e => e.ConversationId).HasColumnName("conversation-ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create-date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.MessageType)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("message-type");

                entity.Property(e => e.UsersId).HasColumnName("users-ID");

                entity.HasOne(d => d.Conversation)
                    .WithMany()
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messages_conversation");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messages_users");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("participants");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ConversationId).HasColumnName("conversation-ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UsersId).HasColumnName("users-ID");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_participants_conversation");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_participants_users");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("reports");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create-date");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.ParticipantsId).HasColumnName("participants-ID");

                entity.Property(e => e.ReportType)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("report-type");

                entity.Property(e => e.UsersId).HasColumnName("users-ID");

                entity.HasOne(d => d.Participants)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ParticipantsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reports_participants");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reports_users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ContactsId).HasColumnName("contacts-ID");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("e-mail");

                entity.Property(e => e.Fristname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("fristname");

                entity.Property(e => e.IsActive).HasColumnName("is-active");

                entity.Property(e => e.IsReported).HasColumnName("is-reported");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.HasOne(d => d.ContactsNavigation)
                    .WithMany(p => p.UsersNavigation)
                    .HasForeignKey(d => d.ContactsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_contacts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
