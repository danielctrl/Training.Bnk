using Account.Api.Options;
using Account.Api.Services;
using Account.Domain.Aggregate;
using Account.Infrastructure.Data;
using Account.Infrastructure.Repositories;
using Account.Infrastructure.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

namespace Account.Api.Extensions;

public static class Extensions
{
    public static IServiceCollection AddAccountApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Todo: Add environment variable for connection string
        services.AddDbContext<AccountDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:AccountDB"]));

        services.AddScoped<IBankAccountRepository, BankAccountRepository>();

        services.AddScoped<BankAccountService>();

        services.Configure<JsonOptions>(options => options.SerializerOptions.Converters.Add(new AccountTypeConverter()));

        //Todo: Try Aspire
        //builder.EnrichNpgsqlDbContext<AccountDbContext>();

#warning fix it: Add seeding
        //services.AddMigration<AccountDbContext, AccountDbContextSeed>();

        return services;
    }

    public static IServiceCollection AddAccountOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FooOptions>(configuration.GetSection(FooOptions.FooSectionName));

        return services;
    }
}
