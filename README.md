# bnk Leaning Project


## Objective

This project is intended to be used as a project where I can practice some tech/concepts

- DDD
- Transactional Outbox
- Microservice (at least 2 services + 1 to query aggregated data >> API Composition or CQRS)
- Port and adapters
- Event Sourcing
- CQRS
- Service discovery / apim
- Elk

- ---
## Domain

1. **Account Management**
    - **Features**
      - **Account Creation:**
          - Types of accounts (checking, savings, investment).
          - Initial data such as balance, credit limit, etc.
      - **Account Deletion and Update:**
          - Updating account data (type, limits, etc.).
          - Deleting accounts, considering business rules (non-zero balance, pending issues).
      - **Balance Inquiry:**
          - Checking the current balance.
          - Detailed statement of recent transactions.

    - Domain Events
        - AccountCreatedEvent
        - AccountUpdatedEvent
        - AccountDeletedEvent
    - Entities
      - Account
         - Properties: AccountId, AccountType, Balance, CreditLimit, CreationDate, UpdateDate
         - Methods: CreateAccount, UpdateAccount, DeleteAccount, CheckBalance
    - Aggregates
      - AccountAggregate
        - Root: Account
        - Components: Transactions (related to the account)
    - Value Objects
      - AccountType
        - Types: Checking, Savings, Investment
      - Balance
        - Properties: Amount, Currency
      - CreditLimit
        - Properties: LimitAmount, Currency

1. **Transactions**
   - Features
     - **Deposits and Withdrawals:**
       - Adding funds to the account.
       - Withdrawing funds, respecting available balance and possible limits.
     - **Account Transfers:**
       - Internal transfers (between accounts within the same bank).
     - **Transaction History:**
       - Detailed record of all transactions (date, amount, type).
     - **Transaction Notifications:**
       - Sending notifications via email or SMS after transactions are made.

    - Domain Events
      - DepositMadeEvent
      - WithdrawalMadeEvent
      - TransferMadeEvent
    - Entities
        - Transaction
            - Properties: TransactionId, AccountId, Amount, Type (Deposit, Withdrawal, Transfer), Date, Status
            - Methods: CreateTransaction, UpdateTransaction, GetTransactionDetails
    - Aggregates
      - TransactionAggregate
        - Root: Transaction
        - Components: Account (related to the transaction)
    - Value Objects
      - TransactionType
        - Types: Deposit, Withdrawal, InternalTransfer, ExternalTransfer
      - Amount
        - Properties: Value, Currency
      - TransactionStatus
        - Types: Pending, Completed, Failed


---
## Future changes on V2 

- **New Domain**
  - **Notification**
  -  **Customer Management**
     - **New Customer Registration:**
       - Collecting personal information (name, address, contact details).
       - Initial credit check.
     - **Updating Personal Information:**
       - Allowing customers to update their personal details.
     - **Credit Verification:**
       - Checking and updating customers' credit information.

- Different dbs for writting and querying (CQRS) 



## Relevant info for developing:
- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

