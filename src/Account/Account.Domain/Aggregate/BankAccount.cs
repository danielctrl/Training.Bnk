using Account.Domain.Common;
using Account.Domain.Services;

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

    public BankAccount(AccountType accountType, string accountOwnerName)
    {
        Id = Ulid.NewUlid();

        _accountTypeId = accountType.Id;
        AccountType = accountType;

        AccountNumber = AccountNumberFactory.CreateAccountNumber(accountType);
        CreationDate = DateTime.UtcNow;

        AccountOwner = new AccountOwner(accountOwnerName);

        Balance = new Balance(null, null);
        CreditLimit = new CreditLimit(null);
    }

    //Events // Methods
    // AccountCreatedEvent
    // AccountUpdatedEvent
    // AccountDeletedEvent
    // CheckBalance()
}
