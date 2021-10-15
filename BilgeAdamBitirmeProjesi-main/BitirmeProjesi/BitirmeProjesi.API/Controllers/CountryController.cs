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
using BitirmeProjesi.Service.Repository.Country;
using BitirmeProjesi.Common.DTOs.Country;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("country")]
    public class CountryController : BaseApiController<CountryController>
    {
        private readonly ICountryRepository _cr;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountryResponse>>>> GetCategories()
        {
            var categoryResult = _mapper.Map<List<CountryResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CountryResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<CountryResponse>>(false, "Error");
        }
    }
}