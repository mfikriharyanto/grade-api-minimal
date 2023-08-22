using Grade.Api.Dtos;
using Grade.Api.Models;
using Grade.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Grade.Api.Endpoints;

public static class StudentsEndpoints
{
    public static RouteGroupBuilder MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var studentRoutes = routes.MapGroup("/api/students").RequireAuthorization();

        studentRoutes.MapGet("/", async (IStudentRepository repository) =>
        {
            var students = (await repository.GetAllAsync()).Select(student => student.AsDto());
            return TypedResults.Ok(students);
        });

        studentRoutes.MapPost("/", async (IStudentRepository repository, CreateStudentDto studenDto) =>
        {
            Student student = new(studenDto.Name);
            await repository.CreateAsync(student);
            return TypedResults.CreatedAtRoute(student.AsDto(), "GetStudent", new { student.Id });
        });

        studentRoutes.MapGet("/{id}", async Task<Results<NotFound, Ok<StudentDto>>> (IStudentRepository repository, int id) =>
        {
            var student = await repository.GetAsync(id);
            return student is null ? TypedResults.NotFound() : TypedResults.Ok(student.AsDto());
        }).WithName("GetStudent");

        studentRoutes.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (IStudentRepository repository, int id, UpdateStudentDto updateStudentDto) =>
        {
            var existingStudent = await repository.GetAsync(id);

            if (existingStudent is null) return TypedResults.NotFound();

            existingStudent.Name = updateStudentDto.Name;
            await repository.UpdateAsync(existingStudent);

            return TypedResults.NoContent();
        });

        studentRoutes.MapDelete("/{id}", async Task<Results<NotFound, NoContent>> (IStudentRepository repository, int id) =>
        {
            var student = await repository.GetAsync(id);

            if (student is null) return TypedResults.NotFound();

            await repository.DeleteAsync(student);
            return TypedResults.NoContent();
        });

        return studentRoutes;
    }
}