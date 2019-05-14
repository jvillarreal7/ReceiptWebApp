using Microsoft.AspNet.Identity;
using ReceiptWebApp.Models;
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

        [HttpDelete]
        public IHttpActionResult Deactivate(int id)
        {
            var userId = User.Identity.GetUserId();
            var receipt = _context.Receipts.Single(g => g.Id == id && g.UserId == userId);
            receipt.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }
    }
}
