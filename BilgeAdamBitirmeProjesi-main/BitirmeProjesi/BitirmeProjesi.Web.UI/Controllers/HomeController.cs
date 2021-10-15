using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CartViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BitirmeProjesi.Web.UI.Models.Home;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeProjesi.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandApi _brandApi;
        private readonly ICategoryApi _categoryApi;
        private readonly IProductApi _productApi;
        private readonly ICartApi _cartApi;
        private readonly IMapper _mapper;
        private readonly ICountryApi _countryApi;
        private readonly ILocationApi _townApi;

        public HomeController(ILogger<HomeController> logger, IBrandApi brandApi, ICategoryApi categoryApi,
            IProductApi productApi, ICartApi cartApi, IMapper mapper, ICountryApi countryApi, ILocationApi townApi)
        {
            _logger = logger;
            _brandApi = brandApi;
            _categoryApi = categoryApi;
            _productApi = productApi;
            _cartApi = cartApi;
            _mapper = mapper;
            _countryApi = countryApi;
            _townApi = townApi;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var productResult = await _productApi.List();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
            hvm.productViewModels = productList;


            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var categoryResult = await _categoryApi.List();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess &&
                categoryResult.Content.ResultData.Any())
                categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
            hvm.categoryViewModels = categoryList;

            List<BrandViewModel> brandList = new List<BrandViewModel>();
            var brandResult = await _brandApi.List();
            if (brandResult.IsSuccessStatusCode && brandResult.Content.IsSuccess &&
                brandResult.Content.ResultData.Any())
                brandList = _mapper.Map<List<BrandViewModel>>(brandResult.Content.ResultData);
            hvm.brandViewModels = brandList;

            List<CartViewModel> cartList = new List<CartViewModel>();
            var cartResult = await _cartApi.List();
            if (cartResult.IsSuccessStatusCode && cartResult.Content.IsSuccess &&
                cartResult.Content.ResultData.Any())
                foreach (var cartItem in cartResult.Content.ResultData)
                {
                    var product = productList.FirstOrDefault(i => i.Id == cartItem.productId);
                    cartList.Add(new CartViewModel()
                    {
                        Id = cartItem.Id,
                        productId = product.Id,
                        base64 = product.productImage,
                        name = product.name,
                        price = product.price,
                        quantity = cartItem.quantity
                    });
                }


            hvm.cartViewModels = cartList;
            TempData["Cart"] = cartList;
            return View(hvm);
        }

        [Authorize]
        public async Task<IActionResult> InsertCart(AddCartItem item)
        {
            var product = _productApi.Get(item.Id).Result.Content.ResultData;
            var request = new CartItemRequest();
            request.quantity = item.Amount;
            request.createdAt = DateTime.Now;
            request.updatedAt = DateTime.Now;
            request.productId = item.Id;
            var insertResult = await _cartApi.Post(request);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");


            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> DeleteItemCart(int id)
        {
            var insertResult = await _cartApi.Delete(id);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Product(int id)
        {
            ProductViewModel pvm = new ProductViewModel();

            var insertResult = await _productApi.Get(id);
            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess &&
                insertResult?.Content?.ResultData != null)
                pvm = _mapper.Map<ProductViewModel>(insertResult.Content.ResultData);
            return View(pvm);
        }

        public async Task<IActionResult> ShopGrid()
        {
            HomeViewModel hvm = new HomeViewModel();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var productResult = await _productApi.List();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
            hvm.productViewModels = productList;


            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var categoryResult = await _categoryApi.List();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess &&
                categoryResult.Content.ResultData.Any())
                categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
            hvm.categoryViewModels = categoryList;

            List<BrandViewModel> brandList = new List<BrandViewModel>();
            var brandResult = await _brandApi.List();
            if (brandResult.IsSuccessStatusCode && brandResult.Content.IsSuccess &&
                brandResult.Content.ResultData.Any())
                brandList = _mapper.Map<List<BrandViewModel>>(brandResult.Content.ResultData);
            hvm.brandViewModels = brandList;
            return View(hvm);
        }

        public async Task<IActionResult> Grid(ShopGridRequestModel model)
        {
            var request = _mapper.Map<ShopGridRequestModelDTO>(model);
            var productResult = await _productApi.GridFlitre(request);

            List<ProductViewModel> productList = new List<ProductViewModel>();

            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
            return PartialView("Grid", productList);
        }

        [Authorize]
        public async Task<IActionResult> Cart()
        {
            List<CartViewModel> cartList = new List<CartViewModel>();
            var cartResult = await _cartApi.List();
            if (cartResult.IsSuccessStatusCode && cartResult.Content.IsSuccess &&
                cartResult.Content.ResultData.Any())
                foreach (var cartItem in cartResult.Content.ResultData)
                {
                    var product = _productApi.Get(cartItem.productId).Result.Content.ResultData;
                    cartList.Add(new CartViewModel()
                    {
                        Id = cartItem.Id,
                        productId = product.Id,
                        base64 = product.productImage,
                        name = product.name,
                        price = product.price,
                        quantity = cartItem.quantity
                    });
                }


            return View(cartList);
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            CheckOrderModel com = new CheckOrderModel();
            List<CartViewModel> cartList = new List<CartViewModel>();
            var cartResult = await _cartApi.List();
            if (cartResult.IsSuccessStatusCode && cartResult.Content.IsSuccess &&
                cartResult.Content.ResultData.Any())
                foreach (var cartItem in cartResult.Content.ResultData)
                {
                    var product = _productApi.Get(cartItem.productId).Result.Content.ResultData;
                    cartList.Add(new CartViewModel()
                    {
                        Id = cartItem.Id,
                        productId = product.Id,
                        base64 = product.productImage,
                        name = product.name,
                        price = product.price,
                        quantity = cartItem.quantity
                    });
                }

            com.cartViewModels = cartList;

            List<CountyViewModel> countryList = new List<CountyViewModel>();
            var countyResult = await _countryApi.List();
            if (countyResult.IsSuccessStatusCode && countyResult.Content.IsSuccess &&
                countyResult.Content.ResultData.Any())
                countryList = _mapper.Map<List<CountyViewModel>>(countyResult.Content.ResultData);
            com.countyViewModels = countryList;

            List<CityViewModel> TownList = new List<CityViewModel>();
            var townResult = await _townApi.List();
            if (townResult.IsSuccessStatusCode && townResult.Content.IsSuccess &&
                townResult.Content.ResultData.Any())
                TownList = _mapper.Map<List<CityViewModel>>(townResult.Content.ResultData);
            com.cityViewModels = TownList;


            return View(com);
        }
    }
}