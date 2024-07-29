using Account.Domain.Aggregate;

namespace Account.Domain.Services;

public static class AccountNumberPrefixGenerator
{
    public static string GenerateByAccountType(AccountType accountType)
    {
        return accountType.Name switch
        {
            "Current" => "001",
            "Savings" => "066",
            _ => throw new AccountDomainException("Invalid account type for account number prefix generation")
        };
    }
}
