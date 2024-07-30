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


        bankAccountTypeBuilder.Property("_accountTypeId")
            .HasColumnName("AccountTypeId")
            .IsRequired();

        bankAccountTypeBuilder.HasOne(acc => acc.AccountType)
            .WithMany()
            .HasForeignKey("_accountTypeId")
            .OnDelete(DeleteBehavior.Restrict);
        /*
        Bank account type navigation property has to be ignored, once it should never adds a new value to that table.
        It has to be manually fed given the value o the FK
            The alternavies would be to:
            - just use the int FK on BankAccount model
            - to ignore the navigation property, without manual feeding it (what would the reading operation to no fill the property, just the FK)
            - to check always on SaveChanges if the AccountType entity was added, to change it to Unchanged
        */
        bankAccountTypeBuilder.Ignore("_accountType");
        bankAccountTypeBuilder.Ignore(acc => acc.AccountType);


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