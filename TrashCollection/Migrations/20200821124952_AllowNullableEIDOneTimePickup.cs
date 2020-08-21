using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class AllowNullableEIDOneTimePickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2750bc28-4fe7-45d4-bbcc-407b7f0844dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7278eaa6-2c5b-4830-9a94-a62a501e3345");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc877c5d-39b2-4692-83d2-e7435c4b569b", "e93b712d-ac85-494a-a25f-ba6f5da8e86e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a62c11d1-5188-4495-9d64-759832b6d12d", "aa543996-6af6-4f82-80e9-e2fe79d08646", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62c11d1-5188-4495-9d64-759832b6d12d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc877c5d-39b2-4692-83d2-e7435c4b569b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2750bc28-4fe7-45d4-bbcc-407b7f0844dc", "49937dad-b10c-4a62-ae6a-c99afb746f12", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7278eaa6-2c5b-4830-9a94-a62a501e3345", "4447b6d8-0be8-4d57-a3bd-d931cd064900", "Customer", "CUSTOMER" });
        }
    }
}
