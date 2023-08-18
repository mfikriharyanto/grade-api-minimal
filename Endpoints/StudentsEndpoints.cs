using Grade.Api.Dtos;
using Grade.Api.Repositories;

namespace Grade.Api.Entities;

public static class StudentsEndpoints
{
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var studentRoutes = routes.MapGroup("/api/students");

        studentRoutes.MapGet("/", (IStudentRepository repository) =>
        {
            return repository.GetAll().Select(student => student.AsDto());
        });

        studentRoutes.MapPost("/", (IStudentRepository repository, CreateStudentDto studenDto) =>
        {
            Student student = new(studenDto.Name);
            repository.Create(student);
            return Results.CreatedAtRoute("Students", new { id = student.Id }, student.AsDto());
        });

        studentRoutes.MapGet("/{id}", (IStudentRepository repository, int id) =>
        {
            Student? student = repository.Get(id);
            return student is null ? Results.NotFound() : Results.Ok(student.AsDto());
        }).WithName("Students");

        studentRoutes.MapPut("/{id}", (IStudentRepository repository, int id, UpdateStudentDto updatedStudentDto) =>
        {
            var existingStudent = repository.Get(id);

            if (existingStudent is null) return Results.NotFound();

            existingStudent.Name = updatedStudentDto.Name;
            repository.Update(id, existingStudent);

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