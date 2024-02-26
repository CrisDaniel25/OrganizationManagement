using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTypes",
                columns: table => new
                {
                    AccessTypeId = table.Column<int>(type: "int", nullable: false),
                    AccessTypeDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AccessTypeStatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    AccessTypeIsDefault = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 598, DateTimeKind.Utc).AddTicks(8094)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 598, DateTimeKind.Utc).AddTicks(8474))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypes", x => x.AccessTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    FormModule = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FormName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FormDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(584)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(1162))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GroupDescription = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    ActiveDirectoryName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GroupStatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 600, DateTimeKind.Utc).AddTicks(4534)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 600, DateTimeKind.Utc).AddTicks(5157))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    UserLogin = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserStatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    UserSecretQuestion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    UserSecretAnswer = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserPasswordHasBeenReset = table.Column<bool>(type: "bit", nullable: true),
                    IsPasswordExpires = table.Column<bool>(type: "bit", nullable: true),
                    PasswordExpiresDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActiveDateBegin = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActiveDateEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 601, DateTimeKind.Utc).AddTicks(1953)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 601, DateTimeKind.Utc).AddTicks(2958)),
                    TypeAutentication = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "('AD')"),
                    HashPassword = table.Column<byte[]>(type: "varbinary(250)", maxLength: 250, nullable: false),
                    PasswordFailedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FormsAccessTypes",
                columns: table => new
                {
                    FormAccessTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    AccessTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(3469)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(3960))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsAccessTypes", x => x.FormAccessTypeId);
                    table.ForeignKey(
                        name: "FK_FormsAccessTypes_Forms",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "FormId");
                });

            migrationBuilder.CreateTable(
                name: "GroupsUsers",
                columns: table => new
                {
                    GroupUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 600, DateTimeKind.Utc).AddTicks(6140)),
                    UserOrder = table.Column<int>(type: "int", nullable: true),
                    IsSendInitialMail = table.Column<bool>(type: "bit", nullable: true),
                    IsSendAllTimeMail = table.Column<bool>(type: "bit", nullable: true),
                    IsSendTimeMail = table.Column<bool>(type: "bit", nullable: true),
                    TimeToSendMail = table.Column<int>(type: "int", nullable: true),
                    TimeType = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 600, DateTimeKind.Utc).AddTicks(6671)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUsers", x => x.GroupUserId);
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Groups",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupFormsAccessTypes",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FormAccessTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(9149)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2023, 8, 26, 0, 3, 5, 599, DateTimeKind.Utc).AddTicks(9549))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFormsAccessTypes", x => new { x.GroupId, x.FormAccessTypeId });
                    table.ForeignKey(
                        name: "FK_GroupFormsAccessTypes_FormsAccessTypes",
                        column: x => x.FormAccessTypeId,
                        principalTable: "FormsAccessTypes",
                        principalColumn: "FormAccessTypeId");
                    table.ForeignKey(
                        name: "FK_GroupFormsAccessTypes_Groups",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessTypes, UserId",
                table: "AccessTypes",
                column: "CreatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_FormsAccessTypes_FormId",
                table: "FormsAccessTypes",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFormsAccessTypes_FormAccessTypeId",
                table: "GroupFormsAccessTypes",
                column: "FormAccessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_GroupId",
                table: "GroupsUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_UserId",
                table: "GroupsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLogin",
                table: "Users",
                column: "UserLogin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTypes");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "GroupFormsAccessTypes");

            migrationBuilder.DropTable(
                name: "GroupsUsers");

            migrationBuilder.DropTable(
                name: "FormsAccessTypes");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
