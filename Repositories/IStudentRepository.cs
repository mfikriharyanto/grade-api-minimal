using Grade.Api.Entities;

namespace Grade.Api.Repositories;

public interface IStudentRepository
{
    public IEnumerable<Student> GetAll();

    public Student? Get(int id);

    public void Create(Student student);

    public void Update(Student updatedStudent);

    public void Delete(int id);
}