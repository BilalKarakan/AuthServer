using AuhtServer.Shared.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
