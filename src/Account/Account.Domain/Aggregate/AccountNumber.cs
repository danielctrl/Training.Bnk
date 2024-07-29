using System.Text;
using System.Text.RegularExpressions;

namespace Account.Domain.Aggregate;

public class AccountNumber
{
    public string Number { get; }

    private static readonly Regex AccountNumberValidCharactersRegex = new("^[0-9]", RegexOptions.Compiled);

    public AccountNumber(string number)
    {
        Number = number;

        if (string.IsNullOrWhiteSpace(Number))
            throw new AccountDomainException("Account number cannot be empty.");

        if (number.Length < 10 || number.Length > 12)
            throw new AccountDomainException("Invalid account number, It must contain between 10 to 12 digits.");

        if (!AccountNumberValidCharactersRegex.IsMatch(Number))
            throw new AccountDomainException("Invalid account number, It must contain only digits.");

        Number = number;
    }

    public static AccountNumber NewRandomAccountNumber(string accountPrefix)
    {
        if (accountPrefix.Length != 3)
            throw new AccountDomainException("Invalid account type prefix, It must contain 3 digits.");

        var reservedDigits = "00";

        var accountNumberSufix = new Random().Next(1000000, 9999999);

        var sb = new StringBuilder();
        sb.Append(accountPrefix);
        sb.Append(reservedDigits);
        sb.Append(accountNumberSufix);

        return new AccountNumber(sb.ToString());
    }
}