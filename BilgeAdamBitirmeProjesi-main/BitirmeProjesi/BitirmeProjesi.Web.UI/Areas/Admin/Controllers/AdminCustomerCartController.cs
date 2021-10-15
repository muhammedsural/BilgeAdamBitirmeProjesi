using System.Diagnostics;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminCustomerCartController : Controller
    {
        private readonly ILogger<AdminCustomerCartController> _logger;

        public AdminCustomerCartController(ILogger<AdminCustomerCartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}