using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullValuesToPropertyOldValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 533, DateTimeKind.Utc).AddTicks(3906),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 533, DateTimeKind.Utc).AddTicks(2131),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 532, DateTimeKind.Utc).AddTicks(2354),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 532, DateTimeKind.Utc).AddTicks(1446),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 531, DateTimeKind.Utc).AddTicks(9624),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 531, DateTimeKind.Utc).AddTicks(8545),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 530, DateTimeKind.Utc).AddTicks(5760),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 530, DateTimeKind.Utc).AddTicks(4906),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(8469),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(6860),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(8905),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(3708),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(2549),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(652));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(2364),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 533, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(1166),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 533, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(4294),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 532, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(3273),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 532, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(1580),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 531, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(513),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 531, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 530, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(3911),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 530, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(7785),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(4604),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 528, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(3651),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(8905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(652),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 26, 527, DateTimeKind.Utc).AddTicks(2549));
        }
    }
}
