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
using BitirmeProjesi.Service.Repository.SpecName;
using BitirmeProjesi.Common.DTOs.SpecName;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("specname")]
    public class SpecNameController : BaseApiController<SpecNameController>
    {
        private readonly ISpecNameRepository _cr;
        private readonly IMapper _mapper;

        public SpecNameController(
            ISpecNameRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecNameResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<SpecNameResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<SpecNameResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<SpecNameResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<SpecNameResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<SpecNameResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<SpecNameResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> PostCategory(SpecNameRequest request)
        {
            SpecName entity = _mapper.Map<SpecName>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                SpecNameResponse rm = _mapper.Map<SpecNameResponse>(insertResult);
                return new WebApiResponse<SpecNameResponse>(true, "Success", rm);
            }

            return new WebApiResponse<SpecNameResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> PutCategory(int id, SpecNameRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecName entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    SpecNameResponse rm = _mapper.Map<SpecNameResponse>(updateResult);
                    return new WebApiResponse<SpecNameResponse>(true, "Success", rm);
                }

                return new WebApiResponse<SpecNameResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}