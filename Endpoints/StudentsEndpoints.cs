using Grade.Api.Dtos;
using Grade.Api.Repositories;

namespace Grade.Api.Entities;

public static class StudentsEndpoints
{
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var studentRoutes = routes.MapGroup("/api/students");

        studentRoutes.MapGet("/", async (IStudentRepository repository) =>
        {
            return (await repository.GetAllAsync()).Select(student => student.AsDto());
        });

        studentRoutes.MapPost("/", async (IStudentRepository repository, CreateStudentDto studenDto) =>
        {
            Student student = new(studenDto.Name);
            await repository.CreateAsync(student);
            return Results.CreatedAtRoute("Students", new { id = student.Id }, student.AsDto());
        });

        studentRoutes.MapGet("/{id}", async (IStudentRepository repository, int id) =>
        {
            var student = await repository.GetAsync(id);
            return student is null ? Results.NotFound() : Results.Ok(student.AsDto());
        }).WithName("Students");

        studentRoutes.MapPut("/{id}", async (IStudentRepository repository, int id, UpdateStudentDto updatedStudentDto) =>
        {
            var existingStudent = await repository.GetAsync(id);

            if (existingStudent is null) return Results.NotFound();

            existingStudent.Name = updatedStudentDto.Name;
            await repository.UpdateAsync(existingStudent);

            return Results.NoContent();
        });

        studentRoutes.MapDelete("/{id}", async (IStudentRepository repository, int id) =>
        {
            var student = await repository.GetAsync(id);

            if (student is null) return Results.NotFound();

            await repository.DeleteAsync(id);
            return Results.NoContent();
        });

        return studentRoutes;
    }
}