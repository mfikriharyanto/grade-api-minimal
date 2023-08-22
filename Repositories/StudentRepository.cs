using Grade.Api.Data;
using Grade.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext dbContext;

    public StudentRepository(StudentContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await dbContext.Students.AsNoTracking().ToListAsync();
    }

    public async Task<Student?> GetAsync(int id)
    {
        return await dbContext.Students.FindAsync(id);
    }

    public async Task CreateAsync(Student student)
    {
        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student updatedStudent)
    {
        dbContext.Update(updatedStudent);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Students.Where(student => student.Id == id)
                                .ExecuteDeleteAsync();
    }
}