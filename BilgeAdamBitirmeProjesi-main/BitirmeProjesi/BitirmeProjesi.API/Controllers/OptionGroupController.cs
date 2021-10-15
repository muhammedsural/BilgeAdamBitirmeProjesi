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
using BitirmeProjesi.Service.Repository.OptionGroup;
using BitirmeProjesi.Common.DTOs.OptionGroup;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("optiongroup")]
    public class OptionGroupController : BaseApiController<OptionGroupController>
    {
        private readonly IOptionGroupRepository _cr;
        private readonly IMapper _mapper;

        public OptionGroupController(
            IOptionGroupRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionGroupResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OptionGroupResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OptionGroupResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OptionGroupResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OptionGroupResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OptionGroupResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OptionGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> PostCategory(OptionGroupRequest request)
        {
            OptionGroup entity = _mapper.Map<OptionGroup>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OptionGroupResponse rm = _mapper.Map<OptionGroupResponse>(insertResult);
                return new WebApiResponse<OptionGroupResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OptionGroupResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> PutCategory(int id, OptionGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OptionGroup entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OptionGroupResponse rm = _mapper.Map<OptionGroupResponse>(updateResult);
                    return new WebApiResponse<OptionGroupResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OptionGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}