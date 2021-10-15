using System.Diagnostics;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AdminCalenderController : Controller
    {
        private readonly ILogger<AdminCalenderController> _logger;

        public AdminCalenderController(ILogger<AdminCalenderController> logger)
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