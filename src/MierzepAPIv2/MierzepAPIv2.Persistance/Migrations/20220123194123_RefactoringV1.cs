using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MierzepAPIv2.Persistance.Migrations
{
    public partial class RefactoringV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 41, 22, 666, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 41, 22, 669, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 41, 22, 669, DateTimeKind.Local).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 41, 22, 669, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 41, 22, 669, DateTimeKind.Local).AddTicks(6760));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 33, 35, 291, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 33, 35, 295, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 33, 35, 295, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 33, 35, 295, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 1, 23, 20, 33, 35, 295, DateTimeKind.Local).AddTicks(524));
        }
    }
}
