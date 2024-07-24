using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class AccountType : Enumeration
{
    public static readonly AccountType Savings = new(1, "Savings");
    public static readonly AccountType Current = new(2, "Current");

    private AccountType(int id, string name) : base(id, name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new AccountDomainException("The account type name can't be emtpy");
    }
}