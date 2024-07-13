using Microsoft.AspNetCore.Http.HttpResults;

namespace Account.API.API;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountRoutes(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/accounts")
            .HasApiVersion(1.0);

        api.MapGet("/{id:int}", GetAccountAsync);

        return app;
    }

    public static async Task<Results<Ok<string>, BadRequest<string>>> GetAccountAsync(int id)
    {
        await Task.Yield();

        if (id == 0)
            return TypedResults.BadRequest<string>("Id cannot be 0");

        return TypedResults.Ok("This is a sudo account");
    }
}