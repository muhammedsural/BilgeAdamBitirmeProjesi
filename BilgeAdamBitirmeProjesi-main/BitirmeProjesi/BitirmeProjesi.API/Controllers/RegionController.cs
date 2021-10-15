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
using BitirmeProjesi.Service.Repository.Region;
using BitirmeProjesi.Common.DTOs.Region;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("region")]
    public class RegionController : BaseApiController<RegionController>
    {
        private readonly IRegionRepository _cr;
        private readonly IMapper _mapper;

        public RegionController(
            IRegionRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<RegionResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<RegionResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<RegionResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<RegionResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<RegionResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<RegionResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<RegionResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<RegionResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<RegionResponse>>> PostCategory(RegionRequest request)
        {
            Region entity = _mapper.Map<Region>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                RegionResponse rm = _mapper.Map<RegionResponse>(insertResult);
                return new WebApiResponse<RegionResponse>(true, "Success", rm);
            }

            return new WebApiResponse<RegionResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<RegionResponse>>> PutCategory(int id, RegionRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Region entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    RegionResponse rm = _mapper.Map<RegionResponse>(updateResult);
                    return new WebApiResponse<RegionResponse>(true, "Success", rm);
                }

                return new WebApiResponse<RegionResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}