using Account.Api.Dto;
using Account.Api.Options;
using Account.Api.Services;
using Account.Domain.Aggregate;
using Account.Domain.Exceptions;
using Account.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Account.Api.Api;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountRoutes(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/v{version:apiVersion}/accounts")
            .HasApiVersion(1.0);

        api.MapGet("/{id}", GetAccountAsync);
        api.MapPost("/", CreateAccountAsync);

        return app;
    }

    public static async Task<Results<Ok<Ulid>, BadRequest>> CreateAccountAsync(CreateAccountRequest createAccountRequest, BankAccountService bankAccountService, ILoggerFactory loggerFactory, CancellationToken cancellationToken)
    {
        var logger = loggerFactory.CreateLogger("AccountApi");

        try
        {
            var bankAccountId = await bankAccountService.CreateBankAccountAsync(createAccountRequest, cancellationToken);

            return TypedResults.Ok(bankAccountId);
        }
        catch (AccountDomainException ex)
        {
            //ToDo: Apply specification and notification pattern: https://www.codeproject.com/Tips/790758/Specification-and-Notification-Patterns
            logger.LogTrace(ex, "A domain error has occur while trying to create a new account");
            return TypedResults.BadRequest();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected erro has occur while trying to create a new account");
            throw;
        }
    }

    public static async Task<Results<Ok<BankAccount>, BadRequest<string>>> GetAccountAsync(Ulid id, IBankAccountRepository bankAccountRepository, [FromServices] IOptions<FooOptions> fooOptions, CancellationToken cancellationToken)
    {
        if (id == default)
            return TypedResults.BadRequest("Id cannot be empty");

        var bankAccount = await bankAccountRepository.GetByIdAsync(id, cancellationToken);

        return TypedResults.Ok(bankAccount);
    }
}