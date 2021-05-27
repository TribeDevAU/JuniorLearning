using System;
using FinanceMentor.Shared;
using System.ComponentModel.DataAnnotations;

namespace FinanceMentor.Components
{
    public class ExpenseModel
    {
        [Required]
        public DateTime Date { get; set; }


        [StringLength(50)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public ExpenseCategory Category { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
