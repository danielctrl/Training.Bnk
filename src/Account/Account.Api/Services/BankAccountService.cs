using Account.Api.Dto;
using Account.Domain.Aggregate;

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
            var bankAccount = new BankAccount(
                createAccountRequest.AccountType,
                createAccountRequest.AccountOwner
            );

            _bankAccountRepository.Add(bankAccount);

            await _bankAccountRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return bankAccount.Id;
        }
    }
}
