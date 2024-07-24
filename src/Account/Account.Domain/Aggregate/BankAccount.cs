using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public sealed class BankAccount : Entity, IAggregateRoot
{
    public AccountType AccountType { get; private set; }

    //public AccountOwner AccountOwner { get; private set; }

    //public DateTime CreationDate { get; private set; }

    //public AccountNumber AccountNumber { get; private set; }

    //public Balance Balance { get; private set; }

    //public CreditLimit CreditLimit { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BankAccount()
    {
        // Required by EF
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public BankAccount(Ulid id, AccountType accountType
        //, AccountOwner accountOwner
        //, DateTime creationDate
        //, AccountNumber accountNumber
        //, Balance balance
        //, CreditLimit creditLimit
        )
    {
        Id = id;
        AccountType = accountType;
        //AccountNumber = accountNumber;
        //Balance = balance;
        //CreditLimit = creditLimit;
        //AccountOwner = accountOwner;
        //CreationDate = creationDate;
    }

    //Events // Methods
    // AccountCreatedEvent
    // AccountUpdatedEvent
    // AccountDeletedEvent
    // CheckBalance()
}
