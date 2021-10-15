using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Cart;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartApi
    {
        [Get("/Cart")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponse>>>> List();

        [Get("/Cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Get(int id);

        [Post("/Cart")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Post(CartItemRequest request);

        [Put("/Cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Put([FromQuery] int id, [FromBody] CartRequest request);

        [Delete("/Cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Delete(int id);

        [Get("/Cart/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Cart/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartResponse>>>> GetActive();
    }
}