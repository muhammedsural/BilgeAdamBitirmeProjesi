using System.Diagnostics;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminDashboardController : Controller
    {
        private readonly ILogger<AdminDashboardController> _logger;

        public AdminDashboardController(ILogger<AdminDashboardController> logger)
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