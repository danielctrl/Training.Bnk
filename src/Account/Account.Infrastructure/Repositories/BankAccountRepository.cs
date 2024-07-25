using Account.Domain.Aggregate;
using Account.Domain.Common;
using Account.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Repositories;

internal class BankAccountRepository : IBankAccountRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly AccountDbContext _context;

    public BankAccountRepository(AccountDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<BankAccount> AddAsync(BankAccount bankAccount)
    {
        var entityEntry = await _context.BankAccounts.AddAsync(bankAccount);
        return entityEntry.Entity;
    }

    public BankAccount Delete(BankAccount bankAccount)
    {
        return _context.BankAccounts.Remove(bankAccount).Entity;
    }

    public Task<BankAccount?> GetByIdAsync(Ulid id)
    {
        return _context.BankAccounts
            .Include(ba => ba.AccountOwner)
            .Where(ba => ba.Id == id)
            .SingleOrDefaultAsync();
    }

    public BankAccount Update(BankAccount bankAccount)
    {
        var entityEntry = _context.BankAccounts.Update(bankAccount);
        return entityEntry.Entity;
    }
}
