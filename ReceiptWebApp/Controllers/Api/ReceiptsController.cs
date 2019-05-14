using Microsoft.AspNet.Identity;
using ReceiptWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace ReceiptWebApp.Controllers.Api
{
    [Authorize]
    public class ReceiptsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ReceiptsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                List<Receipt> receipts = _context.Receipts
                    .Include(x => x.User)
                    .Include(x => x.Provider)
                    .Include(x => x.CurrencyType)
                    .Where(x => x.UserId == userId && x.IsActive == true)
                    .ToList();
                return Json(receipts);
            }
            catch
            {
                return BadRequest();
            }
            

        }

        [HttpDelete]
        public IHttpActionResult Deactivate(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var receipt = _context.Receipts.Single(g => g.Id == id && g.UserId == userId);
                receipt.IsActive = false;
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
