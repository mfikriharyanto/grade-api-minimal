using Grade.Api.Repositories;

namespace Grade.Api.Entities;

public static class StudentsEndpoints
{
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var studentRoutes = routes.MapGroup("/api/students");

        studentRoutes.MapGet("/", (IStudentRepository repository) => repository.GetAll());

        studentRoutes.MapPost("/", (IStudentRepository repository, Student student) =>
        {
            repository.Create(student);
            return Results.CreatedAtRoute("Students", new { id = student.Id }, student);
        });

        studentRoutes.MapGet("/{id}", (IStudentRepository repository, int id) =>
        {
            Student? student = repository.Get(id);
            return student is null ? Results.NotFound() : Results.Ok(student);
        }).WithName("Students");

        studentRoutes.MapPut("/{id}", (IStudentRepository repository, int id, Student updatedStudent) =>
        {
            var existingStudent = repository.Get(id);

            if (existingStudent is null) return Results.NotFound();

            repository.Update(id, updatedStudent);
            return Results.NoContent();
        });

        studentRoutes.MapDelete("/{id}", (IStudentRepository repository, int id) =>
        {
            var student = repository.Get(id);

            if (student is null) return Results.NotFound();

            repository.Delete(id);
            return Results.NoContent();
        });

        return studentRoutes;
    }
}