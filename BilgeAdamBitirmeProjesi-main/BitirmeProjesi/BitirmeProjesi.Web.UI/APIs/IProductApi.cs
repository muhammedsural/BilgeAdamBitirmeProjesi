using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface IProductApi
    {
        [Get("/Product")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> List();

        [Get("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Get(int id);

        [Post("/Product")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Post(ProductRequest request);

        [Put("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Put([FromQuery]int id, [FromBody] ProductRequest request);

        [Delete("/Product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Delete(int id);

        [Get("/Product/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Product/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetActive();
        [Post("/Product/ShopGrid")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GridFlitre(ShopGridRequestModelDTO request);

    }
}
