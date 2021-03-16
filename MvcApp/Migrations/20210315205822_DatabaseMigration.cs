using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcApp.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(name: "e-mail", type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    fristname = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    lastname = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    isactive = table.Column<byte>(name: "is-active", type: "tinyint", nullable: false),
                    isreported = table.Column<byte>(name: "is-reported", type: "tinyint", nullable: false),
                    contactsID = table.Column<int>(name: "contacts-ID", type: "int", nullable: false),
                    sex = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    usersID = table.Column<int>(name: "users-ID", type: "int", nullable: false),
                    isblocked = table.Column<byte>(name: "is-blocked", type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_contacts_users",
                        column: x => x.usersID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conversation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    creatorID = table.Column<int>(name: "creator-ID", type: "int", nullable: false),
                    channelID = table.Column<string>(name: "channel-ID", type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    createdate = table.Column<DateTime>(name: "create-date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_conversation_users",
                        column: x => x.creatorID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conversationID = table.Column<int>(name: "conversation-ID", type: "int", nullable: false),
                    messagetype = table.Column<string>(name: "message-type", type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    message = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    attachmentthumburl = table.Column<string>(name: "attachment-thumb-url", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    attachmenturl = table.Column<string>(name: "attachment-url", type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    createdate = table.Column<DateTime>(name: "create-date", type: "datetime", nullable: false),
                    usersID = table.Column<int>(name: "users-ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_messages_conversation",
                        column: x => x.conversationID,
                        principalTable: "conversation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_users",
                        column: x => x.usersID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    conversationID = table.Column<int>(name: "conversation-ID", type: "int", nullable: false),
                    usersID = table.Column<int>(name: "users-ID", type: "int", nullable: false),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_participants_conversation",
                        column: x => x.conversationID,
                        principalTable: "conversation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_participants_users",
                        column: x => x.usersID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    usersID = table.Column<int>(name: "users-ID", type: "int", nullable: false),
                    participantsID = table.Column<int>(name: "participants-ID", type: "int", nullable: false),
                    reporttype = table.Column<string>(name: "report-type", type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false),
                    createdate = table.Column<DateTime>(name: "create-date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_reports_participants",
                        column: x => x.participantsID,
                        principalTable: "participants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reports_users",
                        column: x => x.usersID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_users-ID",
                table: "contacts",
                column: "users-ID");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_creator-ID",
                table: "conversation",
                column: "creator-ID");

            migrationBuilder.CreateIndex(
                name: "IX_messages_conversation-ID",
                table: "messages",
                column: "conversation-ID");

            migrationBuilder.CreateIndex(
                name: "IX_messages_users-ID",
                table: "messages",
                column: "users-ID");

            migrationBuilder.CreateIndex(
                name: "IX_participants_conversation-ID",
                table: "participants",
                column: "conversation-ID");

            migrationBuilder.CreateIndex(
                name: "IX_participants_users-ID",
                table: "participants",
                column: "users-ID");

            migrationBuilder.CreateIndex(
                name: "IX_reports_participants-ID",
                table: "reports",
                column: "participants-ID");

            migrationBuilder.CreateIndex(
                name: "IX_reports_users-ID",
                table: "reports",
                column: "users-ID");

            migrationBuilder.CreateIndex(
                name: "IX_users_contacts-ID",
                table: "users",
                column: "contacts-ID");

            migrationBuilder.AddForeignKey(
                name: "FK_users_contacts",
                table: "users",
                column: "contacts-ID",
                principalTable: "contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "conversation");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
