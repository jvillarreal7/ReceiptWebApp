using Microsoft.AspNet.Identity;
using ReceiptWebApp.Models;
using ReceiptWebApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ReceiptWebApp.Controllers
{
    [Authorize]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceiptFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Providers = _context.Providers.ToList();
                viewModel.CurrencyTypes = _context.CurrencyTypes.ToList();
                return View("Create", viewModel);
            }

            var receipt = new Receipt
            {
                UserId = User.Identity.GetUserId(),
                CreatedDate = DateTime.Parse(viewModel.CreatedDate),
                Amount = viewModel.Amount,
                Comments = viewModel.Comments,
                ProviderId = viewModel.Provider,
                CurrencyTypeId = viewModel.CurrencyType
            };

            TempData["alert"] = new GenericResponse()
            {
                AlertType = "success",
                Message = "Recibo creado con éxito.",
                Title = "Éxito"
            };
            _context.Receipts.Add(receipt);
            _context.SaveChanges();

            return RedirectToAction("List", "Receipts");
        }

        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            var receipts = _context.Receipts
                .Include(x => x.Provider)
                .Include(x => x.CurrencyType)
                .Where(g => g.UserId == userId);

            ViewBag.Response = TempData["alert"];

            return View(receipts);
        }
    }
}