using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateModelAfterNuke2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d765a5e-30d9-4030-9a78-9b69338b9e39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa94a1b4-ac47-4ff7-9354-7aa669da2ed4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d577a5c2-d502-406f-9743-244f781f0f96", "59b7eea6-abe0-4bc6-9c4d-f1febf176335", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e59cb9d4-f30c-49f1-9a92-f1f63192f210", "27f20f58-d61e-475c-b0e5-0fbde10e7b29", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d577a5c2-d502-406f-9743-244f781f0f96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59cb9d4-f30c-49f1-9a92-f1f63192f210");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa94a1b4-ac47-4ff7-9354-7aa669da2ed4", "bbe17a29-3903-46fb-9d9e-08cfb3c8a0e0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d765a5e-30d9-4030-9a78-9b69338b9e39", "f0bba6d4-1176-453d-b799-8d830f351717", "Customer", "CUSTOMER" });
        }
    }
}
