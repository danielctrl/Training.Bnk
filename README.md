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

### Domain

1. **Account Management**
    - **Account Creation:**
      - Types of accounts (checking, savings, investment).
      - Initial data such as balance, credit limit, etc.
    - **Account Deletion and Update:**
      - Updating account data (type, limits, etc.).
      - Deleting accounts, considering business rules (non-zero balance, pending issues).
    - **Balance Inquiry:**
      - Checking the current balance.
      - Detailed statement of recent transactions.

1. **Transactions**
   - **Deposits and Withdrawals:**
     - Adding funds to the account.
     - Withdrawing funds, respecting available balance and possible limits.
   - **Account Transfers:**
     - Internal transfers (between accounts within the same bank).
     - ~~External transfers (to accounts in other banks).~~
   - **Transaction History:**
     - Detailed record of all transactions (date, amount, type).
   - **Transaction Notifications:**
     - Sending notifications via email or SMS after transactions are made.

1. ~~**Customer Management**~~
     - ~~**New Customer Registration:**~~
     - ~~Collecting personal information (name, address, contact details).~~
     - ~~Initial credit check.~~
   - ~~**Updating Personal Information:**~~
     - ~~Allowing customers to update their personal details.~~
   - ~~**Credit Verification:**~~
     - ~~Checking and updating customers' credit information.~~



## Relevant info for developing:
- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

