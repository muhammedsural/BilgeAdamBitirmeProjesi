using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Infrastructure.Helpers;
using BitirmeProjesi.Web.UI.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitirmeProjesi.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountApi accountApi,
            IMapper mapper)
        {
            _accountApi = accountApi;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                
                var loginRequest = await _accountApi.Login(_mapper.Map<LoginRequest>(request));
                if (loginRequest.IsSuccessStatusCode && loginRequest.Content.IsSuccess)
                {
                    MemberResponse user = loginRequest.Content.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.firstname),
                        new Claim(ClaimTypes.Surname, user.surname),
                        new Claim(ClaimTypes.Email, user.email),
                    };

                    //Giriş işlemlerini tamamlıyoruz ve kullanıcyı yönetici sayfasına yönlendiriyoruz...
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    var cookieModel = new CookieModel
                    {
                        Id = user.Id,
                        FirstName = user.firstname,
                        LastName = user.surname,
                        Email = user.email,
                        AccessToken = user.AccessToken,
                    };
                    HttpContext.Response.Cookies.Append("BilgeAdamAccessToken",
                        JsonConvert.SerializeObject(cookieModel).Encrypt());
                    //Microsoft.AspNetCore.Authentication
                    await HttpContext.SignInAsync(principal);
                    if (user.isAdmin)
                        return RedirectToAction("Index", "AdminHome", new {area = "Admin"});
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        //Kullanıcının güvenli çıkış işlemlerini tamamlıyoruz...
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
    }
}