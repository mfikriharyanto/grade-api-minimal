using Grade.Api.Data;
using Grade.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext dbContext;

    public StudentRepository(StudentContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Student> GetAll()
    {
        return dbContext.Students.AsNoTracking().ToList();
    }

    public Student? Get(int id)
    {
        return dbContext.Students.Find(id);
    }

    public void Create(Student student)
    {
        dbContext.Students.Add(student);
        dbContext.SaveChanges();
    }

    public void Update(Student updatedStudent)
    {
        dbContext.Update(updatedStudent);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Students.Where(student => student.Id == id).ExecuteDelete();
    }
}