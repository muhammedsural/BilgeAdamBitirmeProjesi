using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.MemberViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BitirmeProjesi.Common.DTOs.Member;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminCustomerController : Controller
    {
        private readonly ILogger<AdminCustomerController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly IMemberApi _memberApi;
        private readonly IMapper _mapper;

        public AdminCustomerController(ILogger<AdminCustomerController> logger, IWebHostEnvironment env,
            IMemberApi memberApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _memberApi = memberApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<MemberViewModel> list = new List<MemberViewModel>();
            var listResult = await _memberApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<MemberViewModel>>(listResult.Content.ResultData);
            return View(list);
        }


    }
}