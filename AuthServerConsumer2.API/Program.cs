using AuhtServer.Shared.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient("AuthServer", client =>
{
    client.BaseAddress = new Uri("https://localhost:7082");
});
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});
await builder.Services.AddConfigurationToken(builder.Configuration);

var app = builder.Build();

app.MapScalarApiReference(options =>
{
    options.WithTitle("AuthServer API").WithTheme(ScalarTheme.Moon).WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
