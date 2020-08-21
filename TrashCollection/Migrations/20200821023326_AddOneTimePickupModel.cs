using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class AddOneTimePickupModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c71f0e4-7333-4164-adcf-d1620dbb3aef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d21774e9-6359-448e-bcd0-98769b3bd36e");

            migrationBuilder.CreateTable(
                name: "OneTimePickups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDate = table.Column<DateTime>(nullable: false),
                    HasBeenPickedup = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimePickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimePickups_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OneTimePickups_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "373b684b-d745-4620-a468-cfcdb4615a23", "dfc2bf02-d2f1-448e-81d2-2182e731df5f", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b7d4352-2d84-4d47-821e-25c11c23854b", "a7e236ff-faf8-4181-b231-a345eca60365", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_OneTimePickups_CustomerId",
                table: "OneTimePickups",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimePickups_EmployeeId",
                table: "OneTimePickups",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneTimePickups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "373b684b-d745-4620-a468-cfcdb4615a23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b7d4352-2d84-4d47-821e-25c11c23854b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c71f0e4-7333-4164-adcf-d1620dbb3aef", "3a0c46ab-4a7f-4b97-b033-c4cabf95362e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d21774e9-6359-448e-bcd0-98769b3bd36e", "1b72fe26-9423-4317-a6d1-f79755e85d62", "Customer", "CUSTOMER" });
        }
    }
}
