namespace mvc_aspnetcore_incomes_and_expenses.Data.Services;

public interface ITransactionService
{
    Task<IEnumerable<Models.Transaction>> GetAll();
    Task<Models.Transaction?> GetById(int id);
    Task Add(Models.Transaction transaction);
    Task Update(Models.Transaction transaction);
    Task DeleteById(int id);
    bool TransactionExists(int id);
}
