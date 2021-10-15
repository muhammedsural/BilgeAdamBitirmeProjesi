using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Common.DTOs.Brand;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminBrandController : Controller
    {
        private readonly ILogger<AdminBrandController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly IBrandApi _brandApi;
        private readonly IMapper _mapper;
        private object _categoryApi;

        public AdminBrandController(ILogger<AdminBrandController> logger, IWebHostEnvironment env,
            IBrandApi brandApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _brandApi = brandApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BrandViewModel> list = new List<BrandViewModel>();
            var listResult = await _brandApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<BrandViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateBrandViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _brandApi.Post(_mapper.Map<CreateBrandViewModel>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] =
                        "Kayıt işlemi sırasında bir hata oluştu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";

            return Json(true);
        }

        [HttpGet("BrandUpdateView")]
        public async Task<IActionResult> BrandUpdateView(int id)
        {
            AdminBrandViewModel apvm = new AdminBrandViewModel();


            UpdateBrandViewModel model = new UpdateBrandViewModel();
            var updateResult = await _brandApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess &&
                updateResult?.Content?.ResultData != null)
                model = _mapper.Map<UpdateBrandViewModel>(updateResult.Content.ResultData);
            apvm.updateBrandViewModel = model;


            return View(apvm);
        }

        [HttpPost("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updatetResult = await _brandApi.Put(item.Id, _mapper.Map<BrandRequest>(item));
                if (updatetResult.IsSuccessStatusCode && updatetResult.Content.IsSuccess &&
                    updatetResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] =
                        "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBrand(int id)
        {
            var insertResult = await _brandApi.Delete(id);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

    }
}