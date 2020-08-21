using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateCustomerSpecialtyPickupCompletedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084924b0-0978-4321-91e7-031848933631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18072986-f714-45ed-b12f-974d509a223a");

            migrationBuilder.AlterColumn<bool>(
                name: "SpecialtyPickupCompleted",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f408de7c-8478-4ac6-ab09-f775bb5dacdd", "6f6e603d-01fa-4901-ba00-db17440f51fb", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fbb8d52-0063-4ab2-b43f-9a5515f249af", "92ab7ec9-2de3-498c-8f46-1e64a3f17bd8", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fbb8d52-0063-4ab2-b43f-9a5515f249af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f408de7c-8478-4ac6-ab09-f775bb5dacdd");

            migrationBuilder.AlterColumn<bool>(
                name: "SpecialtyPickupCompleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "084924b0-0978-4321-91e7-031848933631", "5012c251-be16-48eb-bc36-6e1f2a62b568", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18072986-f714-45ed-b12f-974d509a223a", "647b3d55-c127-4095-9f3b-54f9958aed3d", "Customer", "CUSTOMER" });
        }
    }
}
