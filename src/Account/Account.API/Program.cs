using Account.API.API;

var builder = WebApplication.CreateBuilder();

// Minimal api
builder.Services.AddEndpointsApiExplorer();

// Swagger open API
builder.Services.AddSwaggerGen();

// Api versioning
builder.Services.AddApiVersioning(options => options.ReportApiVersions = true)
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Add services
// ...
// ...

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
