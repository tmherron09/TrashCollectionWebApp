using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Data.Migrations
{
    public partial class Addnewroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86619797-f30f-4e0b-aa9a-e692f01f9d36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6a8b99e-3408-4f11-b290-b3df3d3b0865", "4c1ce0ac-e54e-4118-9d79-d64df08d5f5c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58a2218f-f62c-40c2-a710-f4113b1276d4", "61edf41d-a00b-4df6-bd25-97b2e51da9e0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1d12828-bd06-4f9e-afa1-8c6d8546ae2c", "87f271c1-0674-4676-8898-3a75b51ffbdc", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a2218f-f62c-40c2-a710-f4113b1276d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6a8b99e-3408-4f11-b290-b3df3d3b0865");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1d12828-bd06-4f9e-afa1-8c6d8546ae2c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86619797-f30f-4e0b-aa9a-e692f01f9d36", "83cb6869-ca5e-4f9a-a932-6e9615f9dc4d", "Admin", "ADMIN" });
        }
    }
}
