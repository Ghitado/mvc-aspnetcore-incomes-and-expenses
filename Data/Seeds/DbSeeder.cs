using Microsoft.AspNetCore.Identity;

namespace mvc_aspnetcore_incomes_and_expenses.Data.Seeds;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        context.Database.EnsureCreated();

        if (!userManager.Users.Any())
        {
            var user = new IdentityUser
            {
                UserName = "admin@teste.com",
                Email = "admin@teste.com",
                EmailConfirmed = true
            };
            userManager.CreateAsync(user, "SenhaForte123!").Wait();
        }

        if (!context.Transactions.Any())
        {
            var transactions = new List<Models.Transaction>
            {
                new()
                {
                    Type = Models.Enums.TransactionType.RECEITA,
                    Description = "Salário",
                    Amount = 2500.00m,
                    Date = DateTime.Now
                },
                new()
                {
                    Type = Models.Enums.TransactionType.DESPESA,
                    Description = "Aluguel",
                    Amount = 1200.00m,
                    Date = DateTime.Now
                }
            };

            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}