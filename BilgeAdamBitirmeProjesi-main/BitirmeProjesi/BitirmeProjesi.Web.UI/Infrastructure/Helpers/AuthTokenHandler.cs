using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using BilgeAdamBlog.Web.UI.Infrastructure.Helpers;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.APIs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BitirmeProjesi.Web.UI.Infrastructure.Helpers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountApi _accountApi;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor, IAccountApi accountApi)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountApi = accountApi;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("BilgeAdamAccessToken"))
            {
                var cookieModel = 
                    JsonConvert.DeserializeObject<CookieModel>(_httpContextAccessor.HttpContext.Request.Cookies["BilgeAdamAccessToken"].Decrypt());
                if (cookieModel.AccessToken.Expires <= DateTime.Now.ToUnixTime())
                {
                    var getAccessTokenResult = _accountApi.RefreshToken(new RefreshToken
                    {
                        User_Name = cookieModel.Email,
                        Refresh_Token = cookieModel.AccessToken.RefreshToken
                    }).Result;
                    if (getAccessTokenResult.IsSuccessStatusCode && getAccessTokenResult.Content.IsSuccess)
                    {
                        var getAccessToken = getAccessTokenResult.Content.ResultData;

                        var claims = new List<Claim>()
                        {
                            new Claim("Id",cookieModel.Id.ToString()),
                            new Claim(ClaimTypes.Name, cookieModel.FirstName),
                            new Claim(ClaimTypes.Surname, cookieModel.LastName),
                            new Claim(ClaimTypes.Email,cookieModel.Email),
                            new Claim("Image",cookieModel.ImagePath)
                        };

                        //Giriş işlemlerini tamamlıyoruz ve kullanıcyı yönetici sayfasına yönlendiriyoruz...
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        cookieModel.AccessToken = getAccessToken;
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("BilgeAdamAccessToken", JsonConvert.SerializeObject(cookieModel).Encrypt());
                        //Microsoft.AspNetCore.Authentication
                        _httpContextAccessor.HttpContext.SignInAsync(principal).Wait();

                        var token = getAccessToken.AccessToken;
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
                }
                else
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", cookieModel.AccessToken.AccessToken);
                }

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
