using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Category;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/category")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> List();

        [Get("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Get(int id);

        [Post("/category")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Post(CategoryRequest request);

        [Put("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Put([FromQuery]int id, [FromBody]CategoryRequest request);

        [Delete("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Delete(int id);

        [Get("/category/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/category/getactive")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetActive();

    }
}
