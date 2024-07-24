using Account.Api.Options;
using Account.Domain.Aggregate;
using Account.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Account.Api.Extensions;

public static class Extensions
{
    public static IServiceCollection AddAccountOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FooOptions>(configuration.GetSection(FooOptions.FooSectionName));

        return services;
    }
}
