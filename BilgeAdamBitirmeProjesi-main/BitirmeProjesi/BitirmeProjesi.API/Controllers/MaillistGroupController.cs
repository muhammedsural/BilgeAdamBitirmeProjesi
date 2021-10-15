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
using BitirmeProjesi.Service.Repository.MaillistGroup;
using BitirmeProjesi.Common.DTOs.MaillistGroup;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("maillistgroup")]
    public class MaillistGroupController : BaseApiController<MaillistGroupController>
    {
        private readonly IMaillistGroupRepository _cr;
        private readonly IMapper _mapper;

        public MaillistGroupController(
            IMaillistGroupRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MaillistGroupResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<MaillistGroupResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<MaillistGroupResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<MaillistGroupResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistGroupResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<MaillistGroupResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<MaillistGroupResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<MaillistGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MaillistGroupResponse>>> PostCategory(MaillistGroupRequest request)
        {
            MaillistGroup entity = _mapper.Map<MaillistGroup>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                MaillistGroupResponse rm = _mapper.Map<MaillistGroupResponse>(insertResult);
                return new WebApiResponse<MaillistGroupResponse>(true, "Success", rm);
            }

            return new WebApiResponse<MaillistGroupResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistGroupResponse>>> PutCategory(int id, MaillistGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                MaillistGroup entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    MaillistGroupResponse rm = _mapper.Map<MaillistGroupResponse>(updateResult);
                    return new WebApiResponse<MaillistGroupResponse>(true, "Success", rm);
                }

                return new WebApiResponse<MaillistGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}