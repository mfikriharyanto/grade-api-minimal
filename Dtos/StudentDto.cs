namespace Grade.Api.Dtos;

public record StudentDto(
    int Id,
    string Name
);

public record CreateStudentDto(
    string Name
);

public record UpdateStudentDto(
    string Name
);