using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateEmployeeModelForRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1503d399-0e02-4364-b5cf-52976e38e63f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "616dd616-40ba-4952-9c43-b132be65e82d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3455fc1c-31d7-42ce-beef-08161592d1ef", "239a82bf-d168-4f2c-bc5b-7b349621631a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1167d658-c911-488b-95c2-48bc173494f3", "e50ac383-0a26-442a-b1cc-9c60891d1564", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1167d658-c911-488b-95c2-48bc173494f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3455fc1c-31d7-42ce-beef-08161592d1ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1503d399-0e02-4364-b5cf-52976e38e63f", "10196d55-551e-41aa-a6b3-b2fd68ab3f87", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "616dd616-40ba-4952-9c43-b132be65e82d", "3090e6e3-4a55-4908-b5e2-148c901011f7", "Customer", "CUSTOMER" });
        }
    }
}
