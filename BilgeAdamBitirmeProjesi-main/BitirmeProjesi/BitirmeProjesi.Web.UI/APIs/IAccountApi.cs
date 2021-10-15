using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    
    public interface IAccountApi
    {
        [Post("/Account/Login")]
        Task<ApiResponse<WebApiResponse<MemberResponse>>> Login([FromBody]LoginRequest request);

        [Post("/account/refreshtoken")]
        Task<ApiResponse<WebApiResponse<GetAccessToken>>> RefreshToken(RefreshToken request);
    }
}