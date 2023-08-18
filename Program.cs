using Grade.Api.Entities;
using Grade.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

var app = builder.Build();
app.MapStudentsEndpoints();

app.Run();
