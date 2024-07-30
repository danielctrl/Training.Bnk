using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public sealed class BankAccount : Entity, IAggregateRoot
{
    private readonly int _accountTypeId;

    private AccountType? _accountType;
    public AccountType AccountType
    {
        get
        {
            _accountType ??= Enumeration.FromValue<AccountType>(_accountTypeId);

            return _accountType;
        }
        private set { _accountType = value; }
    }

    public AccountOwner AccountOwner { get; private set; }

    public DateTime CreationDate { get; private set; }

    public AccountNumber AccountNumber { get; private set; }

    public Balance Balance { get; private set; }

    public CreditLimit CreditLimit { get; private set; }

#pragma warning disable CS8618
    private BankAccount()
    {
        // Required by EF
    }
#pragma warning restore CS8618

    public BankAccount(Ulid id, AccountType accountType, AccountOwner accountOwner, DateTime creationDate, AccountNumber accountNumber, Balance balance, CreditLimit creditLimit)
    {
        Id = id;

        _accountTypeId = accountType.Id;
        AccountType = accountType;

        AccountOwner = accountOwner;
        CreationDate = creationDate;
        AccountNumber = accountNumber;
        Balance = balance;
        CreditLimit = creditLimit;
    }

    //Events // Methods
    // AccountCreatedEvent
    // AccountUpdatedEvent
    // AccountDeletedEvent
    // CheckBalance()
}
