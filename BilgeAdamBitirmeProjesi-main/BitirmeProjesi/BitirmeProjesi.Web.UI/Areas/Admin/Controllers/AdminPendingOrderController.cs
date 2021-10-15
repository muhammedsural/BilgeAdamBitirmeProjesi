using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.PendingOrderViewModels;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminPendingOrderController : Controller
    {
        private readonly ILogger<AdminPendingOrderController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly IPendingOrderApi _PendingOrderApi;
        private readonly IMapper _mapper;


        public AdminPendingOrderController(ILogger<AdminPendingOrderController> logger, IWebHostEnvironment env,
            IPendingOrderApi PendingOrderApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _PendingOrderApi = PendingOrderApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PendingOrderViewModel> list = new List<PendingOrderViewModel>();
            var listResult = await _PendingOrderApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PendingOrderViewModel>>(listResult.Content.ResultData);
            return View(list);
        }
    }
}