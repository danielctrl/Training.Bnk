using Account.Domain.Aggregate;
using System.Text;

namespace Account.Domain.Services;

public static class AccountNumberFactory
{
    public static AccountNumber CreateAccountNumber(AccountType accountType)
    {
        var accountPrefix = GetAccountTypePrefix(accountType);

        if (accountPrefix.Length != 3)
            throw new AccountDomainException("Invalid account type prefix, It must contain 3 digits.");

        var reservedDigits = "00";

        var accountNumberSufix = new Random().Next(1000000, 9999999);

        var finalNumber = new StringBuilder()
            .Append(accountPrefix)
            .Append(reservedDigits)
            .Append(accountNumberSufix)
            .ToString();

        return new AccountNumber(finalNumber);
    }

    private static string GetAccountTypePrefix(AccountType accountType)
    {
        return accountType.Name switch
        {
            "Current" => "001",
            "Savings" => "066",
            _ => throw new AccountDomainException("Invalid account type for account number prefix generation")
        };
    }
}
