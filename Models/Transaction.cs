using Microsoft.EntityFrameworkCore;
using mvc_aspnetcore_incomes_and_expenses.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc_aspnetcore_incomes_and_expenses.Models;

public class Transaction
{
    [Key]
    public int Id { get; set; }

    [DisplayName("Tipo")]
    public TransactionType Type { get; set; }

    [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    [DisplayName("Descrição")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [DataType(DataType.Currency)]
    [Precision(18,2)]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    [DisplayName("Valor")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "A data é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayName("Data")]
    public DateTime Date { get; set; }
    // Navigation properties can be added here if needed
    // public virtual User User { get; set; }
    // public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
