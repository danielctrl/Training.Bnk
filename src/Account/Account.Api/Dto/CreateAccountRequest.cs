using Account.Domain.Aggregate;

namespace Account.Api.Dto;

public record CreateAccountRequest(AccountType AccountType, string AccountOwner)
{
}
