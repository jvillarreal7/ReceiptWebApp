using ReceiptWebApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReceiptWebApp.ViewModels
{
    public class ReceiptFormViewModel
    {
        public int Id { get; set; }

        [DisplayName("Monto")]
        [Required(ErrorMessage = "El monto es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser una cantidad mayor a 0.")]
        public double Amount { get; set; }

        [DisplayName("Comentarios")]
        public string Comments { get; set; }

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "La fecha es requerida.")]
        public string CreatedDate { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "El proveedor es requerido.")]
        public int Provider { get; set; }

        public IEnumerable<Provider> Providers { get; set; }

        [DisplayName("Tipo de cambio")]
        [Required(ErrorMessage = "El tipo de cambio es requerido.")]
        public int CurrencyType { get; set; }

        public IEnumerable<CurrencyType> CurrencyTypes { get; set; }
    }
}