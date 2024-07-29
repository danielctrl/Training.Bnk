using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    BankAccount Add(BankAccount bankAccount);
    BankAccount Delete(BankAccount bankAccount);
    Task<BankAccount?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    BankAccount Update(BankAccount bankAccount);
}
