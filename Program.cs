using Grade.Api.Data;
using Grade.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapStudentsEndpoints();

app.Run();
