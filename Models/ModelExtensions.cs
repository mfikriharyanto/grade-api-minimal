using Grade.Api.Dtos;

namespace Grade.Api.Models;

public static class ModelExtensions
{
    public static StudentDto AsDto(this Student student)
    {
        return new StudentDto(
            student.Id,
            student.Name
        );
    }
}