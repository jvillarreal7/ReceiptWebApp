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

            TempData["action"] = "Crear";

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

            _context.Receipts.Add(receipt);
            _context.SaveChanges();

            TempData["alert"] = new GenericResponse()
            {
                AlertType = "success",
                Message = "Recibo creado con éxito.",
                Title = "Éxito"
            };

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

        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var receipt = _context.Receipts.Single(g => g.Id == id && g.UserId == userId);

            var viewModel = new ReceiptFormViewModel
            {
                Id = receipt.Id,
                Providers = _context.Providers.ToList(),
                CurrencyTypes = _context.CurrencyTypes.ToList(),
                Amount = receipt.Amount,
                Comments = receipt.Comments,
                CreatedDate = receipt.CreatedDate.ToString("dd/MM/yyyy hh:mm tt"),
                Provider = receipt.ProviderId,
                CurrencyType = receipt.CurrencyTypeId
            };

            TempData["action"] = "Editar";

            return View("Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceiptFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Providers = _context.Providers.ToList();
                viewModel.CurrencyTypes = _context.CurrencyTypes.ToList();
                return View("Edit", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var receipt = _context.Receipts.Single(g => g.Id == viewModel.Id && g.UserId == userId);
            receipt.Amount = viewModel.Amount;
            receipt.CreatedDate = DateTime.Parse(viewModel.CreatedDate);
            receipt.Comments = viewModel.Comments;
            receipt.ProviderId = viewModel.Provider;
            receipt.CurrencyTypeId = viewModel.CurrencyType;

            _context.SaveChanges();

            TempData["alert"] = new GenericResponse()
            {
                AlertType = "success",
                Message = "Recibo editado con éxito.",
                Title = "Éxito"
            };

            return RedirectToAction("List", "Receipts");
        }
    }
}