using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_AllProperties_ToBankAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountOwnerName",
                table: "BankAccounts",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "BankAccounts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BalanceLastUpdated",
                table: "BankAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "BankAccounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "CreditLimit",
                table: "BankAccounts",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountOwnerName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BalanceLastUpdated",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "BankAccounts");
        }
    }
}
