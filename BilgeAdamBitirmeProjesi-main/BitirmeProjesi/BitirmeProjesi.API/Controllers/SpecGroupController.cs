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
using BitirmeProjesi.Service.Repository.SpecGroup;
using BitirmeProjesi.Common.DTOs.SpecGroup;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("specgroup")]
    public class SpecGroupController : BaseApiController<SpecGroupController>
    {
        private readonly ISpecGroupRepository _cr;
        private readonly IMapper _mapper;

        public SpecGroupController(
            ISpecGroupRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecGroupResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<SpecGroupResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<SpecGroupResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<SpecGroupResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<SpecGroupResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<SpecGroupResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<SpecGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> PostCategory(SpecGroupRequest request)
        {
            SpecGroup entity = _mapper.Map<SpecGroup>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                SpecGroupResponse rm = _mapper.Map<SpecGroupResponse>(insertResult);
                return new WebApiResponse<SpecGroupResponse>(true, "Success", rm);
            }

            return new WebApiResponse<SpecGroupResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> PutCategory(int id, SpecGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecGroup entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    SpecGroupResponse rm = _mapper.Map<SpecGroupResponse>(updateResult);
                    return new WebApiResponse<SpecGroupResponse>(true, "Success", rm);
                }

                return new WebApiResponse<SpecGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}