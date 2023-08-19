using Grade.Api.Data;
using Grade.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

app.Services.InitializeDb();

app.MapStudentsEndpoints();

app.Run();
