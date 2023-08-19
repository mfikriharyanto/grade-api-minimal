using Grade.Api.Entities;

namespace Grade.Api.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetAsync(int id);

    Task CreateAsync(Student student);

    Task UpdateAsync(Student updatedStudent);

    Task DeleteAsync(int id);
}