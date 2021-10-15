using AutoMapper;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Service.WorkContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BitirmeProjesi.Service.Repository.Member;

namespace BitirmeProjesi.API.Infrastructor.Models.Base
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemberRepository _ur;
        private readonly IMapper _mapper;

        public ApiWorkContext(
            IHttpContextAccessor httpContextAccessor,
            IMemberRepository ur,
            IMapper mapper
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _ur = ur;
            _mapper = mapper;
        }

        public MemberResponse CurrentUser
        {
            get
            {
                //using Microsoft.AspNetCore.Authentication;
                //using Microsoft.AspNetCore.Authentication.JwtBearer;
                var authResult = _httpContextAccessor.HttpContext
                    .AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
                if (!authResult.Succeeded)
                    return null;

                var email = authResult.Principal.Claims
                    .FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Email).Value;
                //using System.IdentityModel.Tokens.Jwt;
                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)
                    .Value;
                MemberResponse user = _mapper.Map<MemberResponse>(_ur.GetById(Int32.Parse(userId)).Result);
                return user;
            }
            set { CurrentUser = value; }
        }

    }
}