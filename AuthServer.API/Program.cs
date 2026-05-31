using AuhtServer.Shared.Configurations;
using AuthServer.Business;
using AuthServer.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("VaultKeys"));
await builder.Services.AddDataAccessRegistration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
