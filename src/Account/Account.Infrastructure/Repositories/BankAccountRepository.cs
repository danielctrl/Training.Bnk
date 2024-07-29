using Account.Domain.Aggregate;
using Account.Domain.Common;
using Account.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Repositories;

public sealed class BankAccountRepository : IBankAccountRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly AccountDbContext _context;

    public BankAccountRepository(AccountDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public BankAccount Add(BankAccount bankAccount)
    {
        var entityEntry = _context.BankAccounts.Add(bankAccount);
        return entityEntry.Entity;
    }

    public BankAccount Delete(BankAccount bankAccount)
    {
        return _context.BankAccounts.Remove(bankAccount).Entity;
    }

    public Task<BankAccount?> GetByIdAsync(Ulid id, CancellationToken cancellationToken)
    {
        return _context.BankAccounts
            .Include(ba => ba.AccountOwner)
            .Where(ba => ba.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public BankAccount Update(BankAccount bankAccount)
    {
        var entityEntry = _context.BankAccounts.Update(bankAccount);
        return entityEntry.Entity;
    }
}
