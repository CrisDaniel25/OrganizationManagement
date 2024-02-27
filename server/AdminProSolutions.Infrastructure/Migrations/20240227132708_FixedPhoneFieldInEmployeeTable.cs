using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedPhoneFieldInEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(2484),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(873),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(3008),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(1954),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(342),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(9299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 92, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(698),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(9760),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(9889),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(5380),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(8255),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(4666),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(7551),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(933),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(4441),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(1891),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 88, DateTimeKind.Utc).AddTicks(9932));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(7247),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(3939),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(2639),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(52),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 92, DateTimeKind.Utc).AddTicks(8657),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(7081),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(5936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(2596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(8482),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(7055),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(7561),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(8255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(6608),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7948),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7390),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(909),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 88, DateTimeKind.Utc).AddTicks(9932),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(1891));
        }
    }
}
