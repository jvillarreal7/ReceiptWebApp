using System;
using System.ComponentModel.DataAnnotations;

namespace ReceiptWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        public Provider Provider { get; set; }

        [Required]
        public int ProviderId { get; set; }

        public CurrencyType CurrencyType { get; set; }

        [Required]
        public int CurrencyTypeId { get; set; }
    }
}