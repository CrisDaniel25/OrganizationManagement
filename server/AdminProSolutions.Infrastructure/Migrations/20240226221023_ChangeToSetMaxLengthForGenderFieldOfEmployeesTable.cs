using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToSetMaxLengthForGenderFieldOfEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(3939),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(2639),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(52),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(9297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 92, DateTimeKind.Utc).AddTicks(8657),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(7081),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(5936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(2596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(8482),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(7055),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(7561),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(6608),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7948),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7390),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(909),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 88, DateTimeKind.Utc).AddTicks(9932),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5028));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(5199),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 94, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(1086),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(9297),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 93, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(8790),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 92, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4597),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 177, DateTimeKind.Utc).AddTicks(4156),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 91, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 90, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3921),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(2192),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(3535),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 96, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 179, DateTimeKind.Utc).AddTicks(198),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 178, DateTimeKind.Utc).AddTicks(9913),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 95, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5417),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 89, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 26, 21, 44, 17, 176, DateTimeKind.Utc).AddTicks(5028),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 26, 22, 10, 23, 88, DateTimeKind.Utc).AddTicks(9932));
        }
    }
}
