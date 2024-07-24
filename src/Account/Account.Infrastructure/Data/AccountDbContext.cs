using Account.Domain.Aggregate;
using Account.Domain.Common;
using Account.Infrastructure.Data.Configuration;
using Account.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Data;

public class AccountDbContext : DbContext, IUnitOfWork
{
    public DbSet<BankAccount> BankAccounts { get; set; }

    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BankAccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AccountTypeEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>();
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
