using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class AddDefaultEmployeeTestCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f9f14b35-857b-43d6-9617-0062ae0a77cb", "5ff43569-5758-4b23-b3d5-d14cab74abfd", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60201510-eec8-4bd1-aa46-392ebb8eab25", "c0930c8c-6e65-4e9e-8d2c-2eb75a263498", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AssignedZipCode", "EmailAddress", "FamilyName", "FirstName", "IdentityUserId", "PhoneNumber" },
                values: new object[] { 1, "00000", "default@trash.com", "Fail Case", "Default Employee", null, "555-555-5555" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60201510-eec8-4bd1-aa46-392ebb8eab25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9f14b35-857b-43d6-9617-0062ae0a77cb");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc877c5d-39b2-4692-83d2-e7435c4b569b", "e93b712d-ac85-494a-a25f-ba6f5da8e86e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a62c11d1-5188-4495-9d64-759832b6d12d", "aa543996-6af6-4f82-80e9-e2fe79d08646", "Customer", "CUSTOMER" });
        }
    }
}
