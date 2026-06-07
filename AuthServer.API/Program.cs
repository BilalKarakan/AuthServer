using AuhtServer.Shared.Configurations;
using AuthServer.API.Extensions;
using AuthServer.Business;
using AuthServer.DataAccess;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("VaultKeys"));
builder.Services.AddServicesRegistration();
await builder.Services.AddDataAccessRegistration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference(options =>
{
    options.WithTitle("AuthServer API").WithTheme(ScalarTheme.Moon).WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
