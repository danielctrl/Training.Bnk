using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public sealed class Account : Entity, IAggregateRoot
{
    // ToDo: Document it >> https://github.com/Cysharp/ulid
    public Ulid AccountId { get; private set; }

    public AccountType AccountType { get; private set; }

    public string AccountOwner { get; private set; }

    public DateTime CreationDate { get; private set; }

    public AccountNumber AccountNumber { get; private set; }

    public Balance Balance { get; private set; }

    public CreditLimit CreditLimit { get; private set; }

    public Account(string accountId, AccountType accountType, string accountOwner, DateTime creationDate, AccountNumber accountNumber, Balance balance, CreditLimit creditLimit)
    {
        AccountId = Ulid.Parse(accountId);
        AccountType = accountType;
        AccountNumber = accountNumber;
        Balance = balance;
        CreditLimit = creditLimit;
        AccountOwner = accountOwner;
        CreationDate = creationDate;
    }

    //Events // Methods
    // AccountCreatedEvent
    // AccountUpdatedEvent
    // AccountDeletedEvent
    // CheckBalance()
}
