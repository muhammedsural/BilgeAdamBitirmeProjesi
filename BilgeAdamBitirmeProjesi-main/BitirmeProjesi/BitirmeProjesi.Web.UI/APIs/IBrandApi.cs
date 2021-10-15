using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Brand;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface IBrandApi
    {
        [Get("/Brand")]
        Task<ApiResponse<WebApiResponse<List<BrandResponse>>>> List();

        [Get("/Brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Get(int id);

        [Post("/Brand")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Post(CreateBrandViewModel request);

        [Put("/Brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Put([FromQuery]int id, [FromBody]BrandRequest request);

        [Delete("/Brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Delete(int id);

        [Get("/Brand/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Brand/getactive")]
        Task<ApiResponse<WebApiResponse<List<BrandResponse>>>> GetActive();

    }
}
