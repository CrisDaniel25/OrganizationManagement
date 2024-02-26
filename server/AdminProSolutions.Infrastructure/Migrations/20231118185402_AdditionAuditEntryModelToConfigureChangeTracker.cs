using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdditionAuditEntryModelToConfigureChangeTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 294, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 688, DateTimeKind.Utc).AddTicks(8428),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 294, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(2983),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 293, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(1899),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(9807),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(8631),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(8756),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 291, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 291, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(8408),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 289, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 289, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(2820),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(9538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(7424),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(6579),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 287, DateTimeKind.Utc).AddTicks(9504));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 294, DateTimeKind.Utc).AddTicks(6097),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 689, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 294, DateTimeKind.Utc).AddTicks(3806),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 688, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 293, DateTimeKind.Utc).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupsUsers",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(8996),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 687, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(6565),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Groups",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 292, DateTimeKind.Utc).AddTicks(5194),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 686, DateTimeKind.Utc).AddTicks(8631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 291, DateTimeKind.Utc).AddTicks(3131),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupFormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 291, DateTimeKind.Utc).AddTicks(1864),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 685, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 289, DateTimeKind.Utc).AddTicks(8585),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FormsAccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 289, DateTimeKind.Utc).AddTicks(6753),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(9538),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(2820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Forms",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(7648),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 684, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 288, DateTimeKind.Utc).AddTicks(797),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AccessTypes",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 2, 0, 18, 38, 287, DateTimeKind.Utc).AddTicks(9504),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 18, 18, 54, 2, 683, DateTimeKind.Utc).AddTicks(6579));
        }
    }
}
