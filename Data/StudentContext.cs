using Grade.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Data;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}