using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateCustomerSpecialtyPickupCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "373b684b-d745-4620-a468-cfcdb4615a23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b7d4352-2d84-4d47-821e-25c11c23854b");

            migrationBuilder.AddColumn<bool>(
                name: "SpecialtyPickupCompleted",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "084924b0-0978-4321-91e7-031848933631", "5012c251-be16-48eb-bc36-6e1f2a62b568", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18072986-f714-45ed-b12f-974d509a223a", "647b3d55-c127-4095-9f3b-54f9958aed3d", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084924b0-0978-4321-91e7-031848933631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18072986-f714-45ed-b12f-974d509a223a");

            migrationBuilder.DropColumn(
                name: "SpecialtyPickupCompleted",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "373b684b-d745-4620-a468-cfcdb4615a23", "dfc2bf02-d2f1-448e-81d2-2182e731df5f", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b7d4352-2d84-4d47-821e-25c11c23854b", "a7e236ff-faf8-4181-b231-a345eca60365", "Customer", "CUSTOMER" });
        }
    }
}
