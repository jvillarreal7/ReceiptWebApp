using ReceiptWebApp.Models;
using System.Collections.Generic;

namespace ReceiptWebApp.ViewModels
{
    public class ReceiptFormViewModel
    {
        public string Amount { get; set; }
        public string Comments { get; set; }
        public string CreatedDate { get; set; }

        public int Provider { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
        public int CurrencyType { get; set; }
        public IEnumerable<CurrencyType> CurrencyTypes { get; set; }
    }
}