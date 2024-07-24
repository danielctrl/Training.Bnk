using Account.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Data.EntityConfiguration;

public class BankAccountEntityTypeConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> bankAccountTypeBuilder)
    {
        bankAccountTypeBuilder.ToTable("BankAccounts");


        bankAccountTypeBuilder.HasKey(x => x.Id);
        
        bankAccountTypeBuilder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasMaxLength(26)
            .IsRequired();


        // A FK column will be created automaticaly
        bankAccountTypeBuilder.HasOne(acc => acc.AccountType)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);


        bankAccountTypeBuilder.OwnsOne(acc => acc.AccountOwner,
            ao => ao.Property(x => x.Name)
                .HasColumnName("AccountOwnerName")
                .HasMaxLength(1000)
                .IsRequired());


        bankAccountTypeBuilder.Property(x => x.CreationDate)
            .HasColumnName("CreationDate")
            .IsRequired();


        bankAccountTypeBuilder.OwnsOne(acc => acc.AccountNumber,
            an => an.Property(x => x.Number)
                .HasColumnName("AccountNumber")
                .HasMaxLength(12)
                .IsRequired());


        bankAccountTypeBuilder.OwnsOne(acc => acc.Balance, balance =>
        {
            balance.Property(x => x.Value)
                .HasColumnName("Balance")
                .IsRequired(false);

            balance.Property(x => x.LastUpdated)
                .HasColumnName("BalanceLastUpdated")
                .IsRequired(false);
        });


        bankAccountTypeBuilder.OwnsOne(acc => acc.CreditLimit,
            cl => cl.Property(x => x.Value)
                .HasColumnName("CreditLimit")
                .IsRequired(false)
        );
    }
}