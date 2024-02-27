using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdditionAndStructureOfClientsAndEmployeesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5978),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 120, DateTimeKind.Utc).AddTicks(2064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5199),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 119, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(1086),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(9246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(5706));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(9297),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(8790),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 115, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4597),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 113, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4156),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 112, DateTimeKind.Utc).AddTicks(9258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 110, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 110, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 108, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 108, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5417),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 107, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5028),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 107, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanySize = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(9913)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(198))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(2192)),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3535)),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3921))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Client",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClientId",
                table: "Employees",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityDocument",
                table: "Employees",
                column: "IdentityDocument",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 120, DateTimeKind.Utc).AddTicks(2064),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 119, DateTimeKind.Utc).AddTicks(8888),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(9246),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(5706),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 116, DateTimeKind.Utc).AddTicks(1596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(9297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 115, DateTimeKind.Utc).AddTicks(8566),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 113, DateTimeKind.Utc).AddTicks(4801),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 112, DateTimeKind.Utc).AddTicks(9258),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 110, DateTimeKind.Utc).AddTicks(2831),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 110, DateTimeKind.Utc).AddTicks(223),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 108, DateTimeKind.Utc).AddTicks(7962),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 108, DateTimeKind.Utc).AddTicks(5938),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 107, DateTimeKind.Utc).AddTicks(4500),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 24, 12, 55, 4, 107, DateTimeKind.Utc).AddTicks(1696),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5028));
        }
    }
}
