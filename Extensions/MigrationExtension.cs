using Microsoft.EntityFrameworkCore;
using mvc_aspnetcore_incomes_and_expenses.Data;

namespace mvc_aspnetcore_incomes_and_expenses.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext context =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();
    }
}
