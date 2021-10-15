using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Service.Repository.Member;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BitirmeProjesi.API.Controllers
{
    [Route("Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IMemberRepository _ur;

        public AccountController(
            IMapper mapper,
            IConfiguration configuration, IMemberRepository ur)
        {
            _ur = ur;
            _mapper = mapper;
            _configuration = configuration;
        }

        //http://localhost:5000/account/login?Email=admin@admin.com&Password=123
        [HttpPost("Login")]
        public async Task<WebApiResponse<MemberResponse>> Login([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _ur.GetDefault(x => x.email == request.Email && x.password == request.Password);
                if (result != null)
                {
                    MemberResponse rm = _mapper.Map<MemberResponse>(result);
                    rm.AccessToken = SetAccessToken(rm);
                    return new WebApiResponse<MemberResponse>(true, "Success", rm);
                }
            }

            return new WebApiResponse<MemberResponse>(
                false,
                ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString());
        }

        private GetAccessToken SetAccessToken(MemberResponse rm)
        {
            var claims = new List<Claim>
            {
                //using System.IdentityModel.Tokens.Jwt;
                new Claim(JwtRegisteredClaimNames.Email, rm.email),
                new Claim(JwtRegisteredClaimNames.Jti, rm.Id.ToString())
            };

            //JWT

            var systemSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var signingCredentials = new SigningCredentials(systemSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Tokens:Expires"]));
            var ticks = expires.ToUnixTime();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience: _configuration["Tokens:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials
            );
            return new GetAccessToken
            {
                TokenType = "BilgeAdamAccessToken",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expires = ticks,
                RefreshToken = $"{rm.email}_{rm.password}_{ticks}".Encrypt()
            };
        }

        //http://localhost:5000/account/refreshtoken?user_name=admin@admin.com&refresh_token=YWRtaW5AYWRtaW4uY29tXzEyM18xNjEyMDA3OTM3
        [HttpPost("refreshtoken")]
        public async Task<WebApiResponse<GetAccessToken>> RefreshToken([FromQuery] RefreshToken request)
        {
            if (string.IsNullOrEmpty(request.Refresh_Token))
                throw new Exception("Invalid Refresh Token ");

            var key = request.Refresh_Token.Decrypt();
            var userInfo = key.Split('_');

            if (userInfo.Length < 3 || userInfo[0] != request.User_Name)
                throw new Exception("Geçersiz Token Yenileme ");

            var result = await _ur.GetByDefault(x => x.email == userInfo[0] && x.password == userInfo[1]);
            if (result != null)
            {
                MemberResponse rm = _mapper.Map<MemberResponse>(result);
                rm.AccessToken = SetAccessToken(rm);
                return new WebApiResponse<GetAccessToken>(true, "Success", rm.AccessToken);
            }

            return new WebApiResponse<GetAccessToken>(false, "User Not Found ");
        }
    }
}