using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8beb10f2-822f-4a20-9ffe-45bad028ddfa", "5322f39f-2c34-40ce-b550-8bba7ab50794", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d021029-1acd-4580-8ab8-6a6dbda16aaf", "1aeaa94d-f685-4da6-a6b0-187a832ac397", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d021029-1acd-4580-8ab8-6a6dbda16aaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8beb10f2-822f-4a20-9ffe-45bad028ddfa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d577a5c2-d502-406f-9743-244f781f0f96", "59b7eea6-abe0-4bc6-9c4d-f1febf176335", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e59cb9d4-f30c-49f1-9a92-f1f63192f210", "27f20f58-d61e-475c-b0e5-0fbde10e7b29", "Customer", "CUSTOMER" });
        }
    }
}
