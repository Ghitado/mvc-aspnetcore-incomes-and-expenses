using Microsoft.EntityFrameworkCore;
using mvc_aspnetcore_incomes_and_expenses.Models;

namespace mvc_aspnetcore_incomes_and_expenses.Data.Services;

public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext _context;

    public TransactionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Transaction transaction)
    {
        _context.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var transaction = await GetById(id);

        if (transaction is not null)
            _context.Transactions.Remove(transaction);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetAll()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetById(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public bool TransactionExists(int id)
    {
        return _context.Transactions.Any(e => e.Id == id);
    }

    public async Task Update(Transaction transaction)
    {
        _context.Update(transaction);
        await _context.SaveChangesAsync();
    }
}
