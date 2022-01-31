using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MierzepAPIv2.Persistance.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Created", "CreatedBy", "InActivated", "InActivatedBy", "Modified", "ModifiedBy", "StatusId", "PersonName_FirstName", "PersonName_LastName" },
                values: new object[] { 1, new DateTime(2022, 1, 23, 1, 33, 25, 998, DateTimeKind.Local).AddTicks(1390), null, null, null, null, null, 0, "Patryk", "Mierzejewski" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Zdrowie" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Biznes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
