using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Category;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AdminCategoryController : Controller
    {
        private readonly ILogger<AdminCategoryController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public AdminCategoryController(ILogger<AdminCategoryController> logger, IWebHostEnvironment env,
            ICategoryApi categoryApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _categoryApi = categoryApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var a = _mapper.Map<CategoryRequest>(item);
                var insertResult = await _categoryApi.Post(a);
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

        [HttpGet("CategoryUpdateView")]
        public async Task<IActionResult> CategoryUpdateView(int id)
        {
            AdminCategoryViewModel apvm = new AdminCategoryViewModel();


            UpdateCategoryViewModel model = new UpdateCategoryViewModel();
            var updateResult = await _categoryApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess &&
                updateResult?.Content?.ResultData != null)
                model = _mapper.Map<UpdateCategoryViewModel>(updateResult.Content.ResultData);
            apvm.updateCategoryViewModel = model;


            return View(apvm);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updatetResult = await _categoryApi.Put(item.Id, _mapper.Map<CategoryRequest>(item));
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

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var insertResult = await _categoryApi.Delete(id);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
    }
}