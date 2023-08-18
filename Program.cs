using Grade.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapStudentsEndpoints();

app.Run();
