namespace Grade.Api.Entities;

public static class StudentsEndpoints
{
    static readonly List<Student> students = new List<Student>();
    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var studentRoutes = routes.MapGroup("/api/students");

        studentRoutes.MapGet("/", () => students);

        routes.MapPost("/api/students", (Student student) =>
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return Results.CreatedAtRoute("Students", new { id = student.Id }, student);
        });

        studentRoutes.MapGet("/{id}", (int id) =>
        {
            var student = students.Find(student => student.Id == id);

            if (student is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(student);
        }).WithName("Students");

        studentRoutes.MapPut("/{id}", (int id, Student updatedStudent) =>
        {
            var existingStudent = students.Find(student => student.Id == id);

            if (existingStudent is null)
            {
                return Results.NotFound();
            }

            existingStudent.Name = updatedStudent.Name;

            return Results.NoContent();
        });

        studentRoutes.MapDelete("/{id}", (int id) =>
        {
            var student = students.Find(student => student.Id == id);

            if (student is null)
            {
                return Results.NotFound();
            }

            students.Remove(student);
            return Results.NoContent();
        });

        return studentRoutes;
    }
}