using Grade.Api.Data;
using Grade.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _dbContext;

    public StudentRepository(StudentContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _dbContext.Students.AsNoTracking().ToListAsync();
    }

    public async Task<Student?> GetAsync(int id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task CreateAsync(Student student)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _dbContext.Update(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        _dbContext.Remove(student);
        await _dbContext.SaveChangesAsync();
    }
}