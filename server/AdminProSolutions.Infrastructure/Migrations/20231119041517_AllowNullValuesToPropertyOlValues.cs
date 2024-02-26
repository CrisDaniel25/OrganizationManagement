using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullValuesToPropertyOlValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 689, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(1166),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 688, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(4294),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(3273),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(1580),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(513),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(8631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(3911),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(7785),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(4604),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(2820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(3651),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
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
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(652),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(6579));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 689, DateTimeKind.Utc).AddTicks(2395),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 688, DateTimeKind.Utc).AddTicks(8428),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 822, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(2983),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(1899),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(9807),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(8631),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 821, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(8756),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 820, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(8408),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(2820),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
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
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(7424),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(6579),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 19, 4, 15, 17, 819, DateTimeKind.Utc).AddTicks(652));
        }
    }
}
