using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class AccountType : Enumeration
{
    public static readonly AccountType Savings = new(1, "Savings");
    public static readonly AccountType Current = new(1, "Current");

    private AccountType(int id, string name) : base(id, name)
    { }
}