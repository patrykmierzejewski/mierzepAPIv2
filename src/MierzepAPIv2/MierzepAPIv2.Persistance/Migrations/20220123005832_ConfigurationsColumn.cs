using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MierzepAPIv2.Persistance.Migrations
{
    public partial class ConfigurationsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonName_LastName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PersonName_FirstName",
                table: "Authors",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Texts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "Empty",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 1, 58, 32, 294, DateTimeKind.Local).AddTicks(3440));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "PersonName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "PersonName_FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Texts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "Empty");

            migrationBuilder.AlterColumn<string>(
                name: "PersonName_LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName_FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 1, 33, 25, 998, DateTimeKind.Local).AddTicks(1390));
        }
    }
}
