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

        // A FK column will be created
        bankAccountTypeBuilder.HasOne(acc => acc.AccountType)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);






        ////Do it
        //bankAccountTypeBuilder.Property(x => x.AccountOwner)
        //    .HasColumnName("AccountOwner")
        //    .HasMaxLength(1000)
        //    .IsRequired();
        ////Do it
        //bankAccountTypeBuilder.Property(x => x.CreationDate)
        //    .HasColumnName("CreationDate")
        //    .IsRequired();
        ////Do it
        //bankAccountTypeBuilder.Property(x => x.AccountNumber)
        //    .HasColumnName("AccountNumber")
        //    .IsRequired();
        ////Do it
        //bankAccountTypeBuilder.Property(x => x.Balance)
        //    .HasColumnName("Balance")
        //    .IsRequired();
        ////Do it
        //bankAccountTypeBuilder.Property(x => x.CreditLimit)
        //    .HasColumnName("CreditLimit")
        //    .IsRequired();
    }
}