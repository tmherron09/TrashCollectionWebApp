using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateCustomerForDates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c7549eb-d14d-4c75-ae8d-96bff478606d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46dbbc4-8ea0-4153-a707-af227d93ae4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c71f0e4-7333-4164-adcf-d1620dbb3aef", "3a0c46ab-4a7f-4b97-b033-c4cabf95362e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d21774e9-6359-448e-bcd0-98769b3bd36e", "1b72fe26-9423-4317-a6d1-f79755e85d62", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c71f0e4-7333-4164-adcf-d1620dbb3aef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d21774e9-6359-448e-bcd0-98769b3bd36e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c7549eb-d14d-4c75-ae8d-96bff478606d", "d34086d9-495b-4904-931b-4c890ed99984", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e46dbbc4-8ea0-4153-a707-af227d93ae4a", "e78e90de-85b8-4e11-ae62-3f95ad7e2bbf", "Customer", "CUSTOMER" });
        }
    }
}
