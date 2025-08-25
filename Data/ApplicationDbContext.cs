using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvc_aspnetcore_incomes_and_expenses.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Description)
                      .IsRequired(false)
                      .HasMaxLength(100);

                entity.Property(t => t.Amount)
                      .IsRequired()
                      .HasPrecision(18, 2);

                entity.Property(t => t.Date)
                      .IsRequired()
                      .HasColumnType("date"); 

                entity.Property(t => t.Type)
                      .IsRequired()
                      .HasConversion<int>(); 
            });
        }
    }
}
