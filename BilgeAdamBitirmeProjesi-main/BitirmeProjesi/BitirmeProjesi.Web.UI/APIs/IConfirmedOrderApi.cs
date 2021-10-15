using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Order;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ConfirmedOrderViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface IConfirmedOrderApi
    {
        [Get("/Order")]
        Task<ApiResponse<WebApiResponse<List<OrderResponse>>>> List();

        [Get("/Order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Get(int id);

        [Post("/Order")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Post(CreateConfirmedOrderViewModel request);

        [Put("/Order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Put([FromQuery]int id, [FromBody] OrderRequest request);

        [Delete("/Order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Delete(int id);

        [Get("/Order/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Order/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderResponse>>>> GetActive();

    }
}
