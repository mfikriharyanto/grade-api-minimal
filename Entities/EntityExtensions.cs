using Grade.Api.Dtos;

namespace Grade.Api.Entities;

public static class EntityExtensions
{
    public static StudentDto AsDto(this Student student)
    {
        return new StudentDto(
            student.Id,
            student.Name
        );
    }
}