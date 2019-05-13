using ReceiptWebApp.Models;
using ReceiptWebApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ReceiptWebApp.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new ReceiptFormViewModel
            {
                Providers = _context.Providers.ToList(),
                CurrencyTypes = _context.CurrencyTypes.ToList()
            };

            return View(viewModel);
        }
    }
}