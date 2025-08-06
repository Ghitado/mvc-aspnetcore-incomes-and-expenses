using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_aspnetcore_incomes_and_expenses.Data;
using mvc_aspnetcore_incomes_and_expenses.Data.Services;
using mvc_aspnetcore_incomes_and_expenses.Models;

namespace mvc_aspnetcore_incomes_and_expenses.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITransactionService _transactionService;

        public TransactionController(
            ApplicationDbContext context, 
            ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _transactionService.GetAll());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var transaction = await _transactionService.GetById(id.Value);

            if (transaction is null)
                return NotFound();

            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Date,Category,IsIncome")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                await _transactionService.Add(transaction);
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var transaction = await _transactionService.GetById(id.Value);

            if (transaction is null)
                return NotFound();

            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Date,Category,IsIncome")] Transaction transaction)
        {
            if (id != transaction.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _transactionService.Update(transaction);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var transaction = await _transactionService.GetById(id.Value);

            if (transaction is null)
                return NotFound();

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transactionService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _transactionService.TransactionExists(id);
        }
    }
}
