using Grade.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<StudentContext>();
        DbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var conn = configuration.GetConnectionString("GradeStoreContext");
        services.AddSqlServer<StudentContext>(conn)
                .AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}