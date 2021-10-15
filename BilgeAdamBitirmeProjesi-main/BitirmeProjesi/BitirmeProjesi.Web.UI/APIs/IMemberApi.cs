using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.MemberViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer","Content-Type: application/json")]
    public interface IMemberApi
    {
        [Get("/Member")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> List();

        [Get("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Get(int id);

        [Post("/Member")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Post(CreateMemberViewModel request);

        [Put("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Put([FromQuery]int id, [FromBody] MemberRequest request);

        [Delete("/Member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Delete(int id);

        [Get("/Member/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(int id);

        [Get("/Member/getactive")]
        Task<ApiResponse<WebApiResponse<List<MemberResponse>>>> GetActive();

    }
}
