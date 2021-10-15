using AutoMapper;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using Microsoft.AspNetCore.Authorization;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UpdateProductViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Common.Models;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AdminProductController : Controller
    {
        private readonly ILogger<AdminProductController> _logger;

        private readonly IWebHostEnvironment _env;
        private readonly IProductApi _productApi;
        private readonly ICategoryApi _categoryApi;
        private readonly IBrandApi _brandApi;
        private readonly IMapper _mapper;

        public AdminProductController(ILogger<AdminProductController> logger, IWebHostEnvironment env,
            IProductApi productApi, ICategoryApi categoryApi, IBrandApi brandApi,
            IMapper mapper)
        {
            _logger = logger;
            _env = env;
            _productApi = productApi;
            _categoryApi = categoryApi;
            _brandApi = brandApi;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Index()
        {
            AdminProductViewModel apvm = new AdminProductViewModel();


            List<ProductViewModel> productList = new List<ProductViewModel>();
            var productResult = await _productApi.List();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
            apvm.productViewModels = productList;


            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var categoryResult = await _categoryApi.List();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess &&
                categoryResult.Content.ResultData.Any())
                categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
            apvm.categoryViewModels = categoryList;

            List<BrandViewModel> brandList = new List<BrandViewModel>();
            var brandResult = await _brandApi.List();
            if (brandResult.IsSuccessStatusCode && brandResult.Content.IsSuccess &&
                brandResult.Content.ResultData.Any())
                brandList = _mapper.Map<List<BrandViewModel>>(brandResult.Content.ResultData);
            apvm.brandViewModels = brandList;
            return View(apvm);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _productApi.Post(_mapper.Map<ProductRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] =
                        "Kayıt işlemi sırasında bir hata oluştu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen Tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }

        [HttpGet("ProductUpdateView")]
        public async Task<IActionResult> ProductUpdateView(int id)
        {
            AdminProductViewModel apvm = new AdminProductViewModel();


            UpdateProductViewModel model = new UpdateProductViewModel();
            var updateResult = await _productApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess &&
                updateResult?.Content?.ResultData != null)
                model = _mapper.Map<UpdateProductViewModel>(updateResult.Content.ResultData);
            apvm.updateProductViewModel = model;


            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var categoryResult = await _categoryApi.List();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess &&
                categoryResult.Content.ResultData.Any())
                categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
            apvm.categoryViewModels = categoryList;

            List<BrandViewModel> brandList = new List<BrandViewModel>();
            var brandResult = await _brandApi.List();
            if (brandResult.IsSuccessStatusCode && brandResult.Content.IsSuccess &&
                brandResult.Content.ResultData.Any())
                brandList = _mapper.Map<List<BrandViewModel>>(brandResult.Content.ResultData);
            apvm.brandViewModels = brandList;

            return View(apvm);
        }


        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updatetResult = await _productApi.Put(item.Id, _mapper.Map<ProductRequest>(item));
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


        public async Task<IActionResult> DeleteProduct(int id)
        {
            var insertResult = await _productApi.Delete(id);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }


    }
}