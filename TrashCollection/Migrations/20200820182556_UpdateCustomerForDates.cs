using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdateCustomerForDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1167d658-c911-488b-95c2-48bc173494f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3455fc1c-31d7-42ce-beef-08161592d1ef");

            migrationBuilder.DropColumn(
                name: "SpecialtyPickupCompleted",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "SpecialtyPickupDay",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c7549eb-d14d-4c75-ae8d-96bff478606d", "d34086d9-495b-4904-931b-4c890ed99984", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e46dbbc4-8ea0-4153-a707-af227d93ae4a", "e78e90de-85b8-4e11-ae62-3f95ad7e2bbf", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c7549eb-d14d-4c75-ae8d-96bff478606d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46dbbc4-8ea0-4153-a707-af227d93ae4a");

            migrationBuilder.DropColumn(
                name: "SpecialtyPickupDay",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "SpecialtyPickupCompleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3455fc1c-31d7-42ce-beef-08161592d1ef", "239a82bf-d168-4f2c-bc5b-7b349621631a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1167d658-c911-488b-95c2-48bc173494f3", "e50ac383-0a26-442a-b1cc-9c60891d1564", "Customer", "CUSTOMER" });
        }
    }
}
