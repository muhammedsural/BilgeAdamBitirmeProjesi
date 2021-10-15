using System.Diagnostics;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTagController : Controller
    {
        private readonly ILogger<AdminTagController> _logger;

        public AdminTagController(ILogger<AdminTagController> logger)
        {
            _logger = logger;
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}