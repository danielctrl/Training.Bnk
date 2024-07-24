using Account.Api.Extensions;
using Account.API.API;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder();
var services = builder.Services;

// Minimal api
services.AddEndpointsApiExplorer();

// Swagger open API
services.AddSwaggerGen();

// Api versioning
services.AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Add services
services
    .AddAccountApplicationServices(builder.Configuration)
    .AddAccountOptions(builder.Configuration);

var app = builder.Build();

// Swagger open API.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Routing
app.NewVersionedApi("Accounts")
    .MapAccountRoutes();

app.Run();
