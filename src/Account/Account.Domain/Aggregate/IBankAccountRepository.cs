using Account.Domain.Common;

namespace Account.Domain.Aggregate;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    Task<BankAccount> AddAsync(BankAccount bankAccount);
    BankAccount Delete(BankAccount bankAccount);
    Task<BankAccount?> GetByIdAsync(Ulid id);
    BankAccount Update(BankAccount bankAccount);
}
