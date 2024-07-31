using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public class AccountOwner : ValueObject
{
    public string Name { get; set; }

    internal AccountOwner(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new AccountDomainException("The account owner name can't be emtpy");
        if (name.Length > 1000) throw new AccountDomainException("The account owner name can't contain 1000 or more characters");

        Name = name;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }
}