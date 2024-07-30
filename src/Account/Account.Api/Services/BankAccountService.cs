using Account.Api.Dto;
using Account.Domain.Aggregate;
using Account.Domain.Services;

namespace Account.Api.Services
{
    public class BankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<Ulid> CreateBankAccountAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken = default)
        {
            var accountNumberPrefix = AccountNumberPrefixGenerator.GenerateByAccountType(createAccountRequest.AccountType);
            var newAccountNumber = AccountNumber.NewRandomAccountNumber(accountNumberPrefix);
            var id = Ulid.NewUlid();

            var bankAccount = new BankAccount(
                id,
                createAccountRequest.AccountType,
                new AccountOwner(createAccountRequest.AccountOwner),
                DateTime.UtcNow,
                newAccountNumber,
                new Balance(null, null),
                new CreditLimit(null)
            );

            _bankAccountRepository.Add(bankAccount);

            await _bankAccountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return id;
        }
    }
}
