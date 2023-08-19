using Grade.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Grade.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<StudentContext>();
        await DbContext.Database.MigrateAsync();
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