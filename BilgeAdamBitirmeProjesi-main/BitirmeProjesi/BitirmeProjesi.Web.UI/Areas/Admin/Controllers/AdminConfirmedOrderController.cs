using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ConfirmedOrderViewModels;
using BitirmeProjesi.Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminConfirmedOrderController : Controller
    {
        private readonly ILogger<AdminConfirmedOrderController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly IConfirmedOrderApi _confirmedOrderApi;
        private readonly IMapper _mapper;


        public AdminConfirmedOrderController(ILogger<AdminConfirmedOrderController> logger, IWebHostEnvironment env,
            IConfirmedOrderApi confirmedOrderApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _confirmedOrderApi = confirmedOrderApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ConfirmedOrderViewModel> list = new List<ConfirmedOrderViewModel>();
            var listResult = await _confirmedOrderApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ConfirmedOrderViewModel>>(listResult.Content.ResultData);
            return View(list);
        }
    }
}