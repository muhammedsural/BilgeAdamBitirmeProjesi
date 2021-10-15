using AutoMapper;
using BitirmeProjesi.API.Controllers.Base;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using BitirmeProjesi.Service.Repository.Town;
using BitirmeProjesi.Common.DTOs.Town;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("town")]
    public class TownController : BaseApiController<TownController>
    {
        private readonly ITownRepository _cr;
        private readonly IMapper _mapper;

        public TownController(
            ITownRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<TownResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<TownResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<TownResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<TownResponse>>(false, "Error");
        }

    }
}