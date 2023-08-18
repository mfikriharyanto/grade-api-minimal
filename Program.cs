using Grade.Api.Entities;
using Grade.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

var conn = builder.Configuration.GetConnectionString("GradeStoreContext");

var app = builder.Build();
app.MapStudentsEndpoints();

app.Run();
