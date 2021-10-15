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
using BitirmeProjesi.Service.Repository.Member;
using BitirmeProjesi.Common.DTOs.Member;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("member")]
    public class MemberController : BaseApiController<MemberController>
    {
        private readonly IMemberRepository _cr;
        private readonly IMapper _mapper;

        public MemberController(
            IMemberRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<MemberResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<MemberResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<MemberResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<MemberResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<MemberResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<MemberResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MemberResponse>>> PostCategory(MemberRequest request)
        {
            Member entity = _mapper.Map<Member>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                MemberResponse rm = _mapper.Map<MemberResponse>(insertResult);
                return new WebApiResponse<MemberResponse>(true, "Success", rm);
            }

            return new WebApiResponse<MemberResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberResponse>>> PutCategory(int id, MemberRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Member entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    MemberResponse rm = _mapper.Map<MemberResponse>(updateResult);
                    return new WebApiResponse<MemberResponse>(true, "Success", rm);
                }

                return new WebApiResponse<MemberResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}