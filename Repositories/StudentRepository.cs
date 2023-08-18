using Grade.Api.Entities;

namespace Grade.Api.Repositories;

public class StudentRepository
{
    private readonly List<Student> students = new();

    public IEnumerable<Student> GetAll()
    {
        return students;
    }

    public Student? Get(int id)
    {
        return students.Find(student => student.Id == id);
    }

    public void Create(Student student)
    {
        student.Id = Student.GetSeedId();
        students.Add(student);
    }

    public void Update(int id, Student updatedStudent)
    {
        int index = students.FindIndex(student => student.Id == id);
        updatedStudent.Id = id;
        students[index] = updatedStudent;
    }

    public void Delete(int id)
    {
        int index = students.FindIndex(student => student.Id == id);
        students.RemoveAt(index);
    }
}