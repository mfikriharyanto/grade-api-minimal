using Grade.Api.Repositories;

namespace Grade.Api.Entities;

public static class StudentsEndpoints
{
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        StudentRepository studentRepository = new();

        var studentRoutes = routes.MapGroup("/api/students");

        studentRoutes.MapGet("/", () => studentRepository.GetAll());

        studentRoutes.MapPost("/", (Student student) =>
        {
            studentRepository.Create(student);
            return Results.CreatedAtRoute("Students", new { id = student.Id }, student);
        });

        studentRoutes.MapGet("/{id}", (int id) =>
        {
            Student? student = studentRepository.Get(id);
            return student is null ? Results.NotFound() : Results.Ok(student);
        }).WithName("Students");

        studentRoutes.MapPut("/{id}", (int id, Student updatedStudent) =>
        {
            var existingStudent = studentRepository.Get(id);

            if (existingStudent is null) return Results.NotFound();

            studentRepository.Update(id, updatedStudent);
            return Results.NoContent();
        });

        studentRoutes.MapDelete("/{id}", (int id) =>
        {
            var student = studentRepository.Get(id);

            if (student is null) return Results.NotFound();

            studentRepository.Delete(id);
            return Results.NoContent();
        });

        return studentRoutes;
    }
}