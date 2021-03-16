﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcApp.Models;

namespace MvcApp.Migrations
{
    [DbContext(typeof(praktykiv2Context))]
    partial class praktykiv2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcApp.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<byte>("IsBlocked")
                        .HasColumnType("tinyint")
                        .HasColumnName("is-blocked");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users-ID");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("MvcApp.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("channel-ID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create-date");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("creator-ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("conversation");
                });

            modelBuilder.Entity("MvcApp.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentThumbUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("attachment-thumb-url");

                    b.Property<string>("AttachmentUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("attachment-url");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int")
                        .HasColumnName("conversation-ID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create-date");

                    b.Property<string>("Message1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("message");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("message-type");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users-ID");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UsersId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("MvcApp.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int")
                        .HasColumnName("conversation-ID");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users-ID");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UsersId");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("MvcApp.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create-date");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("notes");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int")
                        .HasColumnName("participants-ID");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("report-type");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("users-ID");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantsId");

                    b.HasIndex("UsersId");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("MvcApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("ContactsId")
                        .HasColumnType("int")
                        .HasColumnName("contacts-ID");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("e-mail");

                    b.Property<string>("Fristname")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fristname");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint")
                        .HasColumnName("is-active");

                    b.Property<byte>("IsReported")
                        .HasColumnType("tinyint")
                        .HasColumnName("is-reported");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("lastname");

                    b.Property<byte?>("Sex")
                        .HasColumnType("tinyint")
                        .HasColumnName("sex");

                    b.HasKey("Id");

                    b.HasIndex("ContactsId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MvcApp.Models.Contact", b =>
                {
                    b.HasOne("MvcApp.Models.User", "Users")
                        .WithMany("Contacts")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("FK_contacts_users")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MvcApp.Models.Conversation", b =>
                {
                    b.HasOne("MvcApp.Models.User", "Creator")
                        .WithMany("Conversations")
                        .HasForeignKey("CreatorId")
                        .HasConstraintName("FK_conversation_users")
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("MvcApp.Models.Message", b =>
                {
                    b.HasOne("MvcApp.Models.Conversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .HasConstraintName("FK_messages_conversation")
                        .IsRequired();

                    b.HasOne("MvcApp.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .HasConstraintName("FK_messages_users")
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MvcApp.Models.Participant", b =>
                {
                    b.HasOne("MvcApp.Models.Conversation", "Conversation")
                        .WithMany("Participants")
                        .HasForeignKey("ConversationId")
                        .HasConstraintName("FK_participants_conversation")
                        .IsRequired();

                    b.HasOne("MvcApp.Models.User", "Users")
                        .WithMany("Participants")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("FK_participants_users")
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MvcApp.Models.Report", b =>
                {
                    b.HasOne("MvcApp.Models.Participant", "Participants")
                        .WithMany("Reports")
                        .HasForeignKey("ParticipantsId")
                        .HasConstraintName("FK_reports_participants")
                        .IsRequired();

                    b.HasOne("MvcApp.Models.User", "Users")
                        .WithMany("Reports")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("FK_reports_users")
                        .IsRequired();

                    b.Navigation("Participants");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MvcApp.Models.User", b =>
                {
                    b.HasOne("MvcApp.Models.Contact", "ContactsNavigation")
                        .WithMany("UsersNavigation")
                        .HasForeignKey("ContactsId")
                        .HasConstraintName("FK_users_contacts")
                        .IsRequired();

                    b.Navigation("ContactsNavigation");
                });

            modelBuilder.Entity("MvcApp.Models.Contact", b =>
                {
                    b.Navigation("UsersNavigation");
                });

            modelBuilder.Entity("MvcApp.Models.Conversation", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("MvcApp.Models.Participant", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("MvcApp.Models.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Conversations");

                    b.Navigation("Participants");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}