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
using BitirmeProjesi.Service.Repository.Location;
using BitirmeProjesi.Common.DTOs.Location;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("location")]
    public class LocationController : BaseApiController<LocationController>
    {
        private readonly ILocationRepository _cr;
        private readonly IMapper _mapper;

        public LocationController(
            ILocationRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<LocationResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<LocationResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<LocationResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<LocationResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<LocationResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<LocationResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<LocationResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<LocationResponse>>> PostCategory(LocationRequest request)
        {
            Location entity = _mapper.Map<Location>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                LocationResponse rm = _mapper.Map<LocationResponse>(insertResult);
                return new WebApiResponse<LocationResponse>(true, "Success", rm);
            }

            return new WebApiResponse<LocationResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<LocationResponse>>> PutCategory(int id, LocationRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Location entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    LocationResponse rm = _mapper.Map<LocationResponse>(updateResult);
                    return new WebApiResponse<LocationResponse>(true, "Success", rm);
                }

                return new WebApiResponse<LocationResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}