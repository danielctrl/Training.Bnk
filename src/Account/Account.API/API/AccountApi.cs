using Account.Api.Options;
using Account.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Account.API.API;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountRoutes(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/v{version:apiVersion}/accounts")
            .HasApiVersion(1.0);

        api.MapGet("/{id:int}", GetAccountAsync);

        return app;
    }

    public static async Task<Results<Ok<string>, BadRequest<string>>> GetAccountAsync(int id, [FromServices] IOptions<FooOptions> fooOptions, AccountDbContext accountDbContext)
    {
        await Task.Yield();

        if (id == 0)
            return TypedResults.BadRequest<string>("Id cannot be 0");

        return TypedResults.Ok("This is a valid account");
    }
}