using System;
using System.ComponentModel.DataAnnotations;

namespace ReceiptWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        [Required]
        public Provider Provider { get; set; }

        [Required]
        public CurrencyType CurrencyType { get; set; }
    }
}