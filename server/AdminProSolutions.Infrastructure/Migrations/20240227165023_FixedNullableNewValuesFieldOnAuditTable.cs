using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedNullableNewValuesFieldOnAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 653, DateTimeKind.Utc).AddTicks(1200),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 652, DateTimeKind.Utc).AddTicks(7084),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(3057),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(1145),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(6069),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(2469),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(568),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(4333),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(2811),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(5902),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 657, DateTimeKind.Utc).AddTicks(625),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(8255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(1107),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(8817),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(8207),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(7292),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(7336),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(5854),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(1891));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 653, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 717, DateTimeKind.Utc).AddTicks(873),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 652, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(3008),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(1954),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 716, DateTimeKind.Utc).AddTicks(342),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(9299),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 715, DateTimeKind.Utc).AddTicks(698),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(9760),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 714, DateTimeKind.Utc).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(4333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(9889),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(5380),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 713, DateTimeKind.Utc).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(3600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(8255),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 657, DateTimeKind.Utc).AddTicks(625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(4666),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(7551),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(933),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 718, DateTimeKind.Utc).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(4441),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 27, 13, 27, 8, 711, DateTimeKind.Utc).AddTicks(1891),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(5854));
        }
    }
}
