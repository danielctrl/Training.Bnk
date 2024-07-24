namespace Account.Domain.Aggregate;

public class AccountOwner
{
    public string Name { get; set; }

    public AccountOwner(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new AccountDomainException("The account owner name can't be emtpy");
        if (name.Length > 1000) throw new AccountDomainException("The account owner name can't contain 1000 or more characters");

        Name = name;
    }
}