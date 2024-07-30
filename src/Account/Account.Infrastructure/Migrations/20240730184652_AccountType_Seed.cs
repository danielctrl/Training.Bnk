using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountType_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_AccountTypes_AccountTypeId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_AccountTypeId",
                table: "BankAccounts");

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Current" },
                    { 2, "Savings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AccountTypeId",
                table: "BankAccounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_AccountTypes_AccountTypeId",
                table: "BankAccounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
